using System.Collections;
using UnityEngine;

public class skill_45_bullet : MonoBehaviour
{
    public float speed = 30f;
    private GameObject targetObject;
    private Vector3 moveDirection;
    public Animator Guardian_45_bullet;
    public GameObject Img_Guardian; // 需要設定 Guardian 的圖像
    private bool isFacingRight = true;

    void Start()
    {
        targetObject = GameObject.Find("Player_S");
        if (targetObject != null)
        {
            GameObject nearestNPC = FindNearestNPC();
            if (nearestNPC != null)
            {
                moveDirection = (nearestNPC.transform.position - transform.position).normalized; // 朝向最近 NPC
                transform.forward = moveDirection; // 確保子彈朝向移動方向
                CheckAndFlip(nearestNPC.transform.position); // 初始時檢查翻轉
            }
            else
            {
                moveDirection = transform.forward; // 若無 NPC，則沿當前朝向移動
            }
        }
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private GameObject FindNearestNPC()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        GameObject nearestNPC = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject npc in npcs)
        {
            float distance = Vector3.Distance(transform.position, npc.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestNPC = npc;
            }
        }
        return nearestNPC;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            Guardian_45_bullet.SetTrigger("bullet45");
           StartCoroutine(bullet45_AniEnd());
        }
    }

    void CheckAndFlip(Vector3 targetPosition)
    {
        if ((moveDirection.x > 0 && !isFacingRight) || (moveDirection.x < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
        Vector3 theScale = Img_Guardian.transform.localScale;
        theScale.x *= -1;
        Img_Guardian.transform.localScale = theScale;
        }
    }

    IEnumerator bullet45_AniEnd()
    {
        yield return new WaitUntil(() =>
        {
            AnimatorStateInfo stateInfo = Guardian_45_bullet.GetCurrentAnimatorStateInfo(0);
            return stateInfo.IsName("bullet45_bomb") && stateInfo.normalizedTime >= 0.98f;
        });
        Destroy(gameObject);
    }
}
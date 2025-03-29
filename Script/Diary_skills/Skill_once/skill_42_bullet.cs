using System.Collections;
using UnityEngine;

public class skill_42_bullet : MonoBehaviour
{
    public float speed = 10f;
    private GameObject targetObject;
    private Vector3 moveDirection;
    public Animator Guardian_42_bullet;
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
                Vector3 direction = nearestNPC.transform.position - transform.position;
                direction.y = 0; // 確保不受 Y 軸影響
                moveDirection = direction.normalized;
                CheckAndFlip(nearestNPC.transform.position);
            }
            else
            {
                moveDirection = transform.forward;
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
            Guardian_42_bullet.SetTrigger("bullet42");
            StartCoroutine(bullet42_AniEnd());
        }
    }

    void CheckAndFlip(Vector3 targetPosition)
    {
        // 反轉判斷邏輯
        if ((moveDirection.x > 0 && isFacingRight) || (moveDirection.x < 0 && !isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = Img_Guardian.transform.localScale;
            theScale.x *= -1;
            Img_Guardian.transform.localScale = theScale;
        }
    }

    IEnumerator bullet42_AniEnd()
    {
        yield return new WaitUntil(() =>
        {
            AnimatorStateInfo stateInfo = Guardian_42_bullet.GetCurrentAnimatorStateInfo(0);
            return stateInfo.IsName("bullet_bomb42") && stateInfo.normalizedTime >= 0.98f;
        });
        Destroy(gameObject);
    }
}

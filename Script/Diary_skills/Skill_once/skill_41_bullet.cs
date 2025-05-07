using System.Collections;
using UnityEngine;

public class skill_41_bullet : MonoBehaviour
{
    public float speed = 15f;
    private GameObject targetObject;
    private Vector3 moveDirection;
    public Animator Guardian_41_bullet;
    public GameObject Img_Guardian; // 需要設定 Guardian 的圖像
    private bool isFacingRight = true;
    float lifetime = 5;

    void Start()
    {
        targetObject = GameObject.Find("Player_S");
        if (targetObject != null)
        {
            GameObject nearestNPC = FindNearestNPC();
            if (nearestNPC != null)
            {
                Vector3 rawDir = nearestNPC.transform.position - transform.position;
                rawDir.y = 0f;
                moveDirection = rawDir.normalized;
                transform.forward = moveDirection;
                CheckAndFlip(nearestNPC.transform.position);
            }
        }
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        if (static_parameters.Change_enemy == 0) Destroy(gameObject);
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
            speed = 0; // 停止移動
            Guardian_41_bullet.SetTrigger("Guardian_41_bullet");
            StartCoroutine(bullet41_AniEnd());
        }
    }

    void CheckAndFlip(Vector3 targetPosition)
    {
        if ((moveDirection.x > 0 && isFacingRight) || (moveDirection.x < 0 && !isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = Img_Guardian.transform.localScale;
            theScale.x *= -1;
            Img_Guardian.transform.localScale = theScale;
        }
    }

    IEnumerator bullet41_AniEnd()
    {
        yield return new WaitUntil(() =>
        {
            AnimatorStateInfo stateInfo = Guardian_41_bullet.GetCurrentAnimatorStateInfo(0);
            return stateInfo.IsName("bullet41_bomb") && stateInfo.normalizedTime >= 0.98f;
        });
        Destroy(gameObject, 0.5f);
    }
}
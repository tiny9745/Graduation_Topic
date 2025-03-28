using System.Collections;
using UnityEngine;

public class skill_41_bullet : MonoBehaviour
{
    public float speed = 10f;
    private GameObject targetObject;
    private Vector3 moveDirection;
    public Animator Guardian_41_bullet;
    // private bool isFacingRight = true;

    void Start()
    {
        targetObject = GameObject.Find("Player_S");
        if (targetObject != null)
        {
            GameObject nearestNPC = FindNearestNPC();
            if (nearestNPC != null)
            {
                moveDirection = (nearestNPC.transform.position - transform.position).normalized; // 直接朝向 NPC
                transform.forward = moveDirection; // 確保子彈的前方對準 NPC
            }
            else
            {
                moveDirection = transform.forward; // 若無 NPC，則沿當前朝向前進
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
            Guardian_41_bullet.SetTrigger("Guardian_41_bullet");
            Destroy(gameObject, 0.11f);
        }
    }
}

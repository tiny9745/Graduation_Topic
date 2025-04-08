using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float NPC_ATK = 0, minus;
    public float speed, lifetime = 3f;
    public int damage = 10;
    float timemer;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        timemer += Time.deltaTime;
        if (timemer >= 5f)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player"))
        {
            if (!static_parameters.invincible)
            {
                minus = (float)(NPC_ATK * NPC_ATK / (static_parameters.MC_DEF + NPC_ATK));
                if (minus < 5) minus = 5.0f;
                static_parameters.MC_HP -= minus;
                Destroy(gameObject);
            }
        }
    }
}

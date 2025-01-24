using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian41_col : MonoBehaviour
{
    public GameObject bullet;
    public Transform Firepoint;

    float bullet_time = 0;
    float bullet_time_max = 8f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bullet_time < bullet_time_max)
        {
            bullet_time += Time.deltaTime;
        }
        else
        {
            bullet_time_max = Random.Range(5f, 8f);
            bullet_time = 0;
            bullet_fire();
        }
    }

    private void bullet_fire()
    {
        if (static_parameters.MC_HP > 0)
        {
            Instantiate(bullet, Firepoint.position, transform.rotation);
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

public class Start_Boss : MonoBehaviour
{
    public GameObject Boss01;

    void Start()
    {
        static_parameters.Change_enemy = 1;
        GenerateBOSS01(new Vector3(transform.position.x, 2f, -10f));
    }

    void GenerateBOSS01(Vector3 position)
    {
        // Generate the prefab and place it at the generated location
        GameObject bossInstance = Instantiate(Boss01, position, Quaternion.identity);
    }
}

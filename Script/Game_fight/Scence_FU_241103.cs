using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scence_FU_241103 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] FU;
    int scence_random; 
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Fight_FU01")
        {
            Fight_FU01();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fight_FU01()
    {
        for (int i = 0; i < 4; i++)
        {
            scence_random = Random.Range(0, 8);
            Generatescence(FU[scence_random], new Vector3(0, -33, 0 + i * 120.75f));
        }
    }
    public void Fight_FU02()
    {

    }

    void Generatescence(GameObject scence, Vector3 position)
    {
        // Generate the prefab and place it at the generated location
        GameObject fight_scence = Instantiate(scence, position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scence_FU_241103 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] FU;
    int[][] scence_exist = new int[][]
{
    new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
};
    int i, j;
    int scence_random;
    int scene_type;
    void Start()
    {
        Fight_FU01();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fight_FU01()
    {
        scence_random = Random.Range(0, 8);
        Generatescence(FU[scence_random], new Vector3(0, -33, 0 + 4 * 120.75f));
        scence_exist[0][4] = 1;
        while (!(scence_exist[8][4] == 1))
        {
            for (i = 0; i < 9; i++)
            {
                for (j = 4; j < 9; j++)
                {
                    Debug.Log("L");
                    Scenario_authentication();
                }
                for (j = 4; j >= 0; j--)
                {
                    Debug.Log("R");
                    Scenario_authentication();
                }
            }
        }
    }

    void Scenario_authentication()
    {
        scene_type = Random.Range(0, 5);
        scence_random = Random.Range(0, 8);
        int count = 0;

        if (i > 0 && scence_exist[i - 1][j] == 1) count++;
        if (i < 8 && scence_exist[i + 1][j] == 1) count++;
        if (j > 0 && scence_exist[i][j - 1] == 1) count++;
        if (j < 8 && scence_exist[i][j + 1] == 1) count++;

        // if (count == 4)
        // {
        //     scene_type = 3;
        // }
        if (!(i > 0 && scence_exist[i - 1][j] == 1 && i < 8 && scence_exist[i + 1][j] == 1 && j > 0 && scence_exist[i][j - 1] == 1 && j < 8 && scence_exist[i][j + 1] == 1))
            {
                if (scene_type == 1)
                {
                    scence_random = Random.Range(0, 8);
                    Generatescence(FU[scence_random], new Vector3(i * 120.75f, -33, j * 120.75f));
                    scence_exist[i][j] = 1;
                }
                else
                {
                    scence_exist[i][j] = 0;
                }
            }
    }
    void Generatescence(GameObject scence, Vector3 position)
    {
        // Generate the prefab and place it at the generated location
        GameObject fight_scence = Instantiate(scence, position, Quaternion.identity);
    }
}
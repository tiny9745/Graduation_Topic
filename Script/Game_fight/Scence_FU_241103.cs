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
    int i, j, sum = 0;
    int scence_random;
    int scene_type;
    void Start()
    {
        Fight_FU();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fight_FU()
    {
        scence_random = Random.Range(0, 8);
        Generatescence(FU[scence_random], new Vector3(0, -33, 0 + 4 * 120.75f));
        scence_exist[0][4] = 1;
        while (scence_exist[8][4] != 1)
        {
            for (i = 0; i < 9; i++)
            {
                for (j = 4; j < 9; j++)
                {
                    Scenario_authentication();
                }
                for (j = 4; j >= 0; j--)
                {
                    Scenario_authentication();
                }
            }
            sum++;
        }
        if (scence_exist[8][4] == 1) Debug.Log("AAAAAAA");
    }

    void Scenario_authentication()
    {
        if ((i > 0 && scence_exist[i - 1][j] == 1 || i < 8 && scence_exist[i + 1][j] == 1 || j > 0 && scence_exist[i][j - 1] == 1 || j < 8 && scence_exist[i][j + 1] == 1) && condition(i, j))
        {
            scene_type = Random.Range(0, 2);
            if (scene_type == 1)
            {
                scence_random = Random.Range(0, 8);
                Generatescence(FU[scence_random], new Vector3(i * 120.75f, -33, j * 120.75f));
                scence_exist[i][j] = 1;
            }
        }
    }

    bool condition(int a, int b)
    {
        int count = 0;
        bool safe = false;
        if (b == 4)
        {
            safe = true;
        }
        if (a > 0 && scence_exist[a - 1][b] == 1) count++;
        if (a < 8 && scence_exist[a + 1][b] == 1) count++;
        if (b > 0 && scence_exist[a][b - 1] == 1) count++;
        if (b < 8 && scence_exist[a][b + 1] == 1) count++;

        return count == 1|| count == 2 || safe == true;
    }
    void Generatescence(GameObject scence, Vector3 position)
    {
        GameObject fight_scence = Instantiate(scence, position, Quaternion.identity);
        fight_scence.name = $"Scene_{scence_random}_{i}_{j}"; // 命名
    }
}
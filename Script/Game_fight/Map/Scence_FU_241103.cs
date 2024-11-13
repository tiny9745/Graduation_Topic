using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scence_FU_241103 : MonoBehaviour
{
    public GameObject[] FU;
    public GameObject Door;
    int max_index = 4; // 須為偶數
    int[][] scence_exist = new int[][]
    {
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0},
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0},
    };
    int i, j;
    int scence_random;
    int scene_type;

    float distance_scence = 120.5f;

    void Start()
    {
        Fight_FU();
    }

    public void Fight_FU()
    {
        scence_random = Random.Range(0, 8);
        static_parameters.Map_start = scence_random;
        Generatescence(FU[scence_random], new Vector3(max_index / 2 * distance_scence, -33, 0));
        scence_exist[max_index / 2][0] = 1;

        while (scence_exist[max_index / 2][max_index] != 1)
        {
            Debug.Log("A1");
            for (i = 0; i < max_index + 1; i++)
            {
                for (j = max_index / 2; j < max_index + 1; j++)
                {
                    Scenario_authentication(i, j);
                }
                for (j = max_index / 2; j >= 0; j--)
                {
                    Scenario_authentication(i, j);
                }
            }
        }
    }

    void Scenario_authentication(int i, int j)
    {
        if (i > 0 && scence_exist[i - 1][j] == 1 || i < max_index && scence_exist[i + 1][j] == 1 || j > 0 && scence_exist[i][j - 1] == 1 || j < max_index && scence_exist[i][j + 1] == 1)
        {
            scene_type = Random.Range(0, 2);
            if (scene_type == 1 && scence_exist[i][j] == 0)
            {
                Debug.Log("A2-Yes");
                scence_random = Random.Range(0, 5);
                Generatescence(FU[scence_random], new Vector3(i * distance_scence, -33, j * distance_scence));
                scence_exist[i][j] = 1;
                if (j == max_index && (i == 1 || i == 4 || i == 7))
                {
                    end_Door(scence_random, i, j);
                }
            }
        }
    }

    bool condition(int a, int b)
    {
        int count = 0;
        bool safe = false;
        if (b == max_index / 2)
        {
            safe = true;
        }
        if (a > 0 && scence_exist[a - 1][b] == 1) count++;
        if (a < max_index && scence_exist[a + 1][b] == 1) count++;
        if (b > 0 && scence_exist[a][b - 1] == 1) count++;
        if (b < max_index && scence_exist[a][b + 1] == 1) count++;
        Debug.Log("count:" + count);
        if (safe || count == 1 || count == 2)
        {
            Debug.Log("true");
            return true;
        }
        else
        {
            Debug.Log("false");
            return false;
        }
    }

    void end_Door(int scence_number, int a, int b)
    {
        switch (scence_number)
        {
            case 0:
                GenerateDoor(Door, new Vector3(a * distance_scence + 15f, 2.5f, b * distance_scence + 44f));
                break;
            case 1:
                GenerateDoor(Door, new Vector3(a * distance_scence + 42f, 2.5f, b * distance_scence + 44f));
                break;
            case 2:
                GenerateDoor(Door, new Vector3(a * distance_scence - 8f, 2.5f, b * distance_scence + 44f));
                break;
            case 3:
                GenerateDoor(Door, new Vector3(a * distance_scence - 30f, 2.5f, b * distance_scence + 44f));
                break;
            case 4:
                GenerateDoor(Door, new Vector3(a * distance_scence - 20f, 2.5f, b * distance_scence + 44f));
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
        }
    }

    void Generatescence(GameObject scence, Vector3 position)
    {
        Debug.Log("A3");
        GameObject fight_scence = Instantiate(scence, position, Quaternion.identity);
    }
    void GenerateDoor(GameObject scence, Vector3 position)
    {
        GameObject fight_Door = Instantiate(scence, position, Quaternion.identity);
    }
}

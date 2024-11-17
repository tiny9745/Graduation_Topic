using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scence_FU_241103 : MonoBehaviour
{
    public GameObject[] FU;
    public GameObject Door;
    int max_index = 2; // 須為偶數
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
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    };
    int scence_random;
    int scene_type;
    int max_Re = 0;
    float distance_scence = 120f;

    void Start()
    {
        switch (static_parameters.stage_number_Boss)
        {
            case 0:
                max_index = 2;
                break;
            case 1:
                max_index = 4;
                break;
            case 2:
                max_index = 6;
                break;
        }
        Fight_FU();
    }

    public void Fight_FU()
    {
        scence_random = Random.Range(8, 15);
        static_parameters.Map_start = scence_random;
        Generatescence(FU[scence_random], new Vector3(max_index / 2 * distance_scence, 0, 0));
        scence_exist[max_index / 2][0] = 1;

        while (scence_exist[max_index / 2][max_index] != 1 && scence_exist[0][max_index] != 1 && scence_exist[max_index][max_index] != 1)
        {
            for (int i = 0; i < max_index + 1; i++)
            {
                for (int j = max_index / 2; j < max_index + 1; j++)
                {
                    Scenario_authentication(i, j);
                }
                for (int j = max_index / 2; j >= 0; j--)
                {
                    Scenario_authentication(i, j);
                }
            }
            max_Re++;
        }
    }

    void Scenario_authentication(int i, int j)
    {
        if (condition(i, j) == true)
        {
            scene_type = Random.Range(0, 2);
            if (scene_type == 1 && scence_exist[i][j] == 0)
            {
                if (i == max_index / 2 || j == max_index / 2){
                    scence_random = Random.Range(13, 19);
                }
                else{
                    scence_random = Random.Range(0, 13);
                }
                Generatescence(FU[scence_random], new Vector3(i * distance_scence, 0, j * distance_scence));
                scence_exist[i][j] = 1;
                if (j == max_index && (i == 0 || i == max_index / 2 || i == max_index))
                {
                    end_Door(scence_random, i, j);
                }
            }
        }
        else
            return;
    }

    bool condition(int a, int b)
    {
        int count = 0;
        if (a > 0 && scence_exist[a - 1][b] == 1)
            count++;
        if (a < max_index && scence_exist[a + 1][b] == 1)
            count++;
        if (b > 0 && scence_exist[a][b - 1] == 1)
            count++;
        if (b < max_index && scence_exist[a][b + 1] == 1)
            count++;
        if (count > 0 && count < 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void end_Door(int scence_number, int a, int b)
    {
        switch (scence_number)
        {
            case 0:
                GenerateDoor(
                    Door,
                    new Vector3(a * distance_scence + 15f, 2.5f, b * distance_scence + 44f)
                );
                break;
            case 1:
                GenerateDoor(
                    Door,
                    new Vector3(a * distance_scence + 42f, 2.5f, b * distance_scence + 44f)
                );
                break;
            case 2:
                GenerateDoor(
                    Door,
                    new Vector3(a * distance_scence - 8f, 2.5f, b * distance_scence + 44f)
                );
                break;
            case 3:
                GenerateDoor(
                    Door,
                    new Vector3(a * distance_scence - 30f, 2.5f, b * distance_scence + 44f)
                );
                break;
            case 4:
                GenerateDoor(
                    Door,
                    new Vector3(a * distance_scence - 20f, 2.5f, b * distance_scence + 44f)
                );
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
            case 15:
                break;
            case 16:
                break;
            case 17:
                break;
            case 18:
                break;
            case 19:
                break;
        }
    }

    void Generatescence(GameObject scence, Vector3 position)
    {
        GameObject fight_scence = Instantiate(scence, position, Quaternion.identity, transform); 
    }

    void GenerateDoor(GameObject scence, Vector3 position)
    {
        GameObject fight_Door = Instantiate(scence, position, Quaternion.identity);
    }
}

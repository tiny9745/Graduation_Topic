using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue_comic : MonoBehaviour
{
    uint comic_step = 0;
    uint comic_step_tmp;
    float comic_time_sum = 0;
    // Start is called before the first frame update
    void Start()
    {
        comic_step_tmp = comic_step;
    }

    // Update is called once per frame
    void Update()
    {
        comic_time_sum += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Return) && comic_time_sum > 2.5f)
        {
            comic_time_sum = 0;
            comic_step++;
        }
        if (comic_step != comic_step_tmp)
        {
            comic_step_tmp = comic_step;
            switch (static_parameters.Comic_scene_sort)
            {
                case 0:
                    comic_image();
                    break;
            }
        }
    }

    private void comic_image()
    {
        switch (comic_step)
        {
            case 1:

                break;
        }
    }
}

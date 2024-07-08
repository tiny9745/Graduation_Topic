using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood_col : MonoBehaviour
{
    private RectTransform HPimg_White, HPimg_Red, HPimg_Green;
    float blood_base = 1;
    float blood_tmp = 1000;
    // Start is called before the first frame update
    void Start()
    {
        FindHPImage();
    }

    // Update is called once per frame
    public void Update()
    {
        if (static_parameters.MC_HP_tmp != static_parameters.MC_HP){
           MC_HP();
        }
        if (static_parameters.MC_HP_Max_tmp != static_parameters.MC_HP_Max) {
            print("blood_base return");
            blood_base = blood_tmp / static_parameters.MC_HP_Max;
            static_parameters.MC_HP_Max_tmp = static_parameters.MC_HP_Max;
        }
        MC_HP_effects();
    }
    public void FindHPImage(){
    // Find all "Image" in the scene
        RectTransform[] foundRectTransforms = FindObjectsOfType<RectTransform>();
        foreach (RectTransform rectTransform in foundRectTransforms){
        // Check whether the name of the RectTransform component is the specified name"
        if (rectTransform.name == "HP_BG"){
            HPimg_White = rectTransform;
        }
        if (rectTransform.name == "HP_change"){
            HPimg_Red = rectTransform;
        }
        if (rectTransform.name == "HP_change_after"){
            HPimg_Green = rectTransform;
            break;
        }
        }
        blood_base = blood_tmp / static_parameters.MC_HP_Max;
        print(blood_tmp + "/" + static_parameters.MC_HP_Max + "->blood_tmp = "+blood_base);
        if (HPimg_White != null && HPimg_Red != null && HPimg_Green != null){
            HPimg_White.sizeDelta = new Vector2(static_parameters.MC_HP_Max*blood_base, HPimg_White.sizeDelta.y);
            HPimg_Red.sizeDelta = new Vector2(static_parameters.MC_HP * blood_base, HPimg_White.sizeDelta.y);
            HPimg_Green.sizeDelta = new Vector2(static_parameters.MC_HP * blood_base, HPimg_White.sizeDelta.y);
        }
    }

    //Determined to be attacked
    public void MC_HP(){
        static_parameters.MC_HP_tmp = static_parameters.MC_HP;
        if (HPimg_Green != null){
            HPimg_Green.sizeDelta = new Vector2(static_parameters.MC_HP * blood_base, HPimg_Green.sizeDelta.y);
            //print("HPimg_White: " + HPimg_White.sizeDelta.x + " HPimg_Red: " + HPimg_Red.sizeDelta.x + " HPimg_Green: " + HPimg_Green.sizeDelta.x);
        }
    }
    
    public void MC_HP_effects(){
        if (HPimg_Red != null && HPimg_Green != null && HPimg_Red.sizeDelta.x > HPimg_Green.sizeDelta.x){
            float baseSpeed = 6f;
            // The difference between the current health bar and the damage bar
            float difference = HPimg_Red.sizeDelta.x - HPimg_Green.sizeDelta.x;
            // Adjust speed according to difference
            float speed = baseSpeed + (difference * 0.1f);
            HPimg_Red.sizeDelta -= new Vector2(1, 0) * Time.deltaTime * speed;
            if (HPimg_Red.sizeDelta.x < HPimg_Green.sizeDelta.x){
                HPimg_Red.sizeDelta = new Vector2(HPimg_Green.sizeDelta.x, HPimg_Red.sizeDelta.y);
            }
        }
    }
}

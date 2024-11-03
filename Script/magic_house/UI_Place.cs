using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Place : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Upgrade;
    bool isUpgrade,P1 = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)&&P1){
            UI1();
            isUpgrade = !isUpgrade;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            P1 = true;        
        }
    }
    void UI1(){
        if(isUpgrade){
            Upgrade.SetActive(true);
        }else{
            Upgrade.SetActive(false);
        }
    }
}

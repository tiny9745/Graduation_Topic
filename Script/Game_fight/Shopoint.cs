using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Upgrade;
    bool P1 = false;
    short price;
    int spawn;
    void Start()
    {
        spawn=Random.Range(0,100);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)&&P1){
            Buy();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            P1 = true;        
        }
    }
    void Buy(){
        if(price <= static_parameters.money){
            return;
        }else{
            itemlist(spawn);
        }
    }
    void itemlist(int num){
        switch(num){
            case 0:
                price=100;
                static_parameters.money-=price;

                break;
        }
    }

}

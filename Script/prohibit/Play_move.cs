using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_move : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float dashSpeed, walkSpeed; public bool DashCD = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            horizontalInput = Input.GetAxis("Horizontal") * 0.1f;
            verticalInput = Input.GetAxis("Vertical") * 0.1f;
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
        walkSpeed = static_parameters.MC_Wspeed;
        dashSpeed = walkSpeed * 3;
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        if (movement.magnitude > 1){
            movement.Normalize();
        }
        if (!DashCD){
            movement = movement * walkSpeed * Time.deltaTime;
        }else{
            movement = movement * dashSpeed * Time.deltaTime;
        }
        
        transform.position += movement;

        if (movement != Vector3.zero)
        {

            if (horizontalInput > 0 && verticalInput > 0){
                static_parameters.face = 2;//fr              
            }
            else if (horizontalInput < 0 && verticalInput > 0){
                static_parameters.face = 4;//fl
            }
            else if (horizontalInput < 0 && verticalInput < 0){
                static_parameters.face = 6;//bl
            }
            else if (horizontalInput > 0 && verticalInput < 0){
                static_parameters.face = 8;//br
            }else{
                if (horizontalInput > 0){
                    static_parameters.face = 1;//r               
                }
                if (verticalInput > 0){
                    static_parameters.face = 3;//f                
                }
                if (horizontalInput < 0){
                    static_parameters.face = 5;//l           
                }
                if (verticalInput < 0){
                    static_parameters.face = 7;//b
                }
            }
        }else{
            static_parameters.face = 0;
        }

        if (Input.GetKeyDown(KeyCode.L)){
            DashCD = true;
            static_parameters.invincible = true;
            Invoke("DogeCooldown", 0.3f);
        }
    }
    void DogeCooldown()
    {
        static_parameters.invincible = false;
        DashCD = false;
    }
}

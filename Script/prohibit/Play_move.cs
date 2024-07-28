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

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        walkSpeed = static_parameters.MC_Wspeed;
        dashSpeed = walkSpeed * 3;
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        print(horizontalInput);print(verticalInput);

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
        if(!DashCD){
        movement = movement * walkSpeed * Time.deltaTime;
        }else{
        movement = movement * dashSpeed * Time.deltaTime;
        }
        transform.position += movement;

        if (movement != Vector3.zero)
        {
            if (movement.x > 0)
            {
                static_parameters.face = 1;
            }
            else if (movement.x < 0)
            {
                static_parameters.face = 2;
            }
            else if (movement.z > 0)
            {
                static_parameters.face = 3;
            }
            else if (movement.z < 0)
            {
                static_parameters.face = 4;
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            DashCD = true;
            static_parameters.invincible = true;
            Invoke("DogeCooldown", 0.2f);
        }
    }
    void DogeCooldown()
    {
        static_parameters.invincible = false;
        DashCD = false;
    }
}

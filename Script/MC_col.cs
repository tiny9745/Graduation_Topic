using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_col : MonoBehaviour
{
    public GameObject MC;
    void Start()
    {
        MC = GameObject.Find("Player");
        Renderer renderer = MC.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }
    void Update()
    {
        // Get player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Convert movement direction to world space
        movement = transform.TransformDirection(movement);

        // Move character
        transform.position += movement * static_parameters.MC_Wspeed * Time.deltaTime;
    }
    //Determined to be attacked
    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("NPC"))
        {
            if (static_parameters.MC_HP <= 0)
            {
                static_parameters.MC_HP = 0;
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.LogWarning("找不到對應組件");
        }
        //The attack is determined based on the tag detection of the weapon category
        //Meet customs clearance conditions
    }
}

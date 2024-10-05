using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Play_move : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float dashSpeed, walkSpeed; public bool DashCD = false;

    private Vector3 targetPosition; bool navMeshAvailable;
    public NavMeshAgent agent; public float navMeshCheckRadius = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //MC range limiter in the RandomTileGround.cs
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            horizontalInput = Input.GetAxis("Horizontal") * 0.1f;
            verticalInput = Input.GetAxis("Vertical") * 0.1f;
            if (navMeshAvailable) MC_Nav_Baking_range(horizontalInput, verticalInput);
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            if (navMeshAvailable) MC_Nav_Baking_range(horizontalInput, verticalInput);
        }
        walkSpeed = static_parameters.MC_Wspeed;
        dashSpeed = walkSpeed * 3;
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
        if (!DashCD)
        {
            movement = movement * walkSpeed * Time.deltaTime;
        }
        else
        {
            movement = movement * dashSpeed * Time.deltaTime;
        }

        transform.position += movement;

        if (movement != Vector3.zero)
        {

            if (horizontalInput > 0 && verticalInput > 0)
            {
                static_parameters.face = 2;//fr              
            }
            else if (horizontalInput < 0 && verticalInput > 0)
            {
                static_parameters.face = 4;//fl
            }
            else if (horizontalInput < 0 && verticalInput < 0)
            {
                static_parameters.face = 6;//bl
            }
            else if (horizontalInput > 0 && verticalInput < 0)
            {
                static_parameters.face = 8;//br
            }
            else
            {
                if (horizontalInput > 0)
                {
                    static_parameters.face = 1;//r               
                }
                if (verticalInput > 0)
                {
                    static_parameters.face = 3;//f                
                }
                if (horizontalInput < 0)
                {
                    static_parameters.face = 5;//l           
                }
                if (verticalInput < 0)
                {
                    static_parameters.face = 7;//b
                }
            }
        }
        else
        {
            static_parameters.face = 0;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
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

    void MC_Nav_Baking_range(float h, float v)
    {
        // agent = GameObject.Find("NavMesh Surface").GetComponent<NavMeshAgent>();
        Vector3 direction = new Vector3(h, 0, v).normalized;
        if (direction.magnitude >= 0.1f)
        {
            targetPosition = transform.position + direction * static_parameters.MC_Wspeed * Time.deltaTime;
            if (IsPositionOnNavMesh(targetPosition))
            {
                agent.Move(direction * static_parameters.MC_Wspeed * Time.deltaTime);
            }
        }
    }
    bool IsPositionOnNavMesh(Vector3 position)
    {
        NavMeshHit hit;
        // 檢查指定位置附近是否有有效的 NavMesh 區域
        bool isOnNavMesh = NavMesh.SamplePosition(position, out hit, navMeshCheckRadius, NavMesh.AllAreas);
        return isOnNavMesh;
    }

    bool NavMeshHasBakedData()
    {
        // 檢查場景中是否有已經被 baking 的 NavMesh 資料
        NavMeshData[] navMeshData = FindObjectsOfType<NavMeshData>();
        return navMeshData != null && navMeshData.Length > 0;
    }
}

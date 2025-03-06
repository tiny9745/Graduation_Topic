using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Play_move : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float dashSpeed, walkSpeed = 1;
    public bool DashCD = false;
    private Vector3 targetPosition;
    private bool navMeshAvailable;
    public NavMeshAgent agent;
    public float navMeshCheckRadius = 1.0f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 newPosition = rb.position; // Get current position
        if (static_parameters.MC_HP > 0 && Death_MC.isDead && static_parameters.isTeaching == false && static_parameters.teaching_stop >= 0)
        {
            // 讀取輸入
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            walkSpeed = static_parameters.MC_Wspeed;
            dashSpeed = walkSpeed * 3;

            // 檢查 NavMesh 是否有 Baking 資料
            navMeshAvailable = NavMeshHasBakedData();

            // 更新 NavMesh 範圍內的移動
            if (navMeshAvailable) MC_Nav_Baking_range(horizontalInput, verticalInput);
            
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

            if (movement.magnitude > 1)
            {
                movement.Normalize();
            }
            if (DashCD)
            {
                newPosition += movement * dashSpeed * Time.fixedDeltaTime; // Dash speed
            }
            else if (static_parameters.Ani_state >= 2)
            {
                newPosition += movement * 0.2f * Time.fixedDeltaTime; // Slow movement
            }
            else
            {
                newPosition += movement * walkSpeed * Time.fixedDeltaTime; // Walk speed
            }
            // 更新角色朝向
            UpdateFaceDirection(movement);
            // 監聽衝刺鍵
            if (Input.GetKeyDown(KeyCode.L) && !DashCD && Ani_MC.isDashCooldown_for_move == false && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && static_parameters.isTeaching == false && static_parameters.teaching_stop >= 0)
            {
                Ani_MC.isDashCooldown_for_move = true;
                DashCD = true;
                static_parameters.invincible = true;
                Invoke("DogeCooldown", 0.6f); // 衝刺冷卻時間
            }
        }
        rb.MovePosition(newPosition); // Apply movement
    }

    void DogeCooldown()
    {
        static_parameters.invincible = false;
        DashCD = false;
    }

    void MC_Nav_Baking_range(float h, float v)
    {
        Vector3 direction = new Vector3(h, 0, v).normalized;
        if (direction.magnitude >= 0.1f)
        {
            targetPosition = transform.position + direction * static_parameters.MC_Wspeed * Time.deltaTime;
            targetPosition.z += 10f; // 假設偏移

            if (IsPositionOnNavMesh(targetPosition) && agent.enabled)
            {
                agent.Move(direction * static_parameters.MC_Wspeed * Time.deltaTime);
            }
        }
    }

    bool IsPositionOnNavMesh(Vector3 position)
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(position, out hit, navMeshCheckRadius, NavMesh.AllAreas);
    }

    bool NavMeshHasBakedData()
    {
        NavMeshData[] navMeshData = FindObjectsOfType<NavMeshData>();
        return navMeshData != null && navMeshData.Length > 0;
    }

    void UpdateFaceDirection(Vector3 movement)
    {
        if (movement != Vector3.zero)
        {
            if (horizontalInput > 0 && verticalInput > 0)
            {
                static_parameters.face = 2; // fr
            }
            else if (horizontalInput < 0 && verticalInput > 0)
            {
                static_parameters.face = 4; // fl
            }
            else if (horizontalInput < 0 && verticalInput < 0)
            {
                static_parameters.face = 6; // bl
            }
            else if (horizontalInput > 0 && verticalInput < 0)
            {
                static_parameters.face = 8; // br
            }
            else
            {
                if (horizontalInput > 0)
                {
                    static_parameters.face = 1; // r
                }
                if (verticalInput > 0)
                {
                    static_parameters.face = 3; // f
                }
                if (horizontalInput < 0)
                {
                    static_parameters.face = 5; // l
                }
                if (verticalInput < 0)
                {
                    static_parameters.face = 7; // b
                }
            }
        }
        else
        {
            static_parameters.face = 0; // idle
        }
    }
}

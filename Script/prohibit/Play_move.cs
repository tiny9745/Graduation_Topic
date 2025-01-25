using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Play_move : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float dashSpeed, walkSpeed=1;
    public bool DashCD = false;

    private Vector3 targetPosition;
    private bool navMeshAvailable;
    public NavMeshAgent agent;
    public float navMeshCheckRadius = 1.0f;

    public Transform Player; public Rigidbody rb;

    void Start()
    {
        // Initialization if needed
        Player.transform.position = new Vector3(0, 2, 0);
    }
    
    void Update()
    {
        rb.MovePosition(transform.position);
        // 檢查是否可以移動 (生命大於 0 且角色未死亡)
        if (static_parameters.MC_HP > 0 && Death_MC.isDead)
        {
            // 讀取輸入
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            // 計算行走速度與衝刺速度
            walkSpeed = static_parameters.MC_Wspeed;
            dashSpeed = walkSpeed * 3;

            // 檢查 NavMesh 是否有 Baking 資料
            navMeshAvailable = NavMeshHasBakedData();

            // 更新 NavMesh 範圍內的移動
            if (navMeshAvailable)
            {
                MC_Nav_Baking_range(horizontalInput, verticalInput);
            }

            // 計算移動向量
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

            if (movement.magnitude > 1)
            {
                movement.Normalize();
            }

            // 根據 DashCD 狀態決定速度
            if (DashCD)
            {
                transform.position += movement * dashSpeed * Time.deltaTime; // 衝刺速度
            }
            else if(static_parameters.Ani_state>=2||static_parameters.Ani_state<=4)
            {
                transform.position += movement * 0.5f * Time.deltaTime;
            }else{
                transform.position += movement * walkSpeed * Time.deltaTime; // 行走速度
            }

            // 更新角色朝向
            UpdateFaceDirection(movement);
            // if(Ani_MC.isDashCooldown_for_move)Debug.Log("isDashCooldown_for_move");
            // 監聽衝刺鍵
            if (Input.GetKeyDown(KeyCode.L) && !DashCD && Ani_MC.isDashCooldown_for_move == false && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
            {
                Ani_MC.isDashCooldown_for_move = true;
                Debug.Log("Dash");
                DashCD = true;
                static_parameters.invincible = true;
                Invoke("DogeCooldown", 0.67f); // 衝刺冷卻時間
            }
        }
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

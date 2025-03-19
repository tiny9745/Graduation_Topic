
using UnityEngine;
using UnityEngine.AI;

public class Play_move : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float dashSpeed, walkSpeed = 1;
    private bool navMeshAvailable;
    public NavMeshAgent agent; private Vector3 targetPosition;
    public float navMeshCheckRadius = 1.0f;
    Rigidbody rb; Vector3 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent.updatePosition = false;
    }

    void FixedUpdate()
    {
        Vector3 newPosition = rb.position; // Get current position
        if (static_parameters.MC_HP > 0 && Death_MC.isDead && static_parameters.isTeaching == false && static_parameters.teaching_stop >= 0 && static_parameters.Bookstate == false)
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

            movement = new Vector3(horizontalInput, 0f, verticalInput);

            if (movement.magnitude > 1)
            {
                movement.Normalize();
            }
            if (Ani_MC.isDashCooldown_for_move)
            {
                newPosition += movement * dashSpeed * Time.fixedDeltaTime; // Dash speed
            }
            else if (Ani_MC.isAttackPlaying)
            {
                newPosition += movement * 0.2f * Time.fixedDeltaTime; // Slow movement
            }
            else
            {
                newPosition += movement * walkSpeed * Time.fixedDeltaTime; // Walk speed
            }
            // 更新角色朝向
            UpdateFaceDirection(movement);
        }
        if (movement.magnitude > 0) rb.MovePosition(newPosition);// Apply movement        
    }

    void MC_Nav_Baking_range(float h, float v)
    {
        Vector3 direction = new Vector3(h, 0, v).normalized;
    }

    bool IsPositionOnNavMesh(Vector3 position)
    {
        if (!GetComponent<NavMeshAgent>().enabled) return false;
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

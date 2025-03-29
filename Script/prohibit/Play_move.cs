
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
        Vector3 newPosition = rb.position; // 取得當前位置

        if (static_parameters.MC_HP > 0 && Death_MC.isDead && static_parameters.isTeaching == false &&
            static_parameters.teaching_stop >= 0 && static_parameters.Bookstate == false &&
            static_parameters.MC_NPC_col_move == true)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            walkSpeed = static_parameters.MC_Wspeed;
            dashSpeed = walkSpeed * 3;

            navMeshAvailable = NavMeshHasBakedData();

            if (navMeshAvailable) MC_Nav_Baking_range(horizontalInput, verticalInput);

            movement = new Vector3(horizontalInput, 0f, verticalInput);

            if (movement.magnitude > 1) movement.Normalize();

            if (Ani_MC.isDashCooldown_for_move)
            {
                newPosition += movement * dashSpeed * Time.fixedDeltaTime;
            }
            else if (Ani_MC.isAttackPlaying)
            {
                newPosition += movement * 0.2f * Time.fixedDeltaTime;
            }
            else
            {
                newPosition += movement * walkSpeed * Time.fixedDeltaTime;
            }

            // **確保角色回到最後有效位置**
            if (!IsPositionOnNavMesh(newPosition))
            {
                Debug.Log("嘗試移動到無效區域，將位置設為 lastValidPosition");
                newPosition = lastValidPosition; // 強制回到安全區域
            }

            UpdateFaceDirection(movement);
        }

        if (movement.magnitude > 0) rb.MovePosition(newPosition);
    }

    Vector3 lastValidPosition; // 記錄最後合法的 NavMesh 位置

    void MC_Nav_Baking_range(float h, float v)
    {
        Vector3 direction = new Vector3(h, 0, v).normalized;
        if (direction.magnitude >= 0.1f)
        {
            targetPosition = transform.position + direction * static_parameters.MC_Wspeed * Time.deltaTime;

            if (IsPositionOnNavMesh(targetPosition))
            {
                lastValidPosition = targetPosition; // 更新最後有效的位置
            }
            else
            {
                Debug.Log("目標位置不在 NavMesh 上，取消移動");
                targetPosition = lastValidPosition; // 回到最後有效的位置
            }
        }
    }
    bool IsPositionOnNavMesh(Vector3 position)
    {
        if (!agent.enabled) return false; // 若 NavMeshAgent 未啟用，直接返回 false

        NavMeshHit hit;
        bool isValid = NavMesh.SamplePosition(position, out hit, navMeshCheckRadius, NavMesh.AllAreas);

        return isValid; // 回傳 true (在 NavMesh 上) 或 false (超出範圍)
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

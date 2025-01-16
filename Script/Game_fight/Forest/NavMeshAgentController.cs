using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentController : MonoBehaviour
{
    public string dangerTag = "Thorns"; // 區域的 Tag
    public float retreatDistance = 5f; // 移動距離
    public float boundaryCheckDistance = 0.5f; // 邊界檢查距離
    private bool isInDangerZone = false; // 是否在危險區域內
    private Vector3 currentDirection; // 當前移動方向
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing on " + gameObject.name);
        }

        // 初始化方向
        currentDirection = Vector3.forward; // 初始方向為前方
    }

    private void OnTriggerStay(Collider other)
    {
        // 如果進入危險區域且標記匹配
        if (other.CompareTag(dangerTag))
        {
            if (!isInDangerZone)
            {
                isInDangerZone = true;
                Debug.Log($"{gameObject.name} entered a danger zone: {other.name}");
            }

            // 計算新的目標位置
            Vector3 retreatTarget = transform.position + (currentDirection.normalized * retreatDistance);

            // 設置 NavMeshAgent 的目標位置
            if (agent != null)
            {
                agent.SetDestination(retreatTarget);
                Debug.Log($"{gameObject.name} is moving to {retreatTarget}");
            }

            // 檢查是否碰到邊界
            if (Physics.Raycast(transform.position, currentDirection, boundaryCheckDistance))
            {
                Debug.Log($"{gameObject.name} hit a boundary, changing direction.");
                RotateDirectionBy90Degrees();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 當離開危險區域時，重置狀態
        if (other.CompareTag(dangerTag))
        {
            isInDangerZone = false;
            Debug.Log($"{gameObject.name} exited the danger zone: {other.name}");
        }
    }

    private void RotateDirectionBy90Degrees()
    {
        // 計算新的方向，順時針旋轉 90 度
        currentDirection = new Vector3(currentDirection.z, 0, -currentDirection.x);
        Debug.Log($"New direction: {currentDirection}");
    }
}

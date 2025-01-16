using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentController : MonoBehaviour
{
    private NavMeshAgent agent;
    float speed;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing on " + gameObject.name);
        }
        speed = agent.speed;
    }

    public void LeaveDangerZone(Vector3 dangerZonePosition, Vector3 escapeDirection, float pushForce)
    {
        if (agent == null) return;

        Vector3 escapeTarget = transform.position + (escapeDirection.normalized * pushForce);

        if (NavMesh.SamplePosition(escapeTarget, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
            agent.speed = speed * 1.5f; // 加速逃離
            Debug.Log($"{gameObject.name} is leaving danger zone to {hit.position}!");
        }
        else
        {
            agent.speed = speed;
            Debug.LogWarning($"{gameObject.name} could not find a valid escape point!");
        }
    }
}

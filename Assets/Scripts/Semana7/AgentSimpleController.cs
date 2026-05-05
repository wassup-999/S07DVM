using UnityEngine;
using UnityEngine.AI;
public class AgentSimpleController : MonoBehaviour
{
    public Transform Target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (Target == null)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                Target = playerObject.transform;
            }
           
        }
    }

    void Update()
    {
        OnDrawGizmos();
        if (agent != null && Target != null)
        {
            agent.SetDestination(Target.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (Target != null)
        {
            Vector3 dir = Target.position - transform.position;
            Gizmos.DrawRay(transform.position, dir);
        }
    }
}
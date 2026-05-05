using UnityEngine;
using UnityEngine.AI;
public class AgentSimpleController : MonoBehaviour
{
    public Transform Target;
    private NavMeshAgent agent;
    public int life = 100;

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
       
        if (life <= 0)
        {
            Destroy(gameObject);
            return;
        }

        if (agent != null && Target != null)
        {
            agent.SetDestination(Target.position);
        }
    }

   
}
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public int damage = 100;

    void OnCollisionEnter(Collision collision)
    {
        var agent = collision.gameObject.GetComponent<AgentSimpleController>();
        if (agent == null)
            agent = collision.gameObject.GetComponentInParent<AgentSimpleController>();

        if (agent != null)
        {
            agent.life -= damage;
            Destroy(gameObject);
        }
    }
}
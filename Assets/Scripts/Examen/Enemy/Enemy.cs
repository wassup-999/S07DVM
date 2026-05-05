using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [FoldoutGroup("References")]
    public PlayeMechanics player;
    [FoldoutGroup("References")]
    public NavMeshAgent agent;

    [FoldoutGroup("Attack Settings")]
    public float Damage;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayeMechanics>();
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        FollowPlayer();
        MakeDamage();
    }

    public void FollowPlayer()
    {
        if (!agent.hasPath)
        {
            Debug.Log("No path to follow");
        }
        if (player != null)
        {
            agent.SetDestination(player.transform.position);
        }
    }
    public void MakeDamage()
    {
        if (player == null) return;
        if(Vector3.Distance(player.transform.position, transform.position)<= agent.stoppingDistance)
        {
            player.MakeDamage(10);
            GameManager.Instance.enemySpawner.CurrentEnemies--;
            Destroy(gameObject);
        }
    }
}

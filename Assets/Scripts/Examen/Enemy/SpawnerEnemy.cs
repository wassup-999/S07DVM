using Sirenix.OdinInspector;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [FoldoutGroup("References")]
    public GameObject Enemyprefab;
    [FoldoutGroup("Spawner Settings")]
    public float SpawnInterval = 3f;
    [FoldoutGroup("Spawner Settings")]
    public float SpawnCounter;

    [FoldoutGroup("Counter Settings")]
    public int MaxEnemies = 10;
    [FoldoutGroup("Counter Settings")]
    public int CurrentEnemies;
    void Start()
    {
        
    }

    
    void Update()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        SpawnCounter += Time.deltaTime;
        if (SpawnCounter >= SpawnInterval)
        {
            GameObject EnemyPref = Instantiate(Enemyprefab , transform.position , Quaternion.identity);
            CurrentEnemies++;
            SpawnCounter = 0f;
        }
        EnemyCounterMethod();
    }
    public void EnemyCounterMethod()
    {
        for (int i = 0; i < CurrentEnemies; i++)
        {
            if (CurrentEnemies >= MaxEnemies)
            {
                Debug.Log("Max Enemies Reached");
                SpawnCounter *= 0f;
            }
            else
            {
                SpawnCounter *= 1f;
            }

        }
    }
}

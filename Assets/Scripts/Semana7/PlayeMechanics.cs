using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class PlayeMechanics : MonoBehaviour , IRecieveDamage
{
    [FoldoutGroup("Life Settings")]
    public float Life;
    
    [FoldoutGroup("References")]
    public GameObject TurretPrefab;
    [FoldoutGroup("References")]
    public Transform SpawnRef;
    [FoldoutGroup("CoolDown Settings")]
    public float CurrentCDSpawn;
    [FoldoutGroup("CoolDown Settings")]
    public float TurretSpawnInterval;
    public bool CanSpawnTurret = true;
    
    void Start()
    {
        
    }

    
    void Update()
    {       
    }
    
    public void SpawnTurret()
    {
        if (CanSpawnTurret)
        {
            GameObject Turret = Instantiate(TurretPrefab, SpawnRef.transform.position, Quaternion.identity);
            CanSpawnTurret = false;
            StartCoroutine(CDSpawnTurret());
        }       
    }


    public IEnumerator CDSpawnTurret()
    {
        CurrentCDSpawn = 0;
        while (CurrentCDSpawn <= TurretSpawnInterval) 
        { 
            CurrentCDSpawn += Time.deltaTime;
            yield return null;        
        }
        CanSpawnTurret = true;
        yield break;
    }
    
    public void MakeDamage(float damage)
    {
        damage = GameManager.Instance.enemy.Damage;
        Life -=damage;
        Debug.Log("Player hit");
    }
}

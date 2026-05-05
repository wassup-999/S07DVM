using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class PlayeMechanics : MonoBehaviour
{
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
}

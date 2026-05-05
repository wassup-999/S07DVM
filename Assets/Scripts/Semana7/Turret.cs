using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [FoldoutGroup("References")]
    public GameObject HeadTurret;
    [FoldoutGroup("References")]
    public GameObject Currentenemy;
    [FoldoutGroup("References")]
    public Transform SpawnbulletRef;
    [FoldoutGroup("References")]
    public GameObject BulletPrefab;


    [FoldoutGroup("Rotation Settings")]
    public float rotationSpeed;

    [FoldoutGroup("Shoot Settings")]
    public float ShootForce;

    [FoldoutGroup("CDShoot")]
    public float ShootTimer;
    [FoldoutGroup("CDShoot")]
    public float SpawnInterval;
    public List<Enemy> enemys;
    void Start()
    {
       
        Currentenemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    
    void Update()
    {
        Rotate();
        ShootMechanic();
    }
    public void Rotate()
    {
        if (Currentenemy == null)
        {
            Quaternion targetQuaternion = Quaternion.identity;
            HeadTurret.transform.rotation = Quaternion.Slerp(HeadTurret.transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);

        }
        if (Currentenemy != null)
        {           
            Vector3 Head = (Currentenemy.transform.position - transform.position).normalized;
            Quaternion targetQuaternion = Quaternion.LookRotation(Head);
            HeadTurret.transform.rotation = Quaternion.Slerp(HeadTurret.transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);
          
        }       
    }

    public void FindEnemy()
    {
        if(Currentenemy == null && enemys.Count >0)
        {
            Enemy nearestEnemy = enemys[0];

            Vector3 pos = transform.position;

            foreach(Enemy enemy in enemys)
            {


                if(Vector3.Distance(pos,enemy.transform.position) < Vector3.Distance(pos, nearestEnemy.transform.position))
                {
                    nearestEnemy = enemy;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemys.Add(other.gameObject.GetComponent<Enemy>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemys.Remove(other.gameObject.GetComponent<Enemy>());
        }
    }
    public void ShootMechanic()
    {
        ShootTimer += Time.deltaTime;
        if(ShootTimer >= SpawnInterval)
        {
            GameObject bullet = Instantiate(BulletPrefab, SpawnbulletRef.transform.position, Quaternion.identity);
            SpawnInterval = 0;
        }


        
        //Vector3 dir = bullet.transform.forward;
        //bullet.GetComponent<Rigidbody>().AddForce(dir * ShootForce, ForceMode.Impulse);
    }
}

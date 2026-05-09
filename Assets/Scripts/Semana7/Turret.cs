using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject headTurret;
    public Transform FirePointRight;
    public Transform FirePointLeft;
    public float rotationSpeed;
    public float BulletSpeed = 20f;

    private float fireRate = 1f;
    private float nextFireTime = 0f;
    private bool useRightFirePoint = true;

    public ParticleSystem ShootParticlesLeft;
    public ParticleSystem ShootParticlesRight;

    private Transform currentTarget;

    void Start()
    {
        
        SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 40f;
    }

    void Update()
    {
        if (currentTarget != null)
        {
            Detection();
            Shoot();
        }
    }

    public void Detection()
    {
        if (currentTarget == null) return;

        Vector3 HeadDir = (currentTarget.position - transform.position);
        Quaternion targetQuaternion = Quaternion.LookRotation(HeadDir);
        headTurret.transform.rotation = Quaternion.Slerp(headTurret.transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);
    }

    public void Shoot()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            Transform currentFirePoint = useRightFirePoint ? FirePointRight : FirePointLeft;
            ParticleSystem currentParticles = useRightFirePoint ? ShootParticlesRight : ShootParticlesLeft;
            useRightFirePoint = !useRightFirePoint;

            Debug.Log("Torreta Dispara");
            currentParticles.Play();
            if (Physics.Raycast(currentFirePoint.position, currentFirePoint.forward, out RaycastHit hit, 100f))
            {
                var hitObj = hit.collider.gameObject;
                var agent = hitObj.GetComponent<AgentSimpleController>();
                if (agent == null)
                    agent = hitObj.GetComponentInParent<AgentSimpleController>();

                if (agent != null)
                {
                    agent.life -= 100; 
                  
                }
            }
            GameObject bullet = Instantiate(BulletPrefab, currentFirePoint.position, currentFirePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
           

            if (rb != null)
            {
                rb.linearVelocity = currentFirePoint.forward * BulletSpeed;
            }
            Destroy(bullet, 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            AgentSimpleController agent = other.GetComponent<AgentSimpleController>();
            if (agent != null)
            {
                currentTarget = other.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Enemy") && other.transform == currentTarget)
        {
            currentTarget = null;
        }
    }
}
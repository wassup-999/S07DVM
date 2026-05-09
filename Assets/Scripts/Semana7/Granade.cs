using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class Granade : MonoBehaviour
{
    public float timer;
    public float radius;
    public UnityEvent OnExplotion;
    public ParticleSystem explosionParticles;

    private SphereCollider sphereCollider;

    void Start()
    {
        
        sphereCollider = gameObject.AddComponent<SphereCollider>();
        sphereCollider.isTrigger = true; 
        sphereCollider.radius = radius;

        
        Invoke(nameof(OnExplode), timer);
    }

    private void OnExplode()
    {
       
        Collider[] colls = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider coll in colls)
        {
            var hitObj = coll.gameObject;
            var agent = hitObj.GetComponent<AgentSimpleController>();
            if (agent == null)
                agent = hitObj.GetComponentInParent<AgentSimpleController>();

            
            if (agent != null)
            {
                agent.life -= 100;
            }
        }

        
        if (explosionParticles != null)
        {
            ParticleSystem particles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
            particles.Play();
            
        }

        
        OnExplotion.Invoke();

       
        Destroy(gameObject);
    }
}

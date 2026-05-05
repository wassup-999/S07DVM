using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class Granade : MonoBehaviour
{
    public float timer;
    public float radius;
    public LayerMask mask;
    public UnityEvent OnExplotion;
    void Start()
    {
        Invoke(nameof(OnExplode),timer);
    }

    private void OnExplode()
    {
       Collider[] colls =  Physics.OverlapSphere(transform.position, radius, mask);
        foreach (Collider coll in colls)
        {
            //-> mueran todos
        }
        OnExplotion.Invoke();

        Destroy(gameObject);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

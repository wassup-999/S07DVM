using UnityEngine;
using UnityEngine.Events;

public class Granade : MonoBehaviour
{
    public float timer;
    public float radius;
    public LayerMask mask;
    public UnityEvent OnExplotion;
    void Start()
    {
        Invoke(nameof(OnExplote), timer);
    }

    
    void Update()
    {
        
    }
    public void OnExplote()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, radius , mask);
        foreach(var coll in colls)
        {

        }
        OnExplotion?.Invoke();
        Destroy(gameObject);
    }
}

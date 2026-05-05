using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject HeadTurret;
    public GameObject Enemy;
    public float rotationSpeed;
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    
    void Update()
    {
        Rotate();
    }
    public void Rotate()
    {
        Vector3 Head = (Enemy.transform.position - transform.position).normalized;
        Quaternion targetQuaternion = Quaternion.LookRotation(Head);
        HeadTurret.transform.rotation = Quaternion.Slerp(HeadTurret.transform.rotation,targetQuaternion,rotationSpeed * Time.deltaTime);
    }
}

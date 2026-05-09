using UnityEngine;

public class Bullet : MonoBehaviour , IAttackDamage
{
    public float BulletDamage;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void MakeDamage(float damage)
    {
        BulletDamage = damage;
    }

}

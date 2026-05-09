using UnityEngine;

public class TurretBullet : MonoBehaviour 
{
    public float BulletDamage;
    public Enemy enemy;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {  
        Enemy enemyLife = collision.gameObject.GetComponent<Enemy>();
        if (enemyLife != null) 
        {
            enemyLife.RecieveDamage(20);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject,3);
        }
        /*
        if (collision.gameObject.name == "Enemy")
        {            
            Debug.Log("Collition");
            enemy.RecieveDamage(20);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 3);
        }
        */
    }
}

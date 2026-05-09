using UnityEngine;

public class TurretBullet : MonoBehaviour 
{
    public float BulletDamage;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        //collision.gameObject.CompareTag("Enemy")
        if (enemy !=null)
        {            
            Debug.Log("Collition");
            GameManager.Instance.enemy.RecieveDamage(20);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 3);
        }
    }
}

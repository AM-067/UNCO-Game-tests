using UnityEngine;

public class CS_Enemyt1 : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] Transform target;
    
    private int _maxHealth = 100;

    private int _currentHealth;

    public int Damage;
    
    [SerializeField] private Health healthBar;
    
    private void Start()
    {
        _currentHealth = _maxHealth;
        healthBar.SetMaxHealth(_maxHealth);
    }

    void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        healthBar.SetHealth(_currentHealth);
        
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Target not found!");
        }
        
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Debug.Log("GAME OVER");
        }
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(Damage);
            Debug.Log("hit");
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Enemy down");
    }
    
}

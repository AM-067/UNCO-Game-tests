using UnityEngine;

public class CS_Enemyt2 : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float followDistance = 15f; 
    [SerializeField] private Transform target;

    private bool _isFollowing = false;
    
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
            if (Vector3.Distance(transform.position, target.position) <= followDistance)
            {
                _isFollowing = true;
            }
        
            if (_isFollowing)
            {
                transform.LookAt(target);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
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
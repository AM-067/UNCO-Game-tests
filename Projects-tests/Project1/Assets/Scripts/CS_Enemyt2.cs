using UnityEngine;

public class CS_Enemyt2 : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float followDistance = 15f; 
    [SerializeField] private Transform target;

    private bool _isFollowing = false;
    
    public int MaxHealth = 100;

    public int CurrentHealth;
    
    public int Damage;
    public PlayerHealth HealthBar;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
    }
    
    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        HealthBar.SetHealth(CurrentHealth);
    }
    
    void Update()
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
        
        if (CurrentHealth <= 0)
        {
            Die();
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
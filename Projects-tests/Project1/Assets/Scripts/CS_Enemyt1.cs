using UnityEngine;

public class CS_Enemyt1 : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] Transform target;
    
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

        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
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
    
    private void FixedUpdate()
    {
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Enemy down");
    }
    
}

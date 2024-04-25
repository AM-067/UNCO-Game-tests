using UnityEngine;

public class Player : MonoBehaviour
{

    public int MaxHealth = 100;

    public int CurrentHealth;

    public PlayerHealth HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
        
        
        Cursor.lockState = CursorLockMode.Locked;
        
     
        Cursor.visible = false;
    }
    
    
    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        HealthBar.SetHealth(CurrentHealth);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            TakeDamage(20);
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
        Debug.Log("GAME OVER");
    }
}

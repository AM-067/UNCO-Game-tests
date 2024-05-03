using UnityEngine;

public class Player : MonoBehaviour
{

    private int _maxHealth = 100;

    private int _currentHealth;

    [SerializeField] private Health healthBar;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        healthBar.SetMaxHealth(_maxHealth);
        
        
        Cursor.lockState = CursorLockMode.Locked;
        
     
        Cursor.visible = false;
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
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            TakeDamage(20);
        }
    }
    

    void Die()
    {
        Destroy(gameObject);
        GameManager.InstanceGameManager.PlayerIsDead = true;
        GameManager.InstanceGameManager.GameOver();
        Debug.Log("GAME OVER");
    }
}

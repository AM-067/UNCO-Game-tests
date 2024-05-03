using UnityEngine;
using System.Collections;

public class CS_Enemyt2 : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float followDistance = 15f;
    [SerializeField] private Transform target;
    [SerializeField] private Renderer enemyRenderer; 
    [SerializeField] private Material defaultMaterial; 
    [SerializeField] private  Material followingMaterial; 

    private bool _isFollowing = false;

    private int _maxHealth = 100;
    private int _currentHealth;

    public int Damage;
    
    [SerializeField] private Health healthBar;

    private void Start()
    {
        _currentHealth = _maxHealth;
        healthBar.SetMaxHealth(_maxHealth);
        enemyRenderer.material = defaultMaterial;
    }

    void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        healthBar.SetHealth(_currentHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(FlashRed());
        }
    }

    private IEnumerator FlashRed()
    {
       
        Material currentMaterial = enemyRenderer.material;

        enemyRenderer.material.color = Color.red;
        
        yield return new WaitForSeconds(0.1f);
        
        enemyRenderer.material = currentMaterial;
    }

    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) <= followDistance)
            {
                _isFollowing = true;
                enemyRenderer.material = followingMaterial;
            }

            if (_isFollowing)
            {
                transform.LookAt(target);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                enemyRenderer.material = defaultMaterial;
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
            GameManager.InstanceGameManager.PlayerIsDead = true;
            GameManager.InstanceGameManager.GameOver();
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
        GameManager.InstanceGameManager.PlayerScore += 20;
        GameManager.InstanceGameManager.Victory();
        Debug.Log("Enemy down");
    }
}

using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] private Rigidbody projectilePrefab;
    public Transform LaunchPoint;
    public float ShootForce = 1000f;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        Rigidbody rb = Instantiate(projectilePrefab, LaunchPoint.position, LaunchPoint.rotation);
        
        
        if (rb != null)
        {
            rb.AddForce(LaunchPoint.up * ShootForce);
            Destroy(rb.gameObject,5f);
        }
        else
        {
            Debug.LogError("Rigidbody component not found!");
        }
    }
}
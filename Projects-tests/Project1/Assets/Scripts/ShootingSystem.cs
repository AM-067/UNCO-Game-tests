using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject ProjectilePrefab;
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
        
        GameObject projecTile = Instantiate(ProjectilePrefab, LaunchPoint.position, LaunchPoint.rotation);
        
      
       
        Rigidbody rb = projecTile.GetComponent<Rigidbody>();
        
        
        if (rb != null)
        {
          
            rb.AddForce(LaunchPoint.up * ShootForce);
            Destroy(projecTile,5f);
        }
        else
        {
            Debug.LogError("Rigidbody component not found!");
        }
    }
}
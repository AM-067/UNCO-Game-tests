using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public Transform launchPoint;
    public float bulletSpeed;
    public ObjectPooler objectPooler;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !objectPooler.WillGrow)
        {
            Shoot();
        }
        if (Input.GetMouseButton(0) && objectPooler.WillGrow)
        {
            Shoot();
           
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            objectPooler.WillGrow = !objectPooler.WillGrow;
        }
    }

    private void Shoot()
    {
        GameObject bullet = objectPooler.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = launchPoint.position;
            bullet.transform.rotation = launchPoint.rotation;
            bullet.SetActive(true);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = launchPoint.up * bulletSpeed;
            }
            else
            {
                Debug.LogWarning("Rigidbody component not found on bullet object.");
            }
        }
        else
        {
            Debug.LogWarning("Failed to get bullet from the object pool.");
        }
    }
}
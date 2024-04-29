using System;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    
    

    public Transform LunchPoint;
    public float BulletSpeed;


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shoot();
        }
    }

    private void shoot()
    {
        GameObject obj = ObjectPooler.current.GetPooledObject();
        if (obj == null)
        {
            Debug.Log("not shoot");
            return;
        }

        obj.transform.position = LunchPoint.position;
        obj.transform.rotation = LunchPoint.rotation;
        obj.SetActive(true);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(LunchPoint.up * BulletSpeed);
        Debug.Log("shoot");
    }
}
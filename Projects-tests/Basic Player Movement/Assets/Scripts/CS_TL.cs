using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_TL : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] Transform target;
    // Update is called once per frame
    void Update()
    {
        // Vector3 lookAtPosition = new Vector3(target.position.x,0f, transform.position.z);
            
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        
    }
}

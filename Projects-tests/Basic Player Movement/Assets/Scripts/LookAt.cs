using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] Transform target;

    // Update is called once per frame
    private void Update()
    {
        if (target != null)
        {
            Vector3 lookAtPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
            
            transform.LookAt(target);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{

    public Transform Cam;
    
    void LateUpdate()
    {
        if (Cam != null)
        {
            transform.LookAt(transform.position + Cam.forward); 
        }
        else
        {
            Debug.Log("Cam Not Found!");
        }
        
    }
}

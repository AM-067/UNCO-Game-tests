using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{

    public Transform Cam;
    
    void LateUpdate()
    {
        transform.LookAt(transform.position + Cam.forward);
    }
}

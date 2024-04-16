using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        Vector3 translation = Vector3.up * Time.deltaTime;
        transform.Translate(translation);
    }
}

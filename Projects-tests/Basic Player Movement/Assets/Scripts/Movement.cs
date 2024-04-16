using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Vector3 inputVector;

    // Update is called once per frame
    private void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
        transform.Translate(inputVector * speed * Time.deltaTime);
    }
}

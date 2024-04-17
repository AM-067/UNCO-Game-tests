using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   [SerializeField] private float forwardspeed = 3f;
   [SerializeField] private float speed = 10f;
   
       // private Vector3 inputVector;
       [SerializeField] private Rigidbody player;
   
       // Update is called once per frame
       private void Update()
       {
           // inputVector = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
           if (Input.GetKey(KeyCode.A))
           {
               player.AddForce(new Vector3(-speed,0f,0f) * Time.deltaTime,ForceMode.VelocityChange);
           }
           if (Input.GetKey(KeyCode.D))
           {
               player.AddForce(new Vector3(speed,0f,0f) * Time.deltaTime,ForceMode.VelocityChange);
           }
          
           player.AddForce(new Vector3(0f,0f,forwardspeed) * Time.deltaTime,ForceMode.VelocityChange);
       }
}

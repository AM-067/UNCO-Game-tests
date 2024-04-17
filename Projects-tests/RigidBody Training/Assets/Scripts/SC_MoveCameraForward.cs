using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MoveCameraForward : MonoBehaviour
{
    public Transform ball; // Reference to the ball GameObject

    // Update is called once per frame
    void Update()
    {
        if (ball != null)
        {
            // Get the current position of the ball
            Vector3 ballPos = ball.position;

            // Keep the same y position as the ball, but offset the camera in z
            Vector3 newPos = new Vector3(ballPos.x, transform.position.y, ballPos.z - 7f);

            // Set the new position of the camera
            transform.position = newPos;
        }
    }
}


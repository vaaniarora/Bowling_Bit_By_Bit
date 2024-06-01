using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    // The original position where the object should respawn
    private Vector3 originalPosition;

    public float gutterY = -0.03f;
    public float foulLine = -13.30f;

    public PinRespawner pinRespawner; // Reference to the PinRespawner script

    void Start()
    {
        // Store the original position of the GameObject
        originalPosition = transform.position;
    }

    void Update()
    {
        // Get rigid body component so that we can check velocity to see if it stops in the lane and needs to respawn
        Rigidbody rb = GetComponent<Rigidbody>();
        if ((transform.position.y < gutterY) 
        || ((rb.velocity == Vector3.zero && rb.angularVelocity == Vector3.zero) && (transform.position.x > foulLine)))
        {
            RespawnObject();

            // Check if pinRespawner is not null before calling OnBallRespawned
            if (pinRespawner != null)
            {
                pinRespawner.OnBallRespawned(this); // Notify pin respawner when ball has respawned
            }
            else
            {
                Debug.LogWarning("PinRespawner reference is not set in BallRespawn script.");
            }
        }
    }

    void RespawnObject()
    {
        // Set the object's position to the original position
        transform.position = originalPosition;

        // Optionally reset other properties like velocity if the object has a Rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void ThrowBall()
    {
        // Your ball throwing logic here

        // Check if pinRespawner is not null before calling OnBowlingBallThrown
        if (pinRespawner != null)
        {
            pinRespawner.OnBowlingBallThrown();
        }
        else
        {
            Debug.LogWarning("PinRespawner reference is not set in BallRespawn script.");
        }
    }
}
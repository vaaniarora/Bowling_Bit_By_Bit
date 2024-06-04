using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    // The original position where the object should respawn
    private Vector3 originalPosition;
    public double gutterY = -0.03;
    public double foulLine = -13.30;

    void Start()
    {
        // Store the original position of the GameObject
        originalPosition = transform.position;
    }

    void Update()
    {
        // get rigid body component so that we can check velocity so that if it stops in the lane it will respawn (only if past the foulLine)
        // if there is a dip in the Y axis, that means that it has gone into the gutter or past the pins so it will respawn 

        Rigidbody rb = GetComponent<Rigidbody>();
        if ((transform.position.y < gutterY) 
        | ((rb.velocity == Vector3.zero && rb.angularVelocity == Vector3.zero) && (transform.position.x > foulLine)))
        {
            RespawnObject();
                    
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

}

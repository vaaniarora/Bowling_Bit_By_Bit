using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // The original position where the object should respawn
    private Vector3 originalPosition;

    // The threshold position on the y-axis (or any axis you prefer) 
    // beyond which the object will respawn
    public double thresholdXend = 2.1;
    public double thresholdXback = -17;
    public double thresholdZleft = -17.7;
    public double thresholdZright = -21.8;
    public double gutterXLeft = 1.64;
    public double gutterZLeft = -18.18;
    public double gutterXRight = 1.68;
    public double gutterZRight = -19.42;


    void Start()
    {
        // Store the original position of the GameObject
        originalPosition = transform.position;
    }

    void Update()
    {
        // Check if the object's position is below the threshold
        // This defines the y-coordinate threshold.
        // If the GameObject's y-coordinate goes below this value, it will respawn.
        // and condition for end of gutter (left and right)

        if ((transform.position.x > thresholdXend) | (transform.position.x < thresholdXback) 
            | (transform.position.z > thresholdZleft) | (transform.position.z < thresholdZright) )
            // | (transform.position.x > gutterXLeft) | (transform.position.x < gutterXRight) 
            // | (transform.position.z > gutterZLeft) | (transform.position.z < gutterZRight) )
        {
            RespawnObject();
        }

        // condition for ball stopped in the middle of the lane 

        // Rigidbody rb = GetComponent<Rigidbody>();
        // if (rb.velocity == Vector3.zero && rb.angularVelocity == Vector3.zero) {
        //     RespawnObject();
        // }
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

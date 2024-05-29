using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // The original position where the object should respawn
    private Vector3 originalPosition;

    public double gutterY = -0.03;

    public double foulLine = -13.3;


    void Start()
    {
        // Store the original position of the GameObject
        originalPosition = transform.position;
    }

    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if ((rb.velocity == Vector3.zero && rb.angularVelocity == Vector3.zero && transform.position.x > foulLine) 
            | (transform.position.y < gutterY)) 
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

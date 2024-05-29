using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    public bool isKnockedDown { get; private set; } = false; // Make this property public with a private setter
    private Quaternion initialRotation;
    private Vector3 initialPosition;
    private float knockdownAngleThreshold = 45.0f; // Angle threshold to consider the pin knocked down
    private float knockdownPositionThreshold = 0.1f; // Position threshold to consider the pin knocked down

    void Start()
    {
        // Store the initial rotation and position of the pin
        initialRotation = transform.rotation;
        initialPosition = transform.position;
    }

    void Update()
    {
        if (!isKnockedDown)
        {
            // Calculate the angle between the pin's up direction and the world's up direction
            float angle = Quaternion.Angle(transform.rotation, initialRotation);

            // Check if the pin is significantly rotated or moved
            if (angle > knockdownAngleThreshold || Mathf.Abs(transform.position.y - initialPosition.y) > knockdownPositionThreshold)
            {
                isKnockedDown = true;
                BowlingGameManager.Instance.PinKnockedDown();
                Debug.Log("Pin knocked down: " + gameObject.name);
            }
        }
    }
}

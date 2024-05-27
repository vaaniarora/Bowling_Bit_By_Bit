using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public class pin_script : MonoBehaviour
{
    private bool isKnockedDown = false;
    private Quaternion initialRotation;
    private Vector3 initialPosition;
    private float knockdownThreshold = 45.0f; // Threshold for considering the pin as knocked down

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
            if (angle > knockdownThreshold || Vector3.Distance(transform.position, initialPosition) > 0.2f)
            {
                isKnockedDown = true;
                BowlingGameManager.Instance.PinKnockedDown();
            }
        }
    }
}*/

public class PinScript : MonoBehaviour
{
    private bool isKnockedDown = false;
    private Quaternion initialRotation;
    private Vector3 initialPosition;
    private float knockdownAngleThreshold = 90.0f; // Angle threshold to consider the pin knocked down
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimHelper : MonoBehaviour
{
    public List<Transform> pins;
    public Transform ball;
    public float knockdownThreshold = 0.5f; // Threshold to consider the pin as knocked down
    public Transform fixedPosition; // Fixed position on the bowling lane

    void Start()
    {
        if (fixedPosition == null)
        {
            Debug.LogError("Fixed position is not set in AimHelper.");
        }

        if (ball == null)
        {
            Debug.LogWarning("Ball reference is not set in AimHelper during Start.");
        }
        else
        {
            Debug.Log("Ball reference set in AimHelper during Start: " + ball.name);
        }

        // Set the initial position to the fixed position
        transform.position = fixedPosition.position;
    }

    void Update()
    {
        if (ball == null)
        {
            Debug.LogWarning("Ball reference is not set in AimHelper during Update.");
            return;
        }

        // Update the position to the fixed position
        transform.position = fixedPosition.position;

        // The rotation is handled by BowlingGameManager, so we don't need to adjust it here
    }
}

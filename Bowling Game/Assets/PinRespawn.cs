using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinRespawner : MonoBehaviour
{
    private Vector3 originalPosition;

    public int maxAttempts = 2;
    private int currentAttempts = 0;
    private HashSet<BallRespawn> ballsToRespawn = new HashSet<BallRespawn>();

    void Start()
    {
        // Store the original position of the GameObject
        originalPosition = transform.position;
    }

    public void OnBowlingBallThrown()
    {
        currentAttempts++;

        if (currentAttempts >= maxAttempts)
        {
            // RespawnPins();
            // currentAttempts = 0;
            ballsToRespawn.Clear();

        }
    }

    public void OnBallRespawned(BallRespawn ball)
    {
        // do not want to respawn immediately: 
        // respawn after ball has been thrown (x2) and reached end of lane/gutter 
        // wait a few seconds so that they can see their score, 
        // then respawn 

        ballsToRespawn.Add(ball);

        // Check if all balls have respawned
        if (ballsToRespawn.Count >= FindObjectsOfType<BallRespawn>().Length)
        {
            StartCoroutine(RespawnPinsWithDelay(3f)); // Adjust the delay as needed
            currentAttempts = 0;
        }

    }

    IEnumerator RespawnPinsWithDelay(float delay) 
    {
        // Wait for the delay period
        yield return new WaitForSeconds(delay);
        // Respawn the pins
        RespawnPins();
    }


    void RespawnPins()
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

        // Reactivate the pin if it was deactivated (optional)
        gameObject.SetActive(true);
    }
}




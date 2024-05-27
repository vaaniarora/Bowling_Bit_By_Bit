using System.Collections;
using UnityEngine;

public class MoveGuards : MonoBehaviour
{
    private bool isMovingUp = false;
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private float moveDuration = 0.5f; // Duration of the move

    private void Start()
    {
        // Store the original position of the object
        originalPosition = transform.position;
        // Calculate the target position for moving up
        targetPosition = originalPosition - Vector3.up * 0.3f;
    }

    public void Move()
    {
        StopAllCoroutines(); // Stop any ongoing movement
        if (isMovingUp)
        {
            // If already moving up, move down
            StartCoroutine(MoveObject(originalPosition));
        }
        else
        {
            // If not moving up, move up
            StartCoroutine(MoveObject(targetPosition));
        }
        isMovingUp = !isMovingUp;
    }

    private IEnumerator MoveObject(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Ensure the final position is set
    }
}
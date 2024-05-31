using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static int totalGrabCount = 0; // Static counter to track grabs across all balls

    public static void IncrementGrabCount()
    {
        totalGrabCount++;
    }

    public static bool CanPlaySound()
    {
        return totalGrabCount < 2;
    }
}

using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BowlingGameManager : MonoBehaviour
{
    public static BowlingGameManager Instance { get; private set; }

    public int totalPins = 10;
    private int knockedDownPins = 0;
    public TextMeshProUGUI scoreboardText;
    public GameObject aimHelperPrefab; // Prefab for the aim helper
    private GameObject aimHelperInstance;
    public List<Transform> pins; // List of pin transforms
    public Transform activeBall; // Reference to the active bowling ball
    public List<Transform> balls; // List of all bowling balls
    public Transform fixedPosition; // Fixed position for the AimHelper on the bowling lane
    private float middleZ = -18.8f; // Middle Z position between left and right most pins
    private float leftMostZ = -18.54f; // Z position of the left-most pin
    private float rightMostZ = -19.078f; // Z position of the right-most pin
    private float maxAngle = 6f; // Maximum angle for rotation

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreboard();
    }

    public void PinKnockedDown()
    {
        knockedDownPins++;
        UpdateScoreboard();
    }

    void UpdateScoreboard()
    {
        int remainingPins = totalPins - knockedDownPins;
        scoreboardText.text = "Knocked Down: " + knockedDownPins + "\nRemaining: " + remainingPins;
    }

    public void SetActiveBall(Transform newActiveBall)
    {
        if (activeBall != newActiveBall) // Only update if it's a new active ball
        {
            activeBall = newActiveBall;
            Debug.Log("SetActiveBall called. New active ball: " + activeBall.name);

            if (aimHelperInstance != null)
            {
                Destroy(aimHelperInstance);
            }

            InstantiateAimHelper();
        }
    }

    void InstantiateAimHelper()
    {
        if (activeBall != null)
        {
            // Calculate the average Z position of the standing pins
            float averageZ = GetAverageZPositionOfRemainingPins();
            Debug.Log($"Calculated average Z position: {averageZ}");

            // Map the average Z position to the angle range [-10, 10]
            float angle = MapZPositionToAngle(averageZ);
            Debug.Log($"Mapped angle: {angle}");

            // Create the final rotation with the adjusted Y rotation
            Quaternion finalRotation = Quaternion.Euler(0, angle, -90);

            // Instantiate the AimHelper with the calculated rotation
            aimHelperInstance = Instantiate(aimHelperPrefab, fixedPosition.position, finalRotation);
            AimHelper aimHelperScript = aimHelperInstance.GetComponent<AimHelper>();
            aimHelperScript.pins = pins;
            aimHelperScript.ball = activeBall;
            aimHelperScript.fixedPosition = fixedPosition;

            Debug.Log($"AimHelper instantiated. Ball reference set to: {aimHelperScript.ball.name}, Rotation: {finalRotation.eulerAngles}");
        }
    }

    float GetAverageZPositionOfRemainingPins()
    {
        float totalZ = 0f;
        int count = 0;

        Debug.Log("Calculating average Z position of remaining pins...");

        foreach (Transform pin in pins)
        {
            PinScript pinScript = pin.GetComponent<PinScript>();
            if (pinScript != null && !pinScript.isKnockedDown) // Check if the pin is still standing
            {
                totalZ += pin.position.z;
                Debug.Log($"Added pin Z position: {pin.position.z}");
                count++;
            }
        }

        return count > 0 ? totalZ / count : middleZ; // Return middleZ if no pins are standing
    }

    float MapZPositionToAngle(float zPosition)
    {
        // Calculate the difference from the middle Z position
        float difference = zPosition - middleZ;
        float angle;

        if (difference < 0)
        {
            // Position is to the right of the middle
            angle = (difference / (rightMostZ - middleZ)) * maxAngle;
        }
        else
        {
            // Position is to the left of the middle
            angle = (difference / (middleZ - leftMostZ)) * maxAngle;
        }

        // Clamp the angle to the range [-maxAngle, maxAngle]
        return Mathf.Clamp(angle, -maxAngle, maxAngle);
    }

    public void ShowAimHelper(bool show)
    {
        if (aimHelperInstance != null)
        {
            aimHelperInstance.SetActive(show);
        }
    }

    public void DestroyAimHelper()
    {
        if (aimHelperInstance != null)
        {
            Destroy(aimHelperInstance);
            aimHelperInstance = null;
        }
    }
}

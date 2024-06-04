using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DirectionalArrow : MonoBehaviour
{
    public GameObject leftArrowIndicator;
    public GameObject rightArrowIndicator; 
    private XRGrabInteractable grabInteractable; // The XR Grab Interactable component

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Hide the arrow indicator at the start
        leftArrowIndicator.SetActive(false);
        rightArrowIndicator.SetActive(false);


        // Subscribe to the grab events
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        grabInteractable.onSelectExited.AddListener(OnReleased);
    }

    void Update()
    {
        if (grabInteractable.isSelected)
        {
            // Update the arrow direction based on the player's hand direction
            UpdateArrowDirection();
        }
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        // Show the arrow indicator when the ball is grabbed
        if (interactor.name.Contains("Left"))
        {
            leftArrowIndicator.SetActive(true);
        }
        else if (interactor.name.Contains("Right"))
        {
            rightArrowIndicator.SetActive(true);
        }
    }

    private void OnReleased(XRBaseInteractor interactor)
    {
        // Hide the arrow indicator when the ball is released
        leftArrowIndicator.SetActive(false);
        rightArrowIndicator.SetActive(false);

    }

    private void UpdateArrowDirection()
    {
        if (grabInteractable.selectingInteractor != null)
        {
            // Get the forward direction of the player's hand
            Vector3 handForward = -grabInteractable.selectingInteractor.transform.forward;

            // Project the hand's forward direction onto the horizontal plane (XZ plane)
            Vector3 horizontalDirection = new Vector3(handForward.x, 0, handForward.z).normalized;

            if (horizontalDirection != Vector3.zero)
            {
                // Calculate the new rotation based on the horizontal direction
                // Quaternion targetRotation = Quaternion.LookRotation(horizontalDirection);

                // Set the arrow's rotation to the new rotation with fixed X and Z rotations
                // float yAngle = targetRotation.eulerAngles.y - 168.566f;
                float yAngle = Vector3.SignedAngle(Vector3.forward, horizontalDirection, Vector3.up);
                float absAngle = Mathf.Abs(yAngle);
                if (grabInteractable.selectingInteractor.name.Contains("Left"))
                {
                    leftArrowIndicator.transform.rotation = Quaternion.Euler(0, yAngle - 183, 0);
                }
                else if (grabInteractable.selectingInteractor.name.Contains("Right"))
                {
                    // rightArrowIndicator.transform.rotation = Quaternion.Euler(0, yAngle - 165.566f, 0);
                    rightArrowIndicator.transform.rotation = Quaternion.Euler(0, yAngle - 183, 0);
                }
            }
        }
    }
}
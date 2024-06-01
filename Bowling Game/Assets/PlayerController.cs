using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionAsset inputActions; // Reference to the input actions asset
    public AudioSource audioSource1; // AudioSource component for sound1
    public AudioSource audioSource2; // AudioSource component for sound2

    private InputAction primaryAction;
    private InputAction secondaryAction;

    void Awake()
    {
        if (inputActions == null)
        {
            Debug.LogError("Input Actions asset is not assigned.");
            return;
        }

        // Find and initialize the action map and actions
        var playerActionMap = inputActions.FindActionMap("Controller");
        if (playerActionMap == null)
        {
            Debug.LogError("Controller action map not found.");
            return;
        }

        primaryAction = playerActionMap.FindAction("Primary Button");
        secondaryAction = playerActionMap.FindAction("Secondary Button");

        if (primaryAction == null)
        {
            Debug.LogError("Primary Button action not found.");
            return;
        }

        if (secondaryAction == null)
        {
            Debug.LogError("Secondary Button action not found.");
            return;
        }

        // Register callbacks
        primaryAction.performed += OnPrimaryAction;
        secondaryAction.performed += OnSecondaryAction;

        // Enable the action map
        playerActionMap.Enable();
    }

    private void OnDestroy()
    {
        // Clean up the callbacks when the object is destroyed
        if (primaryAction != null)
        {
            primaryAction.performed -= OnPrimaryAction;
        }

        if (secondaryAction != null)
        {
            secondaryAction.performed -= OnSecondaryAction;
        }
    }

    private void OnPrimaryAction(InputAction.CallbackContext context)
    {
        if (audioSource1 != null)
        {
            audioSource1.Play();
        }
        else
        {
            Debug.LogError("AudioSource1 is not assigned.");
        }
    }

    private void OnSecondaryAction(InputAction.CallbackContext context)
    {
        if (audioSource2 != null)
        {
            audioSource2.Play();
        }
        else
        {
            Debug.LogError("AudioSource2 is not assigned.");
        }
    }
}

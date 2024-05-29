using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerClickInstruction : MonoBehaviour
{
    public InputActionReference primaryButtonAction; // Reference to the default primary button action
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Enable the primary button action
        primaryButtonAction.action.Enable();

        // Subscribe to the performed event of the primary button action
        primaryButtonAction.action.performed += OnPrimaryButtonClicked;
    }

    void OnDestroy()
    {
        // Disable and unsubscribe from the primary button action
        primaryButtonAction.action.Disable();
        primaryButtonAction.action.performed -= OnPrimaryButtonClicked;
    }

    private void OnPrimaryButtonClicked(InputAction.CallbackContext context)
    {
        // Check if the audio source is not already playing
        if (!audioSource.isPlaying)
        {
            // Play the audio
            audioSource.Play();
        }
    }
}

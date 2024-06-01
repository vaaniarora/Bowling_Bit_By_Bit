using UnityEngine;
using UnityEngine.InputSystem;

public class SecondaryClickInstruction : MonoBehaviour
{
    public InputActionReference secondaryButtonAction; // Reference to the default primary button action
    public AudioSource audioSource;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();

        // Enable the primary button action
        secondaryButtonAction.action.Enable();

        // Subscribe to the performed event of the primary button action
        secondaryButtonAction.action.performed += OnSecondaryButtonClicked;
    }

    void OnDestroy()
    {
        // Disable and unsubscribe from the primary button action
        secondaryButtonAction.action.Disable();
        secondaryButtonAction.action.performed -= OnSecondaryButtonClicked;
    }

    private void OnSecondaryButtonClicked(InputAction.CallbackContext context)
    {
        // Check if the audio source is not already playing
        if (!audioSource.isPlaying)
        {
            // Play the audio
            audioSource.Play();
        }
    }
}

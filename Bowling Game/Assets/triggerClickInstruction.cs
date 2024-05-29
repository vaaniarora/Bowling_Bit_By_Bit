using UnityEngine;
using UnityEngine.InputSystem;

public class triggerClickInstruction : MonoBehaviour
{
    public InputActionReference buttonClickAction; // Reference to the ButtonClick Action
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        buttonClickAction.action.Enable(); // Ensure the action is enabled
        buttonClickAction.action.performed += OnButtonClick;
    }

    void OnDestroy()
    {
        buttonClickAction.action.performed -= OnButtonClick;
    }

    private void OnButtonClick(InputAction.CallbackContext context)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}

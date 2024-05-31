using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InstructorFeedback : MonoBehaviour
{
    public AudioClip audioClip; // Assign this in the Inspector
    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;
    private bool hasPlayed = false;

    void Awake()
    {
        // Add AudioSource component and assign the AudioClip
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;

        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Ensure XRGrabInteractable component is present
    }

    void OnEnable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
            grabInteractable.selectExited.AddListener(OnReleased);
        }
    }

    void OnDisable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
            grabInteractable.selectExited.RemoveListener(OnReleased);
        }
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        // Check if the audio has already played for this ball and if the global grab count is less than 2
        if (!hasPlayed && BallManager.CanPlaySound())
        {
            audioSource.Play();
            hasPlayed = true;
            BallManager.IncrementGrabCount();
        }
    }

    void OnReleased(SelectExitEventArgs args)
    {
        // If the ball is released, stop the audio
        audioSource.Stop();
        hasPlayed = false; // Reset flag for next grab
    }
}

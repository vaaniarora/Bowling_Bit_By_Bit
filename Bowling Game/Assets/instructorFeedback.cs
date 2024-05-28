using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InstructorFeedback : MonoBehaviour
{
    public AudioClip audioClip; // Assign this in the Inspector
    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        // Add AudioSource component and assign the AudioClip
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;

        // Ensure AudioClip is assigned
        if (audioSource.clip == null)
        {
            Debug.LogError("AudioClip is not assigned to AudioSource.");
        }

        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Ensure XRGrabInteractable component is present
        if (grabInteractable == null)
        {
            Debug.LogError("XRGrabInteractable component is missing.");
        }
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
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void OnReleased(SelectExitEventArgs args)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}

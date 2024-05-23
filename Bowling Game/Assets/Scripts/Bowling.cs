using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bowling : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody ballRigidbody;
    private bool isGrabbed = false;
    private Vector3 lastPosition;

    public delegate void GrabbedAction();
    public delegate void ReleasedAction();
    public static event GrabbedAction OnGrabbed;
    public static event ReleasedAction OnReleased;


    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        // grabInteractable.onSelectEntered.AddListener(OnGrab);
        // grabInteractable.onSelectExited.AddListener(OnRelease);
        ballRigidbody = GetComponent<Rigidbody>();
    }

    void OnGrab(XRBaseInteractor interactor)
    {
        if (!isGrabbed)
        {
            isGrabbed = true;
            Debug.Log("Grabbed");
            if (OnGrabbed != null)
                OnGrabbed();
        }
    }

    void OnRelease(XRBaseInteractor interactor)
    {
        if (isGrabbed)
        {
            isGrabbed = false;
            Debug.Log("Released");
            if (OnReleased != null)
                OnReleased();

            // Calculate velocity based on controller movement
            Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;

            // Apply velocity to the ball's Rigidbody
            ballRigidbody.velocity = velocity;

            // Reset last position
            lastPosition = transform.position;
        }
    }

    void Update()
    {
        // Update last position for velocity calculation
        lastPosition = transform.position;
    }

    
}




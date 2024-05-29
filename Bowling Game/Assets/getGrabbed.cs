using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class getGrabbed : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private bool grabbed = false;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        if (!grabbed)
        {
            Debug.Log("Grabbed: " + transform.name);
            BowlingGameManager.Instance.SetActiveBall(transform);
            BowlingGameManager.Instance.ShowAimHelper(true); // Show the AimHelper
            grabbed = true;
        }
    }

    void OnReleased(SelectExitEventArgs args)
    {
        if (grabbed)
        {
            Debug.Log("Released: " + transform.name);
            BowlingGameManager.Instance.ShowAimHelper(false); // Hide the AimHelper
            BowlingGameManager.Instance.DestroyAimHelper(); // Destroy the AimHelper instance
            grabbed = false;
        }
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }
}
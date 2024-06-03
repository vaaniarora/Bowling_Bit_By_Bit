using UnityEngine;
using UnityEngine.InputSystem;

public class GuardManager : MonoBehaviour
{
    public MoveGuards[] guards; // Array to hold references to all guard objects

    // Reference to the Input Action
    public InputAction moveGuttersAction;

    private void OnEnable()
    {
        // Enable the Input Action
        moveGuttersAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the Input Action
        moveGuttersAction.Disable();
    }

    private void Start()
    {
        // Subscribe to the Input Action's performed event
        moveGuttersAction.performed += ctx => MoveGutters();
    }

    private void MoveGutters()
    {
        foreach (MoveGuards guard in guards)
        {
            guard.Move();
        }
    }
}

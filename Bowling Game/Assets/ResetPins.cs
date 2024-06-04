using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetPins : MonoBehaviour
{
    public List<GameObject> pins;
    private Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>();
    private Dictionary<GameObject, Quaternion> originalRotations = new Dictionary<GameObject, Quaternion>();
    public InputAction resetPins;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var pin in pins)
        {
            originalPositions[pin] = pin.transform.position;
            originalRotations[pin] = pin.transform.rotation;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        resetPins.performed += ctx => RegeneratePins();
    }

    private void OnEnable()
    {
        // Enable the Input Action
        resetPins.Enable();
    }

    private void OnDisable()
    {
        // Disable the Input Action
        resetPins.Disable();
    }

    private void RegeneratePins()
    {
        foreach (var pin in pins)
        {
            pin.transform.position = originalPositions[pin];
            pin.transform.rotation = originalRotations[pin];
        }
    }
}

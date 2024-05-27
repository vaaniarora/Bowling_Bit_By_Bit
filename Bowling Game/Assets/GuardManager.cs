using UnityEngine;
using UnityEngine.UI;

public class GuardManager : MonoBehaviour
{
    public MoveGuards[] guards; // Array to hold references to all guard objects
    public Button moveButton; // Reference to the UI button

    private void Start()
    {
        if (moveButton != null)
        {
            moveButton.onClick.AddListener(OnMoveButtonClicked);
        }
    }

    private void OnMoveButtonClicked()
    {
        foreach (MoveGuards guard in guards)
        {
            guard.Move();
        }
    }
}

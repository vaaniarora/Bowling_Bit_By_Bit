using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BowlingGameManager : MonoBehaviour
{
    public static BowlingGameManager Instance { get; private set; }

    public int totalPins = 10;
    private int knockedDownPins = 0;
    public TextMeshProUGUI scoreboardText; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreboard();
    }

    public void PinKnockedDown()
    {
        knockedDownPins++;
        UpdateScoreboard();
    }

    void UpdateScoreboard()
    {
        int remainingPins = totalPins - knockedDownPins;
        scoreboardText.text = "Knocked Down: " + knockedDownPins + "\nRemaining: " + remainingPins;
    }
}


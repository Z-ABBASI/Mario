using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI pointsText;
    public static int coins = 0;
    public static int points = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        levelText.text = $"WORLD\n1-1";
    }

    // Update is called once per frame
    void Update()
    {
        // Timer Text
        int intTime = 400 - (int)Time.realtimeSinceStartup;
        string timeStr = $"Time\n{intTime}";
        timerText.text = timeStr;
        
        // Coins Text
        coinsText.text = $"\u00D7";
        if (coins < 10)
        {
            coinsText.text += $"0";
        }
        coinsText.text += $"{coins}";
        
        // Points Text
        pointsText.text = $"MARIO\n";
        if (points < 100000) {
            pointsText.text += $"0";
        }
        if (points < 10000) {
            pointsText.text += $"0";
        }
        if (points < 1000) {
            pointsText.text += $"0";
        }
        if (points < 100) {
            pointsText.text += $"0";
        }
        if (points < 10) {
            pointsText.text += $"0";
        }
        // if (points < 1) {
        //     pointsText.text += $"0";
        // }

        pointsText.text += $"{points}";
    }
}

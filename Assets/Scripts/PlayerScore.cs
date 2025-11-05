using UnityEngine;
using TMPro; 
public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreUI();  
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Coins: " + score;
        }
    }
}


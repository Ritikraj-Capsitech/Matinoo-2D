
using UnityEngine;
using TMPro; 
public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public TextMeshProUGUI healthText;

    void Start()
    {
        UpdateHealthUI();
    }

    public void totalHealth(int amount)
    {
        health -= amount;
        UpdateHealthUI();
    }
    public void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }
}


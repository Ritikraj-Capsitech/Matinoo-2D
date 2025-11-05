using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            PlayerScore playerScore = collision.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.AddScore(coinValue);
            }
            Destroy(gameObject);
        }
    }
}

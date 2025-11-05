using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompleted : MonoBehaviour
{
    public GameManager gameManager;

   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.CompareTag("GameCompleted"))
        {
            gameManager.GameCompleted();
        }
    }
}

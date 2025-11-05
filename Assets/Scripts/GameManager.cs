using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public int playerScore; 
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public bool isGameStarted = false;
    public PlayerMovement playerMovement;
    public GameObject gameCompletedScreen;
    public PlayerHealth playerHealth;


    void Start()
    {
        titleScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        isGameStarted = false;
    }

    public void StartGame()
    {
        playerMovement.rb.simulated = true;
        isGameStarted = true;
        titleScreen.SetActive(false);
        gameOverScreen.SetActive(false);     
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameStarted = false;
        titleScreen.SetActive(false);
        playerMovement.rb.simulated = false;
        playerHealth.health = 0;
        playerHealth.UpdateHealthUI();
    }

    public void GameCompleted()
    {
        gameCompletedScreen.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();

    }
}

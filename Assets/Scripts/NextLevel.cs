

using UnityEngine;
using UnityEngine.SceneManagement; 

public class NextLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
{
    if (collider.CompareTag("NextLevel"))
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
}




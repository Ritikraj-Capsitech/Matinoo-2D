using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1f;
    public GameManager gameManager;
    public float changeDirectionInterval = 2f;
    private float timer;
    private float randomSpeed;
    public Transform playerRespawnPoint;
    public PlayerHealth playerHealth;

    void Update()
    {
        if (!gameManager.isGameStarted)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= changeDirectionInterval)
            {
                PickNewDirection();
                timer = 0f;
            }
            rb.linearVelocity = new Vector2(randomSpeed, rb.linearVelocity.y);
        }

    }

    // private IEnumerator RespawnPlayer(GameObject player)
    // {

    //     player.SetActive(false);
    //     yield return new WaitForSeconds(1f);
    //     player.transform.position = playerRespawnPoint.position;
    //     player.SetActive(true);
    // }

    private IEnumerator RespawnPlayer(GameObject player)
    {
        if (player == null) yield break;

        player.SetActive(false);
        yield return new WaitForSeconds(1f);

        if (player != null)
        {
            player.transform.position = playerRespawnPoint.position;
            player.SetActive(true);
        }
    }

    void PickNewDirection()
    {
        randomSpeed = Random.Range(-speed, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            playerHealth.totalHealth(50);
            StartCoroutine(RespawnPlayer(collision.gameObject));


            if (playerHealth.health <= 0)
            {
                Destroy(collision.gameObject);
                gameManager.GameOver();
            }

        }
    }
}

using System.Collections;
using UnityEngine;

public class PassThroughLogic : MonoBehaviour
{
    private Collider2D cubeCollider;

    void Start()
    {
        cubeCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            StartCoroutine(AllowPlayerToPass());
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            
            cubeCollider.enabled = true;
        }
    }

    private IEnumerator AllowPlayerToPass()
    {
        cubeCollider.isTrigger = true;
        yield return new WaitForSeconds(1f);
        cubeCollider.isTrigger = false;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
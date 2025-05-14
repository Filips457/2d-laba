using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int StartHealth;

    private int health;


    private void Awake()
    {
        health = StartHealth;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

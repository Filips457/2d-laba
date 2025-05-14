using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int StartHealth;
    [SerializeField] private Image HealthBarImage;

    private int health;


    private void Awake()
    {
        health = StartHealth;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        HealthBarImage.fillAmount = (float)health / StartHealth;

        if (health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

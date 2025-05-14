using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private int Damage;
    [SerializeField] private Rigidbody2D rb;


    private void Awake()
    {
        rb.linearVelocity = Vector2.up * Speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            collision.transform.GetComponent<PlayerHealth>().TakeDamage(Damage);
        else
            collision.transform.GetComponent<Health>().TakeDamage(Damage);

        Destroy(gameObject);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private int Damage;
    [SerializeField] private Rigidbody2D rb;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            collision.transform.GetComponent<PlayerHealth>().TakeDamage(Damage);
        else
            collision.transform.GetComponent<Health>().TakeDamage(Damage);

        Destroy(gameObject);
    }


    public void MoveToTarget(Vector3 direction, float angle)
    {
        rb.linearVelocity = direction.normalized * Speed;
        
        transform.rotation = Quaternion.Euler(0, 0, angle + 180);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
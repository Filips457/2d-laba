using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Speed;

    private Vector3 clickPos;


    void Start()
    {
        clickPos = transform.position;
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }


    private void FixedUpdate()
    {
        rb.linearVelocity = (clickPos - transform.position) * Speed;
    }
}

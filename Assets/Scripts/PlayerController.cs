using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField] float jumpForce;
    [SerializeField] float deathForce;
    Rigidbody2D rb;
    Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.HasGameStarted())
        {
            Jump();
        }
    }

    public void StartGame()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPosition;
        rb.gravityScale = 1;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    void Dead()
    {
        Debug.Log("Dead");
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * deathForce);
        gameManager.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager.HasGameStarted())
        {
            if (collision.CompareTag("Pipe"))
            {
                Dead();
            }
            if (collision.CompareTag("Score"))
            {
                gameManager.PointScored();
            }
        }
    }
}

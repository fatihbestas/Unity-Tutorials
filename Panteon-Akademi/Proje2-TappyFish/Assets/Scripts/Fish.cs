using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;
    [SerializeField] Score score;
    bool touchedGround;
    [SerializeField] GameManager gameManager;
    [SerializeField] Sprite fishDied;
    SpriteRenderer sp;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // oyuncudan ilk input gelene kadar balığın düşmemesi için:
        rb.gravityScale = 0;

        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        FishRotation();
    }
    
    void Update()
    {
        FishSwim();
    }

    void FishSwim()
    {
        if(Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            if (GameManager.gameStarted == false)
            {
                rb.gravityScale = 4f;
                rb.velocity = new Vector2(rb.velocity.x, speed);
                gameManager.GameHasStarted();
            }
            else
            {
                // rb.velocity = Vector2.zero; // bu satırın bir işlevi yok bence.
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
        }
    }

    void FishRotation()
    {
        if(rb.velocity.y > 0)
        {
            if(angle <= maxAngle)
            {
                angle += 4;
            }
        }
        else if(rb.velocity.y < -1.2)
        {
            if(angle > minAngle)
            {
                angle -= 2;
            }
        }

        if(touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Obstacle"))
        {
            score.Scored();
        }
        else if(other.CompareTag("Column"))
        {
            gameManager.GameOver();
            RotateDown();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            gameManager.GameOver();
            RotateDown();
        }    
    }

    void RotateDown()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        animator.enabled = false;
    }
}

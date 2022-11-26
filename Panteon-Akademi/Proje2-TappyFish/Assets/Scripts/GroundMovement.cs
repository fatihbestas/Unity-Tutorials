using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float groundWidth;
    
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        groundWidth = box.size.x;
    }

    void Update()
    {
        if(GameManager.gameOver == false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        if(transform.position.x <= -(groundWidth * 1.5f))
        {
            transform.position = new Vector2(transform.position.x + 3 * groundWidth, transform.position.y);
        }
    }
}

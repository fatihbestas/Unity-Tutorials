using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    float positionForDestroy = -9f;
    void Start()
    {

    }

    void Update()
    {
        if(GameManager.gameOver == false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        if(transform.position.x <= positionForDestroy)
        {
            Destroy(gameObject);
            return;
        }
    }
}

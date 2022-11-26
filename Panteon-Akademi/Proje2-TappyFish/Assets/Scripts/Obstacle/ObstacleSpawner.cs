using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    float maxTime;
    float timer;
    [SerializeField] float maxY;
    [SerializeField] float minY;
    float randomY;

    void Start()
    {
        maxTime = 2f;
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= maxTime)
        {
            randomY = Random.Range(minY, maxY);
            InstantiateObstacle(randomY);

            maxTime = Random.Range(2f, 3.5f);
            timer = 0;
        }
    }

    public void InstantiateObstacle(float positionY)
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, positionY);
    }
}

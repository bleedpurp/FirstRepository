using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class characterMovement : MonoBehaviour
{
    public float speed = 2f;
    public LayerMask wallLayer;

    private Vector2 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == (Vector3)targetPosition)
        {
            targetPosition = GetRandomPosition();
        }
    }

    Vector2 GetRandomPosition()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        
            int dir = Random.Range(0, 4);

            if (dir == 0)
                x++;

            else if (dir == 1)
                x--;

            else if (dir == 2)
                y++;
            else if (dir == 3)
                y--;
            Vector2 newPosition = new Vector2(x, y);

           Collider2D hit = Physics2D.OverlapCircle(newPosition, 0.1f, wallLayer);
            if (hit)
            {
                return new Vector2(transform.position.x, transform.position.y);
            }
            

        return newPosition;
        

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPatrol : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] stops;
    [SerializeField] private float minDistance;

    private int nextStop = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        turnSprite();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, stops[nextStop].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, stops[nextStop].position) < minDistance)
        {
            nextStop++;
            if(nextStop >= stops.Length) 
            { 
                nextStop = 0;
            }
            turnSprite();
        }
    }

    private void turnSprite()
    {
        if (transform.position.x < stops[nextStop].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}

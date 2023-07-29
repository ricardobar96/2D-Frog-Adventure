using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] stops;
    [SerializeField] private float minDistance;

    private int randomNumber;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        randomNumber = Random.Range(0, stops.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        turnSprite();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, stops[randomNumber].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, stops[randomNumber].position) < minDistance) 
        {
            randomNumber = Random.Range(0, stops.Length);
            turnSprite();
        }
    }

    private void turnSprite() 
    { 
        if(transform.position.x < stops[randomNumber].position.x) 
        { 
            spriteRenderer.flipX = true;
        }
        else 
        {
            spriteRenderer.flipX = false;
        }
    }
}

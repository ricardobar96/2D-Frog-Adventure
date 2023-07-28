using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlantBullet : MonoBehaviour
{
    private float speed = 2;

    private float duration = 2;

    public bool left;

    private void Start()
    {
        Destroy(gameObject, duration);
    }

    private void Update()
    {
        if (left) 
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else 
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
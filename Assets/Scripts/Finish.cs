using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private AudioSource finishSfx;
    private void Start()
    {
        finishSfx = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player") 
        { 
            finishSfx.Play();
            //FinishLevel();
        }
    }

    private void FinishLevel() 
    { 
        finishSfx.Play(); 
    }
}

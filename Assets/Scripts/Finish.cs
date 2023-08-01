using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Invoke("FinishLevel", 0.7f);
        }
    }

    private void FinishLevel() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

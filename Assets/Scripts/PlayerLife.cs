using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private GameObject player;

    [SerializeField] private AudioSource deathSfx;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes")) 
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath() 
    {
        deathSfx.Play();
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (player.transform.position.y < -11f)
        {
            animator.Play("Player_Death");
            rb.bodyType = RigidbodyType2D.Static;
            Invoke("ResetLevel", 0.5f);
        }
    }
}

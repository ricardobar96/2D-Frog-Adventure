using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int strawberries = 0;
    public int highScore = 0;

    [SerializeField] private Text strawberriesCount;
    [SerializeField] private Text bestScore;
    [SerializeField] private AudioSource itemSfx;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        bestScore.text = ("Best Score: " + highScore + "/35");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry")) 
        {
            itemSfx.Play();
            Destroy(collision.gameObject);
            strawberries++;
            strawberriesCount.text = ("Food: " + strawberries);

            if(strawberries > highScore) 
            {
                PlayerPrefs.SetInt("highScore", strawberries);
                PlayerPrefs.Save();
                bestScore.text = ("Best Score: " + highScore + "/35");
            }
        }
    }
}

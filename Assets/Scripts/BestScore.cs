using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public int highScore = 0;

    [SerializeField] private Text bestScore;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        bestScore.text = ("Best Score: " + highScore + "/35");
    }
}

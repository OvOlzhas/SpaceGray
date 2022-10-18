using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private Text scoreText;

    public int Score => _score;
    
    private void Start()
    {
        scoreText.text = "SCORE:" + _score.ToString();
    }

    public void IncreaseScore(int add)
    {
        _score += add;
        scoreText.text = "SCORE:" + _score.ToString();
    }
}

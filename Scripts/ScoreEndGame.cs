using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEndGame : MonoBehaviour
{
    void Start()
    {
        Text text = GetComponent<Text>();
        int current_score = PlayerPrefs.GetInt("currentScore");
        int best_score = PlayerPrefs.GetInt("bestScore");
        text.text = "Your score:" + current_score.ToString() + "\n" + "Best score:" + best_score.ToString();
    }
}

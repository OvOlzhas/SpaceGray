using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEndGame : MonoBehaviour
{
    void Start()
    {
        Text text = GetComponent<Text>();
        int current_score = PlayerPrefs.HasKey("currentScore") ? PlayerPrefs.GetInt("currentScore") : 0;
        int best_score = PlayerPrefs.HasKey("bestScore") ? PlayerPrefs.GetInt("bestScore") : 0;
        text.text = "Your score:" + current_score.ToString() + "\n" + "Best score:" + best_score.ToString();
    }
}

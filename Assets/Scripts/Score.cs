using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    private Text CurrentScore;

    // Update is called once per frame
    void Update()
    {
        CurrentScore.text = score.ToString();

        if (score > PlayerPrefs.GetInt("highestscore"));
        PlayerPrefs.SetInt("highestscore", score);
    }

    public void AddScoreButton()
    {
        score += 1;
    }
}

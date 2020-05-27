using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameOverUI gameOverMenu;

    void Awake()
    {
        scoreText = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        scoreText.enabled = false;
    }
}

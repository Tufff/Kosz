using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    TextMeshProUGUI yourScore;
    TextMeshProUGUI highScore;
    int currentScore;

    // Start is called before the first frame update
    void Awake()
    {
        yourScore = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        highScore = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void MakeHighScore()
    {
        currentScore = GameManager.instance.score;
        yourScore.text = currentScore.ToString();
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}

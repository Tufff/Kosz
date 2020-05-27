using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public TextMeshProUGUI yourScore;
    public TextMeshProUGUI highScore;
    public GameObject tabDisplay;

    ScoreDisplay scrDis;

    int score = 0;
    int comboCount = 1;

    void Awake()
    {
        instance = this;
        scrDis = GameObject.FindWithTag("ScoreDisplay").GetComponent<ScoreDisplay>();
        Time.timeScale = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        score = 0;
        comboCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Score: " + score);
        //Debug.Log(comboCount);
    }

    public void ScorePoints(){
        score += comboCount;
        comboCount++;
        if (comboCount > 5){
            comboCount = 5;
        }
        scrDis.SetScore(score);
    }

    public void ResetCombo()
    {
        comboCount = 1;
    }

    public void RestartLevel(){
        scrDis.GameOver();
    }

    public void GameOver(){
        yourScore.text = score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", score);
        }
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        tabDisplay.SetActive(true);
    }
}

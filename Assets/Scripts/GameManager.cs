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
    GameObject tabDisplay;

    ScoreDisplay scrDis;

    public int score = 0;
    int comboCount = 1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        scrDis = GameObject.FindWithTag("ScoreDisplay").GetComponent<ScoreDisplay>();
        tabDisplay = GameObject.FindWithTag("ScoreDisplay").transform.GetChild(1).gameObject;
        tabDisplay.SetActive(true);
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
        if (scrDis == null)
        {
            scrDis = GameObject.FindWithTag("ScoreDisplay").GetComponent<ScoreDisplay>();
            
        }
        if(tabDisplay == null)
        {
            tabDisplay = GameObject.FindWithTag("ScoreDisplay").transform.GetChild(1).gameObject;
        }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        score = 0;
        comboCount = 1;
    }

    public void GameOver(){
        scrDis.GameOver();
        tabDisplay.SetActive(true);
        tabDisplay.GetComponent<TabController>().UpdateScorePanel();
    }
}

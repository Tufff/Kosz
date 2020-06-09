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
    public GameObject tabDisplay;

    ScoreDisplay scrDis;

    public int score = 0;
    int comboCount = 1;
    int money = 0;
    float moneyEvery10 = 0;

    void Awake()
    {
        scrDis = GameObject.FindWithTag("ScoreDisplay").GetComponent<ScoreDisplay>();
        tabDisplay.SetActive(true);
        instance = this;
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
        moneyEvery10 += comboCount;
        if (moneyEvery10/10 >= 1){
            GameManager.instance.AddMoney();
            moneyEvery10 = score%10;
        }
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
    }

    public void GameOver(){
        scrDis.GameOver();
        tabDisplay.SetActive(true);
        tabDisplay.GetComponent<TabController>().UpdateScorePanel();
    }

    public void AddMoney(){
        money += 1;
        scrDis.SetMoney(money);
    }
}

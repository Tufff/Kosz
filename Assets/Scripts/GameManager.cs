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

    BallSpawner spawner;
    ScoreDisplay scrDis;

    public int score = 0;
    public int comboCount = 1;
    public bool superBall = false;
    public int ballCounter = 0;
    int money = 0;
    float moneyEvery10 = 0;

    void Awake()
    {
        scrDis = GameObject.FindWithTag("ScoreDisplay").GetComponent<ScoreDisplay>();
        spawner = GetComponent<BallSpawner>();
        tabDisplay.SetActive(true);
        money = PlayerPrefs.GetInt("money", 0);
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scrDis.SetMoney(money);
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
        if (comboCount >= 5){
            comboCount = 5;
            superBall = true;
        }
        scrDis.SetScore(score);
        ChangeTime();
    }

    public void ResetCombo()
    {
        comboCount = 1;
        superBall = false;
    }

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver(){
        PlayerPrefs.SetInt("money", money);
        scrDis.GameOver();
        tabDisplay.SetActive(true);
        tabDisplay.GetComponent<TabController>().UpdateScorePanel();
    }

    public void AddMoney(){
        money += 1;
        scrDis.SetMoney(money);
    }

    void ChangeTime(){
        if (spawner.timeBtw > 0.5f){
            spawner.timeBtw = 1f - (ballCounter/1000f);
        }
    }
}

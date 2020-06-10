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
        tabDisplay = GameObject.FindWithTag("ScoreDisplay").transform.GetChild(2).gameObject;
        tabDisplay.SetActive(true);
        
        spawner = GetComponent<BallSpawner>();
        money = PlayerPrefs.GetInt("money", 0);
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
        if (SceneManager.GetActiveScene().buildIndex == 1){
            if (scrDis == null)
            {
                scrDis = GameObject.FindWithTag("ScoreDisplay").GetComponent<ScoreDisplay>();
            }
            if(tabDisplay == null)
            {
                tabDisplay = GameObject.FindWithTag("ScoreDisplay").transform.GetChild(2).gameObject;
                scrDis.SetMoney(money);
            }
        }
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
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        score = 0;
        comboCount = 1;
    }

    public void GameOver(){
        spawner.timeBtw = 1f;
        ballCounter = 0;
        ResetCombo();
        PlayerPrefs.SetInt("money", money);
        scrDis.GameOver();
        tabDisplay.SetActive(true);
        tabDisplay.GetComponent<TabController>().UpdateScorePanel();
        score = 0;
        moneyEvery10 = 0;
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

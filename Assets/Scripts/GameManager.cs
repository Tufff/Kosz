using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    ScoreDisplay scrDis;

    int score = 0;
    int comboCount = 1;

    void Awake()
    {
        instance = this;
        scrDis = GameObject.FindWithTag("ScoreDisplay").GetComponent<ScoreDisplay>();
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
}

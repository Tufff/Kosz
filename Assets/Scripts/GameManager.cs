using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    
    int score = 0;
    int comboCount = 1;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
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
    }

    public void ResetCombo()
    {
        comboCount = 1;
    }
}

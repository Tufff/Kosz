using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    void Awake()
    {
        scoreText = transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
    }


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(string currentScoreStr)
    {
        scoreText.text = currentScoreStr;
        gameObject.SetActive(true);
    }

    public void RestartButtonAction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

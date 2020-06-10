using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public void ResetPrefs(){
        PlayerPrefs.DeleteAll();
    }

    public void Restart(){
        GameManager.instance.RestartLevel();
    }

    public void Menu(){
        SceneManager.LoadScene("Menu");
    }
}

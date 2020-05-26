using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    public void ResetPrefs(){
        PlayerPrefs.DeleteAll();
    }

    public void Restart(){
        GameManager.instance.RestartLevel();
    }
}

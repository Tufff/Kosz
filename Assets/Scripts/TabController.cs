using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TabController : MonoBehaviour
{
    Transform buttonsPanel;
    Transform panelsPanel;

    public Color normalColor;
    public Color mouseClickColor;
    public Color mouseEnterColor;

    int selectedIndex;
    TabButtons selectedButton;
    
    List<TabButtons> buttons = new List<TabButtons>();
    List<Transform> panels = new List<Transform>();

    void Awake(){
        buttonsPanel = transform.GetChild(0).gameObject.transform;
        panelsPanel = transform.GetChild(1).gameObject.transform;

        for (int i = 0; i < buttonsPanel.transform.childCount; i++)
        {
            GameObject buttonTemp = buttonsPanel.transform.GetChild(i).gameObject;
            TabButtons button = buttonTemp.GetComponent<TabButtons>();
            button.SetIndex(i);
            buttons.Add(button);
        }

        foreach (Transform item in panelsPanel.transform)
        {
            panels.Add(item);
        }
        
        ButtonMouseClick(0);
        gameObject.SetActive(false);
    }

    public void ButtonMouseClick(int id){
        if (selectedButton != null){
            selectedButton.ToggleActive();
        }

        selectedIndex = id;
        selectedButton = buttons[selectedIndex];
        selectedButton.ToggleActive();
        HideAllPanels();
    }

    void HideAllPanels(){
        for (int i = 0; i < panels.Count; i++)
        {
            if (i == selectedIndex){
                panels[i].gameObject.SetActive(true);
            }else
            {
                panels[i].gameObject.SetActive(false);
            }
        }
    }

    public void UpdateScorePanel()
    {
        panels[0].gameObject.GetComponent<ScorePanel>().MakeHighScore();
    }

}

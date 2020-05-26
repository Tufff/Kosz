using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TabButtons : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    int tabIndex;
    Image image;
    TabController controller;
    bool isActive = false;

    void Awake(){
        controller = FindObjectOfType<TabController>();
        image = GetComponent<Image>();
    }

    public void SetIndex(int index){
        tabIndex = index;
    }
    
    public void OnPointerClick(PointerEventData eventData){
        controller.ButtonMouseClick(tabIndex);
    }

    public void OnPointerEnter(PointerEventData eventData){
        if (!isActive){
            image.color = controller.mouseEnterColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData){
        if (!isActive){
            image.color = controller.normalColor;
        }
    }

    public void ToggleActive(){
        isActive = !isActive;
        if(isActive){
            image.color = controller.mouseClickColor;
        }else{
            image.color = controller.normalColor;
        }
    }
}

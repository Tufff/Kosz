using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinScript : MonoBehaviour
{
    int id;

    GameObject costChild;
    GameObject padlockChild;

    void Start()
    {
        //costChild = transform.GetChild(1).gameObject;
        //padlockChild = transform.GetChild(2).gameObject;
    }

    public void Unlock()
    {
        BallMeshHolder.instance.NewUnlocked(id);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);//button unl
        transform.GetChild(4).gameObject.SetActive(true);//button choose
    }

    public void Choose()
    {
        BallMeshHolder.instance.SetCurrentID(id);
    }

    public void Init(int nextID)
    {
        id = nextID;
    }
}

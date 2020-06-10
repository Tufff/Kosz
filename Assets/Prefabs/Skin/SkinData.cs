using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkinData
{
    bool[] unlockedID;

    public SkinData(int numberOfSkins, bool[] unlocked)
    {
        unlockedID = new bool[numberOfSkins];
        for(int i = 0; i < numberOfSkins; i++)
        {
            unlockedID[i] = unlocked[i];
        }
    }

    public bool[] GetUnlockedList()
    {
        return unlockedID;
    }
}

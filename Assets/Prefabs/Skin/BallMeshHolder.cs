using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class BallMeshHolder : MonoBehaviour
{
    public static BallMeshHolder instance = null;

    public Mesh[] meshes;
    bool[] unlocked;
    int currentID = 0;

    GameObject skinPanel;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
        }
        skinPanel = GameObject.FindWithTag("ScoreDisplay").transform.GetChild(2).transform.GetChild(1).transform.GetChild(1).gameObject;
        unlocked = LoadData();
        if(unlocked == null)
        {
            Debug.Log("po raz pierwszy");
            unlocked = new bool[skinPanel.transform.childCount];
            NewUnlocked(0);
        }

        skinPanel = null;
        SkinInit();
        
        /*int i = 0;
        foreach(GameObject skin in skinPanel)
        {
            SkinScript skinScr= skin.GetComponent<SkinScript>();
            if(skin == null) { Debug.Log("f"); }
            skinScr.Init(i);
            i++;
        }*/
    }

    void Update()
    {
        SkinInit();
    }

    void SkinInit()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1){
            if(skinPanel == null)
            {
                skinPanel = GameObject.FindWithTag("ScoreDisplay").transform.GetChild(2).transform.GetChild(1).transform.GetChild(1).gameObject;
                
                for (int i = 0; i < skinPanel.transform.childCount; i++)
                {
                    SkinScript skinScr = skinPanel.transform.GetChild(i).gameObject.GetComponent<SkinScript>();
                    skinScr.Init(i);
                    if (unlocked[i])
                    {
                        skinScr.Unlock();
                    }
                }
            }
        }
    }

    public void SetCurrentID(int id)
    {
        currentID = id;
    }

    public void NewUnlocked(int id)
    {
        unlocked[id] = true;

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/unlockedSkins.tau";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        SkinData data = new SkinData(unlocked.Length, unlocked);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public Mesh TakeCurrentMesh()
    {
        return meshes[currentID];
    }

    bool[] LoadData()
    {
        string path = Application.persistentDataPath + "/unlockedSkins.tau";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            SkinData data = formatter.Deserialize(fileStream) as SkinData;
            fileStream.Close();

            return data.GetUnlockedList();
        }
        else
        {
            Debug.Log("nie wczytalem pliku");
            return null;
        }
    }
}

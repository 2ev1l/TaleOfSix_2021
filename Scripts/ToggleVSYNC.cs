using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class ToggleVSYNC : MonoBehaviour
{
    public GameObject checkmark;
    bool check;
    static readonly string LangSave = "ll.json";

    void Start()
    {
        SaveData1 data = new SaveData1();
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, LangSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData1 copy = JsonUtility.FromJson<SaveData1>(jsonFromFile);
        if (copy.vsync==false)
        {
            checkmark.SetActive(false);
            check=false;
        }
        else
        {
            checkmark.SetActive(true);
            check=true;
        }
    }

    public void VCheck()
    {
        if (check==true)
        {
            QualitySettings.vSyncCount = 0;
            check=false;
            SaveData1 data = new SaveData1()
            {
                lang = JsonUtility.FromJson<SaveData1>(File.ReadAllText(Path.Combine(Application.persistentDataPath, LangSave))).lang,
                vsync = false
            };
            string json = JsonUtility.ToJson(data);
            string filename = Path.Combine(Application.persistentDataPath, LangSave);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData1 copy = JsonUtility.FromJson<SaveData1>(jsonFromFile);
            File.WriteAllText(filename, json);
            checkmark.SetActive(false);
            Debug.Log("TRUE");
        }
        else
        {
            QualitySettings.vSyncCount = 1;
            check=true;
            SaveData1 data = new SaveData1()
            {
                lang = JsonUtility.FromJson<SaveData1>(File.ReadAllText(Path.Combine(Application.persistentDataPath, LangSave))).lang,
                vsync = true
            };
            string json = JsonUtility.ToJson(data);
            string filename = Path.Combine(Application.persistentDataPath, LangSave);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData1 copy = JsonUtility.FromJson<SaveData1>(jsonFromFile);
            File.WriteAllText(filename, json);
            checkmark.SetActive(true);
            Debug.Log("FALSE");
        }
    }

}

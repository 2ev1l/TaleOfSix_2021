using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SetLang : MonoBehaviour
{
    static readonly string LangSave = "ll.json";
    GameObject LangEng;
    GameObject LangRus;
    void Start()
    {
            if (GameObject.Find("eng") != null)
            LangEng=GameObject.Find("eng");
            if (GameObject.Find("rus") != null)
            LangRus=GameObject.Find("rus");
            SaveData1 data = new SaveData1();
            string json = JsonUtility.ToJson(data);
            string filename = Path.Combine(Application.persistentDataPath, LangSave);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData1 copy = JsonUtility.FromJson<SaveData1>(jsonFromFile);
            if (copy.lang == "RUS")
            {
                LangEng.SetActive(false);
                LangRus.SetActive(true);
            }
            else
            {
                LangEng.SetActive(true);
                LangRus.SetActive(false);
            }
    }

}

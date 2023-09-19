using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class Serializer1 : MonoBehaviour
{
    static readonly string LangSave = "ll.json";
    
    void Awake()
    {  
        if (!File.Exists(Path.Combine(Application.persistentDataPath, LangSave)))
        {
            using (FileStream fs = File.Create(Path.Combine(Application.persistentDataPath, LangSave)))
            Debug.Log(Path.Combine(Application.persistentDataPath, LangSave));
            SaveData1 data = new SaveData1()
            {
                lang = "ENG",
                vsync = false
            };
            string json = JsonUtility.ToJson(data);
            string filename = Path.Combine(Application.persistentDataPath, LangSave);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData1 copy = JsonUtility.FromJson<SaveData1>(jsonFromFile);
            File.WriteAllText(filename, json);
        } 
    }
}

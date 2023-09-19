using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class Serializer : MonoBehaviour
{
    static readonly string GameSave = "ss.json";
    
    void Awake()
    {  
        if (!File.Exists(Path.Combine(Application.persistentDataPath, GameSave)))
        {
            using (FileStream fs = File.Create(Path.Combine(Application.persistentDataPath, GameSave)))
            Debug.Log(Path.Combine(Application.persistentDataPath, GameSave));
            SaveData data = new SaveData()
            {
                deathcount = 0,
                pos = " ",
                scene = " ",
                m1=true,
                m2=false,
                m3=false,
                p=0
            };
            string json = JsonUtility.ToJson(data);
            string filename = Path.Combine(Application.persistentDataPath, GameSave);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
            File.WriteAllText(filename, json);
        } 
    }
}

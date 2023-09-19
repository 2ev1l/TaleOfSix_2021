using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class SaveGPMenu : MonoBehaviour
{
    static readonly string GameSave = "ss.json";

    void Start()
    {
        SaveData data = new SaveData()
        {
            scene = SceneManager.GetActiveScene().name,
            pos = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).pos,
            deathcount = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).deathcount,
            m1 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m1,
            m2 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m2,
            m3 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m3,
            p = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).p
        };    
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        Debug.Log("Player saved to " + filename);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        File.WriteAllText(filename, json);

    }
}

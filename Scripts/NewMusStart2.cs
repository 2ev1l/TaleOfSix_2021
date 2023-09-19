using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class NewMusStart2 : MonoBehaviour
{
    static readonly string GameSave = "ss.json";

    void Start()
    {
        SaveData data = new SaveData()
            {
                deathcount = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).deathcount,
                scene = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).scene,
                pos = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).pos,
                m1=false,
                m2=false,
                m3=true,
                p = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).p
            };
            string json = JsonUtility.ToJson(data);
            string filename = Path.Combine(Application.persistentDataPath, GameSave);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
            
        if (copy.m3==false)
        {
        DDONLOAD.audioData.Stop();
        DDONLOAD.audioData2.Stop();
        DDONLOAD.audioData3.Play();
        File.WriteAllText(filename, json);
        }
    }

}

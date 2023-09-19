using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveID : MonoBehaviour
{
    static readonly string GameSave = "ss.json";
    int pCurrent;
    
    void Start()
    {
        if (SceneManager.GetActiveScene().name=="1.1") pCurrent=0;
        if (SceneManager.GetActiveScene().name=="2.1") pCurrent=1;
        if (SceneManager.GetActiveScene().name=="3.1") pCurrent=2;
        if (SceneManager.GetActiveScene().name=="4.1") pCurrent=3;
        if (SceneManager.GetActiveScene().name=="5.1") pCurrent=4;
        if (SceneManager.GetActiveScene().name=="6.1") pCurrent=5;
        if (SceneManager.GetActiveScene().name=="7.1") pCurrent=6;
        if (SceneManager.GetActiveScene().name=="8.1") pCurrent=7;
        if (SceneManager.GetActiveScene().name=="9.1") pCurrent=8;
        if (SceneManager.GetActiveScene().name=="10.1") pCurrent=9;
        if (SceneManager.GetActiveScene().name=="11.1") pCurrent=10;
        if (SceneManager.GetActiveScene().name=="12.1") pCurrent=11;
        if (SceneManager.GetActiveScene().name=="13.1") pCurrent=12;
        if (SceneManager.GetActiveScene().name=="14.1") pCurrent=13;
        if (SceneManager.GetActiveScene().name=="15.1") pCurrent=14;
        if (SceneManager.GetActiveScene().name=="16.1") pCurrent=15;
        if (SceneManager.GetActiveScene().name=="17.1") pCurrent=16;
        if (SceneManager.GetActiveScene().name=="18.1") pCurrent=17;
        if (SceneManager.GetActiveScene().name=="19.1") pCurrent=18;
        if (SceneManager.GetActiveScene().name=="20.1") pCurrent=19;
        if (SceneManager.GetActiveScene().name=="21.1") pCurrent=20;
        if (SceneManager.GetActiveScene().name=="22.1") pCurrent=21;
        if (SceneManager.GetActiveScene().name=="23.1") pCurrent=22;
        if (SceneManager.GetActiveScene().name=="24.1") pCurrent=23;
        if (SceneManager.GetActiveScene().name=="25.1") pCurrent=24;
        if (SceneManager.GetActiveScene().name=="26.1") pCurrent=25;
        if (SceneManager.GetActiveScene().name=="27.1") pCurrent=26;
        if (SceneManager.GetActiveScene().name=="28.1") pCurrent=27;
        if (SceneManager.GetActiveScene().name=="29.1") pCurrent=28;
        if (SceneManager.GetActiveScene().name=="30.1") pCurrent=29;
        if (SceneManager.GetActiveScene().name=="31.1") pCurrent=30;
        
        if (JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).p < pCurrent)
        {
        SaveData data = new SaveData()
            {
                scene = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).scene,
                pos = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).pos,
                m1 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m1,
                m2 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m2,
                m3 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m3,
                deathcount = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).deathcount,
                p = pCurrent
            };
            string json = JsonUtility.ToJson(data);
            string filename = Path.Combine(Application.persistentDataPath, GameSave);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
            File.WriteAllText(filename, json);
        }
    }

}

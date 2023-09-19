using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class X201 : MonoBehaviour
{
    static readonly string GameSave = "ss.json";
    public GameObject Hide;
    public GameObject Hide2;
    void Start()
    {
            SaveData data = new SaveData();
            string json = JsonUtility.ToJson(data);
            string filename = Path.Combine(Application.persistentDataPath, GameSave);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
            if (copy.p>=20)
            {
                Hide2.SetActive(true);
                Hide.SetActive(true);
            }
            else
            {
                Hide2.SetActive(false);
                Hide.SetActive(false);
            }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DeathText : MonoBehaviour
{
    static readonly string GameSave = "ss.json";
    public Text display_Text;

    void Start()
    {
            SaveData data = new SaveData();
            string json = JsonUtility.ToJson(data);
            string filename = Path.Combine(Application.persistentDataPath, GameSave);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
            display_Text.text=copy.deathcount.ToString();
    }

}

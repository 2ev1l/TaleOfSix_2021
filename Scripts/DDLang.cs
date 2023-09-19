using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using Steamworks;

public class DDLang : MonoBehaviour
{
public Dropdown DropDown;
static readonly string LangSave = "ll.json";

public void DropD()
{
    if (DropDown.value == 0)
    {
        //Debug.Log("0");
        SaveData1 data = new SaveData1()
            {
                lang = "ENG",
                vsync = JsonUtility.FromJson<SaveData1>(File.ReadAllText(Path.Combine(Application.persistentDataPath, LangSave))).vsync
            };
            string json = JsonUtility.ToJson(data);
            string filename = Path.Combine(Application.persistentDataPath, LangSave);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData1 copy = JsonUtility.FromJson<SaveData1>(jsonFromFile);
            File.WriteAllText(filename, json);
    }
    if (DropDown.value == 1)
    {
        //Debug.Log("1");
        SaveData1 data = new SaveData1()
            {
                lang = "RUS",
                vsync = JsonUtility.FromJson<SaveData1>(File.ReadAllText(Path.Combine(Application.persistentDataPath, LangSave))).vsync
            };
            string json = JsonUtility.ToJson(data);
            string filename = Path.Combine(Application.persistentDataPath, LangSave);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData1 copy = JsonUtility.FromJson<SaveData1>(jsonFromFile);
            File.WriteAllText(filename, json);
    }
    if (DropDown.value == 2)
    {
        //Debug.Log("2");
        if(SteamManager.Initialized)
        {
            Steamworks.SteamUserStats.SetAchievement("ACH_BUG");
            SteamUserStats.StoreStats();
        }
    }
}

}

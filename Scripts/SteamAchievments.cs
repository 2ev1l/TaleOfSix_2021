using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using Steamworks;
using UnityEngine.SceneManagement;
using System.IO;

public class SteamAchievments : MonoBehaviour 
{
   static readonly string GameSave = "ss.json";

    private void Update()
    {
        SaveData data = new SaveData();
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);

        Scene scene = SceneManager.GetActiveScene();
        
        if(SteamManager.Initialized)
        {
            if (scene.name == "BHEnd") 
            {
            Steamworks.SteamUserStats.SetAchievement("ACH_DEND");
            SteamUserStats.StoreStats();
            }
            if (scene.name == "SuicideEnd") 
            {
            Steamworks.SteamUserStats.SetAchievement("ACH_SEND");
            SteamUserStats.StoreStats();
            }
            if (scene.name == "TimeEnd") 
            {
            Steamworks.SteamUserStats.SetAchievement("ACH_TIME");
            SteamUserStats.StoreStats();
            }
            if (scene.name == "GoodEnd") 
            {
            Steamworks.SteamUserStats.SetAchievement("ACH_GEND");
            SteamUserStats.StoreStats();
            }
            if (scene.name == "Secret1") 
            {
            Steamworks.SteamUserStats.SetAchievement("ACH_2021");
            SteamUserStats.StoreStats();
            }
            if (scene.name == "Secret2") 
            {
            Steamworks.SteamUserStats.SetAchievement("ACH_18");
            SteamUserStats.StoreStats();
            }
            if (scene.name == "Secret3") 
            {
            Steamworks.SteamUserStats.SetAchievement("ACH_Cassiopeya");
            SteamUserStats.StoreStats();
            }
            if (scene.name == "31.1") 
            {
            Steamworks.SteamUserStats.SetAchievement("ACH_AEND");
            SteamUserStats.StoreStats();
            }
            if (scene.name == "1.1") 
            {
            Steamworks.SteamUserStats.SetAchievement("ACH_START");
            SteamUserStats.StoreStats();
            }
            if (scene.name == "11.1") 
            {
            Steamworks.SteamUserStats.SetAchievement("ACH_CH1");
            SteamUserStats.StoreStats();
            }
            if (scene.name == "21.1") 
            {
            Steamworks.SteamUserStats.SetAchievement("ACH_CH2");
            SteamUserStats.StoreStats();
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using Steamworks;

public class X31 : MonoBehaviour
{
    static readonly string GameSave = "ss.json";
    public Text eng;
    public Text rus;

    void Start()
    {
        SaveData data = new SaveData();
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        if (copy.deathcount==0)
        {
            eng.text="It was hard, but I saved my life...";
            rus.text="Было тяжело, но я сохранил свою жизнь...";
            if(SteamManager.Initialized)
            {
                Steamworks.SteamUserStats.SetAchievement("ACH_SSS");
                SteamUserStats.StoreStats();
                Steamworks.SteamUserStats.SetAchievement("ACH_SS");
                SteamUserStats.StoreStats();
                Steamworks.SteamUserStats.SetAchievement("ACH_S");
                    SteamUserStats.StoreStats();
                    Steamworks.SteamUserStats.SetAchievement("ACH_A");
                        SteamUserStats.StoreStats();
                        Steamworks.SteamUserStats.SetAchievement("ACH_B");
                            SteamUserStats.StoreStats();
                            Steamworks.SteamUserStats.SetAchievement("ACH_C");
                                SteamUserStats.StoreStats();
                                Steamworks.SteamUserStats.SetAchievement("ACH_D");
                                    SteamUserStats.StoreStats();
                                    Steamworks.SteamUserStats.SetAchievement("ACH_E");
                                        SteamUserStats.StoreStats();
                                        Steamworks.SteamUserStats.SetAchievement("ACH_F");
                                        SteamUserStats.StoreStats();
            }
        }
        else
        {
            eng.text="It was a painful journey, because I died " + copy.deathcount.ToString() +" times...";
            rus.text="Это было болезненное путешествие, потому что я умер "+ copy.deathcount.ToString() +" раз...";
            //It was a painful journey, because I died X times
            if(SteamManager.Initialized)
            {
            if (copy.deathcount<=10)
            {
                Steamworks.SteamUserStats.SetAchievement("ACH_SS");
                SteamUserStats.StoreStats();
                Steamworks.SteamUserStats.SetAchievement("ACH_S");
                    SteamUserStats.StoreStats();
                    Steamworks.SteamUserStats.SetAchievement("ACH_A");
                        SteamUserStats.StoreStats();
                        Steamworks.SteamUserStats.SetAchievement("ACH_B");
                            SteamUserStats.StoreStats();
                            Steamworks.SteamUserStats.SetAchievement("ACH_C");
                                SteamUserStats.StoreStats();
                                Steamworks.SteamUserStats.SetAchievement("ACH_D");
                                    SteamUserStats.StoreStats();
                                    Steamworks.SteamUserStats.SetAchievement("ACH_E");
                                        SteamUserStats.StoreStats();
                                        Steamworks.SteamUserStats.SetAchievement("ACH_F");
                                        SteamUserStats.StoreStats();
                
            }
            else
            {
                if (copy.deathcount<=50)
                {
                    Steamworks.SteamUserStats.SetAchievement("ACH_S");
                    SteamUserStats.StoreStats();
                    Steamworks.SteamUserStats.SetAchievement("ACH_A");
                        SteamUserStats.StoreStats();
                        Steamworks.SteamUserStats.SetAchievement("ACH_B");
                            SteamUserStats.StoreStats();
                            Steamworks.SteamUserStats.SetAchievement("ACH_C");
                                SteamUserStats.StoreStats();
                                Steamworks.SteamUserStats.SetAchievement("ACH_D");
                                    SteamUserStats.StoreStats();
                                    Steamworks.SteamUserStats.SetAchievement("ACH_E");
                                        SteamUserStats.StoreStats();
                                        Steamworks.SteamUserStats.SetAchievement("ACH_F");
                                        SteamUserStats.StoreStats();
                }
                else
                {
                    if (copy.deathcount<=100)
                    {
                        Steamworks.SteamUserStats.SetAchievement("ACH_A");
                        SteamUserStats.StoreStats();
                        Steamworks.SteamUserStats.SetAchievement("ACH_B");
                            SteamUserStats.StoreStats();
                            Steamworks.SteamUserStats.SetAchievement("ACH_C");
                                SteamUserStats.StoreStats();
                                Steamworks.SteamUserStats.SetAchievement("ACH_D");
                                    SteamUserStats.StoreStats();
                                    Steamworks.SteamUserStats.SetAchievement("ACH_E");
                                        SteamUserStats.StoreStats();
                                        Steamworks.SteamUserStats.SetAchievement("ACH_F");
                                        SteamUserStats.StoreStats();
                    }
                    else
                    {
                        if (copy.deathcount<=200)
                        {
                            Steamworks.SteamUserStats.SetAchievement("ACH_B");
                            SteamUserStats.StoreStats();
                            Steamworks.SteamUserStats.SetAchievement("ACH_C");
                                SteamUserStats.StoreStats();
                                Steamworks.SteamUserStats.SetAchievement("ACH_D");
                                    SteamUserStats.StoreStats();
                                    Steamworks.SteamUserStats.SetAchievement("ACH_E");
                                        SteamUserStats.StoreStats();
                                        Steamworks.SteamUserStats.SetAchievement("ACH_F");
                                        SteamUserStats.StoreStats();
                        }
                        else
                        {
                            if (copy.deathcount<=500)
                            {
                                Steamworks.SteamUserStats.SetAchievement("ACH_C");
                                SteamUserStats.StoreStats();
                                Steamworks.SteamUserStats.SetAchievement("ACH_D");
                                    SteamUserStats.StoreStats();
                                    Steamworks.SteamUserStats.SetAchievement("ACH_E");
                                        SteamUserStats.StoreStats();
                                        Steamworks.SteamUserStats.SetAchievement("ACH_F");
                                        SteamUserStats.StoreStats();
                            }
                            else
                            {
                                if (copy.deathcount<=1000)
                                {
                                    Steamworks.SteamUserStats.SetAchievement("ACH_D");
                                    SteamUserStats.StoreStats();
                                    Steamworks.SteamUserStats.SetAchievement("ACH_E");
                                        SteamUserStats.StoreStats();
                                        Steamworks.SteamUserStats.SetAchievement("ACH_F");
                                        SteamUserStats.StoreStats();
                                }
                                else
                                {
                                    if (copy.deathcount<=2000)
                                    {
                                        Steamworks.SteamUserStats.SetAchievement("ACH_E");
                                        SteamUserStats.StoreStats();
                                        Steamworks.SteamUserStats.SetAchievement("ACH_F");
                                        SteamUserStats.StoreStats();
                                    }
                                    else
                                    {
                                        Steamworks.SteamUserStats.SetAchievement("ACH_F");
                                        SteamUserStats.StoreStats();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            }   
        }
    }
}

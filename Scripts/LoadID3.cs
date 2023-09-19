using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadID3 : MonoBehaviour
{
    static readonly string GameSave = "ss.json";
    static readonly string LangSave = "ll.json";
    public GameObject ChapterMenu;
    GameObject LangEng;
    GameObject LangRus;
    public GameObject P21;
    public GameObject P22;
    public GameObject P23;
    public GameObject P24;
    public GameObject P25;
    public GameObject P26;
    public GameObject P27;
    public GameObject P28;
    public GameObject P29;
    public GameObject P30;

    public GameObject P21R;
    public GameObject P22R;
    public GameObject P23R;
    public GameObject P24R;
    public GameObject P25R;
    public GameObject P26R;
    public GameObject P27R;
    public GameObject P28R;
    public GameObject P29R;
    public GameObject P30R;

    void Start()
    {
        if (GameObject.Find("eng") != null)
            LangEng=GameObject.Find("eng");
            if (GameObject.Find("rus") != null)
            LangRus=GameObject.Find("rus");
            SaveData1 data1 = new SaveData1();
            string json1 = JsonUtility.ToJson(data1);
            string filename1 = Path.Combine(Application.persistentDataPath, LangSave);
            string jsonFromFile1 = File.ReadAllText(filename1);
            SaveData1 copy1 = JsonUtility.FromJson<SaveData1>(jsonFromFile1);
            if (copy1.lang == "RUS")
            {
                LangEng.SetActive(false);
                LangRus.SetActive(true);
            }
            else
            {
                LangEng.SetActive(true);
                LangRus.SetActive(false);
            }

        //if (ChapterMenu.activeSelf==true)
        //{
        SaveData data = new SaveData();
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);

        if (copy.p>=21)  P21.SetActive(true); else 
                        P21.SetActive(false);
        
        if (copy.p>=22)  P22.SetActive(true); else 
                        P22.SetActive(false);

        if (copy.p>=23)  P23.SetActive(true); else 
                        P23.SetActive(false);
        
        if (copy.p>=24)  P24.SetActive(true); else 
                        P24.SetActive(false);
        
        if (copy.p>=25)  P25.SetActive(true); else 
                        P25.SetActive(false);
        
        if (copy.p>=26)  P26.SetActive(true); else 
                        P26.SetActive(false);
        
        if (copy.p>=27)  P27.SetActive(true); else 
                        P27.SetActive(false);

        if (copy.p>=28)  P28.SetActive(true); else 
                        P28.SetActive(false);

        if (copy.p>=29)  P29.SetActive(true); else 
                        P29.SetActive(false);

        if (copy.p>=30) P30.SetActive(true); else 
                        P30.SetActive(false);


        if (copy.p>=21)  P21R.SetActive(true); else 
                        P21R.SetActive(false);
        
        if (copy.p>=22)  P22R.SetActive(true); else 
                        P22R.SetActive(false);

        if (copy.p>=23)  P23R.SetActive(true); else 
                        P23R.SetActive(false);
        
        if (copy.p>=24)  P24R.SetActive(true); else 
                        P24R.SetActive(false);
        
        if (copy.p>=25)  P25R.SetActive(true); else 
                        P25R.SetActive(false);
        
        if (copy.p>=26)  P26R.SetActive(true); else 
                        P26R.SetActive(false);
        
        if (copy.p>=27)  P27R.SetActive(true); else 
                        P27R.SetActive(false);

        if (copy.p>=28)  P28R.SetActive(true); else 
                        P28R.SetActive(false);

        if (copy.p>=29)  P29R.SetActive(true); else 
                        P29R.SetActive(false);

        if (copy.p>=30) P30R.SetActive(true); else 
                        P30R.SetActive(false);

        //}
    }

}

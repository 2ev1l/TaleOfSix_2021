using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadID1 : MonoBehaviour
{
    static readonly string GameSave = "ss.json";
    static readonly string LangSave = "ll.json";
    public GameObject Next;
    public GameObject BackNext;
    public GameObject BackD;
    public GameObject ChapterMenu;
    GameObject LangEng;
    GameObject LangRus;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    public GameObject P5;
    public GameObject P6;
    public GameObject P7;
    public GameObject P8;
    public GameObject P9;
    public GameObject P10;

    public GameObject P1R;
    public GameObject P2R;
    public GameObject P3R;
    public GameObject P4R;
    public GameObject P5R;
    public GameObject P6R;
    public GameObject P7R;
    public GameObject P8R;
    public GameObject P9R;
    public GameObject P10R;
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

        if (copy.p>=1)  P1.SetActive(true); else 
                        P1.SetActive(false);
        
        if (copy.p>=2)  P2.SetActive(true); else 
                        P2.SetActive(false);

        if (copy.p>=3)  P3.SetActive(true); else 
                        P3.SetActive(false);
        
        if (copy.p>=4)  P4.SetActive(true); else 
                        P4.SetActive(false);
        
        if (copy.p>=5)  P5.SetActive(true); else 
                        P5.SetActive(false);
        
        if (copy.p>=6)  P6.SetActive(true); else 
                        P6.SetActive(false);
        
        if (copy.p>=7)  P7.SetActive(true); else 
                        P7.SetActive(false);

        if (copy.p>=8)  P8.SetActive(true); else 
                        P8.SetActive(false);

        if (copy.p>=9)  P9.SetActive(true); else 
                        P9.SetActive(false);

        if (copy.p>=10) P10.SetActive(true); else 
                        P10.SetActive(false);
        

        if (copy.p>=1)  P1R.SetActive(true); else 
                        P1R.SetActive(false);
        
        if (copy.p>=2)  P2R.SetActive(true); else 
                        P2R.SetActive(false);

        if (copy.p>=3)  P3R.SetActive(true); else 
                        P3R.SetActive(false);
        
        if (copy.p>=4)  P4R.SetActive(true); else 
                        P4R.SetActive(false);
        
        if (copy.p>=5)  P5R.SetActive(true); else 
                        P5R.SetActive(false);
        
        if (copy.p>=6)  P6R.SetActive(true); else 
                        P6R.SetActive(false);
        
        if (copy.p>=7)  P7R.SetActive(true); else 
                        P7R.SetActive(false);

        if (copy.p>=8)  P8R.SetActive(true); else 
                        P8R.SetActive(false);

        if (copy.p>=9)  P9R.SetActive(true); else 
                        P9R.SetActive(false);

        if (copy.p>=10) P10R.SetActive(true); else 
                        P10R.SetActive(false);


        if (copy.p>=11) 
        {
            Next.SetActive(true); 
            BackNext.SetActive(true);
            BackD.SetActive(false);
        }
        else
        {
            Next.SetActive(false);
            BackNext.SetActive(false);
            BackD.SetActive(true);
        }
        //}
    }

}

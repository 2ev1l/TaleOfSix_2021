using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadID2 : MonoBehaviour
{
    static readonly string GameSave = "ss.json";
    static readonly string LangSave = "ll.json";
    public GameObject Next;
    public GameObject BackNext;
    public GameObject BackD;
    public GameObject ChapterMenu;
    GameObject LangEng;
    GameObject LangRus;
    public GameObject P11;
    public GameObject P12;
    public GameObject P13;
    public GameObject P14;
    public GameObject P15;
    public GameObject P16;
    public GameObject P17;
    public GameObject P18;
    public GameObject P19;
    public GameObject P20;

    public GameObject P11R;
    public GameObject P12R;
    public GameObject P13R;
    public GameObject P14R;
    public GameObject P15R;
    public GameObject P16R;
    public GameObject P17R;
    public GameObject P18R;
    public GameObject P19R;
    public GameObject P20R;
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

        if (copy.p>=11)  P11.SetActive(true); else 
                        P11.SetActive(false);
        
        if (copy.p>=12)  P12.SetActive(true); else 
                        P12.SetActive(false);

        if (copy.p>=13)  P13.SetActive(true); else 
                        P13.SetActive(false);
        
        if (copy.p>=14)  P14.SetActive(true); else 
                        P14.SetActive(false);
        
        if (copy.p>=15)  P15.SetActive(true); else 
                        P15.SetActive(false);
        
        if (copy.p>=16)  P16.SetActive(true); else 
                        P16.SetActive(false);
        
        if (copy.p>=17)  P17.SetActive(true); else 
                        P17.SetActive(false);

        if (copy.p>=18)  P18.SetActive(true); else 
                        P18.SetActive(false);

        if (copy.p>=19)  P19.SetActive(true); else 
                        P19.SetActive(false);

        if (copy.p>=20) P20.SetActive(true); else 
                        P20.SetActive(false);


        if (copy.p>=11)  P11R.SetActive(true); else 
                        P11R.SetActive(false);
        
        if (copy.p>=12)  P12R.SetActive(true); else 
                        P12R.SetActive(false);

        if (copy.p>=13)  P13R.SetActive(true); else 
                        P13R.SetActive(false);
        
        if (copy.p>=14)  P14R.SetActive(true); else 
                        P14R.SetActive(false);
        
        if (copy.p>=15)  P15R.SetActive(true); else 
                        P15R.SetActive(false);
        
        if (copy.p>=16)  P16R.SetActive(true); else 
                        P16R.SetActive(false);
        
        if (copy.p>=17)  P17R.SetActive(true); else 
                        P17R.SetActive(false);

        if (copy.p>=18)  P18R.SetActive(true); else 
                        P18R.SetActive(false);

        if (copy.p>=19)  P19R.SetActive(true); else 
                        P19R.SetActive(false);

        if (copy.p>=20) P20R.SetActive(true); else 
                        P20R.SetActive(false);

        if (copy.p>=21) 
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

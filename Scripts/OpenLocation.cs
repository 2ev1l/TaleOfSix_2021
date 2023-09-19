using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Steamworks;

public class OpenLocation : MonoBehaviour
{
    
    public static GameObject Player1;
    public static GameObject Player2;
    public static GameObject Player3;
    public static GameObject Player4;
    public static GameObject Player5;
    public static GameObject Player6;
    public static GameObject Pos1;
    public static GameObject Pos2;
    public static GameObject Pos3;
    public static GameObject Pos4;
    public static GameObject Pos5;
    public static GameObject Pos6;

    static readonly string GameSave = "ss.json";
    void Awake()
    {
        Player1=GameObject.Find("Player1");
        Player2=GameObject.Find("Player2");
        Player3=GameObject.Find("Player3");
        Player4=GameObject.Find("Player4");
        Player5=GameObject.Find("Player5");
        Player6=GameObject.Find("Player6");
        Player1.SetActive(false);
        Player2.SetActive(false);
        Player3.SetActive(false);
        Player4.SetActive(false);
        Player5.SetActive(false);
        Player6.SetActive(false);
    }
    void Start()
    {   
        SaveData data = new SaveData();
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        Pos1=GameObject.Find("BlockPos1");
        Pos2=GameObject.Find("BlockPos2");
        Pos3=GameObject.Find("BlockPos3");
        Pos4=GameObject.Find("BlockPos4");
        Pos5=GameObject.Find("BlockPos5");
        Pos6=GameObject.Find("BlockPos6");
        if (copy.pos == "1")
        {
        GameObject.Find("BlockPos1").SetActive(false);
        Player1.SetActive(true);
        }
        if (copy.pos == "2")
        {
        GameObject.Find("BlockPos2").SetActive(false);
        Player2.SetActive(true);
        }
        if (copy.pos == "3")
        {
        GameObject.Find("BlockPos3").SetActive(false);
        Player3.SetActive(true);
        }
        if (copy.pos == "4")
        {
        GameObject.Find("BlockPos4").SetActive(false);
        Player4.SetActive(true);
        }
        if (copy.pos == "5")
        {
        GameObject.Find("BlockPos5").SetActive(false);
        Player5.SetActive(true);
        }
        if (copy.pos == "6")
        {
        GameObject.Find("BlockPos6").SetActive(false);
        Player6.SetActive(true);
        
        }
    }
    

}

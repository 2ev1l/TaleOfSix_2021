using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DDONLOAD : MonoBehaviour
{
    static readonly string GameSave = "ss.json";
    public static int CheckAudio;
    public static GameObject Buttons;
    public static GameObject musicPlayer;
    public static GameObject musicPlayer2;
    public static GameObject musicPlayer3;
    public static GameObject soundPlayer;
    public static GameObject soundPlayer2;
    public static GameObject soundPlayer3;
    public static GameObject soundPlayer4;
    public static AudioSource audioData;
    public static AudioSource audioData2;
    public static AudioSource audioData3;
    public static AudioSource soundData;
    public static AudioSource soundData2;
    public static AudioSource soundData3;
    public static AudioSource soundData4;
    void Start()
    {
        if (CheckAudio == 0)
        {
        Buttons = GameObject.Find("Buttons");
        musicPlayer = GameObject.Find("AudioX");
        musicPlayer2 = GameObject.Find("AudioX2");
        musicPlayer3 = GameObject.Find("AudioX3");
        soundPlayer = GameObject.Find("SoundsJump");
        soundPlayer2 = GameObject.Find("SoundsDeath");
        soundPlayer3 = GameObject.Find("SoundsButton");
        soundPlayer4 = GameObject.Find("SoundsButton2");
        audioData = GameObject.Find("AudioX").GetComponent<AudioSource>();
        audioData2 = GameObject.Find("AudioX2").GetComponent<AudioSource>();
        audioData3 = GameObject.Find("AudioX3").GetComponent<AudioSource>();
        soundData = GameObject.Find("SoundsJump").GetComponent<AudioSource>();
        soundData2 = GameObject.Find("SoundsDeath").GetComponent<AudioSource>();
        soundData3 = GameObject.Find("SoundsButton").GetComponent<AudioSource>();
        soundData4 = GameObject.Find("SoundsButton2").GetComponent<AudioSource>();

            SaveData data = new SaveData();
            string json = JsonUtility.ToJson(data);
            string filename = Path.Combine(Application.persistentDataPath, GameSave);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
            if (copy.m1==true)
            {
                audioData.Play();
            }
            if (copy.m2==true)
            {
                audioData2.Play();
            }
            if (copy.m3==true)
            {
                audioData3.Play();
            }

        DontDestroyOnLoad(Buttons);
        DontDestroyOnLoad(audioData);
        DontDestroyOnLoad(musicPlayer); 
        DontDestroyOnLoad(audioData2);
        DontDestroyOnLoad(musicPlayer2); 
        DontDestroyOnLoad(audioData3);
        DontDestroyOnLoad(musicPlayer3); 
        DontDestroyOnLoad(soundPlayer); 
        DontDestroyOnLoad(soundData);
        DontDestroyOnLoad(soundPlayer2); 
        DontDestroyOnLoad(soundData2);
        DontDestroyOnLoad(soundPlayer3); 
        DontDestroyOnLoad(soundData3);
        DontDestroyOnLoad(soundPlayer4); 
        DontDestroyOnLoad(soundData4);
        }
        CheckAudio += 1;
    }
}

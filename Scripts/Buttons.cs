using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Steamworks;

public class Buttons : MonoBehaviour
{
    static readonly string GameSave = "ss.json";
    public static bool is_FS;
    public GameObject Menu;
    public GameObject Credits;
    public GameObject Play;
    public GameObject Settings;
    public GameObject Chapter1;
    public GameObject Chapter2;
    public GameObject Chapter3;
    public GameObject NewGame;
    int cc = 0;
    int cc2 = 0;
    public static bool cs = false;
    public static bool isLoad;
    public static bool isExit;
    public static bool isPressed;

    void Update()
    {
        //Debug.Log(isPressed);
    }

    public void FS()
    {
        is_FS = !is_FS;
        Screen.fullScreen = is_FS;
    }
    
    public void DELETESAVE()
    {
        File.Delete(Path.Combine(Application.persistentDataPath, GameSave));
        Debug.Log(Path.Combine(Application.persistentDataPath, GameSave));
    }
    IEnumerator GameStartAsync() 
    {
        isLoad=true;
        SaveData data = new SaveData()
        {
            deathcount = 0,
            pos = " ",
            scene = " ",
            m1=JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m1,
            m2=JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m2,
            m3=JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m3,
            p=0
        };
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        //if (cs==true)
        if (copy.scene=="1.2")
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("1.2");
            if (asyncLoad.progress == 1f) 
                {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("1.2"));
                yield return null;
                }
            isPressed=false;
        } 
        else
        {
        File.WriteAllText(filename, json);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("1.1");
        if (asyncLoad.progress == 1f) 
        {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("1.1"));
        yield return null;
        }
        isPressed=false;
        }
        //if (cs==false)
    }  

    public void NewGameStart()
    {
        if (!isPressed)
        {
        isPressed=true;
        isExit=true;
        Invoke("NGS",0.66f);
        }
    }
    void NGS()
    {
        StartCoroutine("GameStartAsync");
    }

    IEnumerator MenuStartAsync() 
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu");
        if (asyncLoad.progress == 1f) 
            {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));
            yield return null;
            }   
    }  

    public void ContinueSP1()
    {
        Invoke("CSP1",0.66f);
        Buttons.isExit=true;
        Buttons.isLoad=true;
    }
    void CSP1()
    {
        SceneManager.LoadScene("10.2");
    }
    public void MenuStart()
    {
        isExit=true;
        Time.timeScale=1f;
        Invoke("MSA",0.66f);
        
    }

    public void ContinueSP2()
    {
        Invoke("CSP2",0.66f);
        Buttons.isExit=true;
        Buttons.isLoad=true;
    }
    void CSP2()
    {
        SceneManager.LoadScene("20.2");
    }
    void MSA()
    {
        StartCoroutine("MenuStartAsync");
    }
    public void LoadPressed()
    {   
        if (!isPressed)
        {
        isPressed=true;
        SaveData data = new SaveData();
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        if (copy.scene != " ")
        {
        isLoad=true;
        isExit=true;
        Time.timeScale=1f;
        Invoke("LP",0.66f);
        }
        else
        {
        isLoad=true;
        isExit=true;
        Time.timeScale=1f;
        Invoke("NGS",0.66f);
        }
        }
    }
    void LP()
    {
        SaveData data = new SaveData();
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        SceneManager.LoadScene(copy.scene);
        isPressed=false;
    }
    
    public void ExitPressed()
    {
        SteamAPI.Shutdown();
        Application.Quit();
        SteamAPI.Shutdown();
    }

    public void ButtonSoundPressed()
    {
        DDONLOAD.soundData3.Play();
    }
    
    public void SettingsPressed()
    {
        Menu.SetActive(false);
        Settings.SetActive(true);
    }

    public void PlayPressed()
    {
        Menu.SetActive(false);
        Play.SetActive(true);
    }

    public void CreditsPressed()
    {
        Menu.SetActive(false);
        Credits.SetActive(true);
    }

    public void BackSettingsPressed()
    {
        Settings.SetActive(false);
        Menu.SetActive(true);
    }

    public void BackCreditsPressed()
    {
        Credits.SetActive(false);
        Menu.SetActive(true);
    }

    public void BackPlayPressed()
    {
        Play.SetActive(false);
        Menu.SetActive(true);
    }

    public void BackCH1Pressed()
    {
        Chapter1.SetActive(false);
        Play.SetActive(true);
    }
    public void NextCH1Pressed()
    {
        Chapter1.SetActive(false);
        Chapter2.SetActive(true);
    }

    public void BackCH2Pressed()
    {
        Chapter2.SetActive(false);
        Chapter1.SetActive(true);
    }
    public void NextCH2Pressed()
    {
        Chapter2.SetActive(false);
        Chapter3.SetActive(true);
    }

    public void BackCH3Pressed()
    {
        Chapter3.SetActive(false);
        Chapter2.SetActive(true);
    }

    public void SelectPressed()
    {
        Play.SetActive(false);
        Chapter1.SetActive(true);
    }

    public void GamePos1()
    {
        isExit = true;
        Time.timeScale = 1;
        Invoke("GamePos11",0.66f);
    }
    public void GamePos11()
    {
        isLoad = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveData data = new SaveData()
        {
            deathcount = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).deathcount,
            pos = "1",
            scene = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).scene,
            m1 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m1,
            m2 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m2,
            m3 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m3,
            p = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).p
        };
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        File.WriteAllText(filename, json);
    }
    public void GamePos2()
    {
        isExit = true;
        Time.timeScale = 1;
        Invoke("GamePos22",0.66f);
    }
    public void GamePos22()
    {
        isLoad = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveData data = new SaveData()
        {
            deathcount = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).deathcount,
            pos = "2",
            scene = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).scene,
            m1 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m1,
            m2 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m2,
            m3 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m3,
            p = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).p
        };
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        File.WriteAllText(filename, json);
    }

    public void GamePos3()
    {
        isExit = true;
        Time.timeScale = 1;
        Invoke("GamePos33",0.66f);
    }
    public void GamePos33()
    {
        isLoad = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveData data = new SaveData()
        {
            deathcount = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).deathcount,
            pos = "3",
            scene = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).scene,
            m1 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m1,
            m2 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m2,
            m3 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m3,
            p = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).p
        };
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        File.WriteAllText(filename, json);
    }

    public void GamePos4()
    {
        isExit = true;
        Time.timeScale = 1;
        Invoke("GamePos44",0.66f);
    }
    public void GamePos44()
    {
        isLoad = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveData data = new SaveData()
        {
            deathcount = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).deathcount,
            pos = "4",
            scene = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).scene,
            m1 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m1,
            m2 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m2,
            m3 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m3,
            p = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).p
        };
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        File.WriteAllText(filename, json);
    }

    public void GamePos5()
    {
        isExit = true;
        Time.timeScale = 1;
        Invoke("GamePos55",0.66f);
    }
    public void GamePos55()
    {
        isLoad = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveData data = new SaveData()
        {
            deathcount = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).deathcount,
            pos = "5",
            scene = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).scene,
            m1 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m1,
            m2 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m2,
            m3 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m3,
            p = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).p
        };
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        File.WriteAllText(filename, json);
    }

    public void GamePos6()
    {
        isExit = true;
        Time.timeScale = 1;
        Invoke("GamePos66",0.66f);
    }
    public void GamePos66()
    {
        isLoad = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveData data = new SaveData()
        {
            deathcount = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).deathcount,
            pos = "6",
            scene = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).scene,
            m1 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m1,
            m2 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m2,
            m3 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m3,
            p = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).p
        };
        string json = JsonUtility.ToJson(data);
        string filename = Path.Combine(Application.persistentDataPath, GameSave);
        string jsonFromFile = File.ReadAllText(filename);
        SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
        File.WriteAllText(filename, json);
    }
    
    public void ConfirmPressed()
    {
        NewGame.SetActive(true);
        Play.SetActive(false);
    }

    public void BackConfirmPressed()
    {
        NewGame.SetActive(false);
        Play.SetActive(true);
    }
    void Start()
    {
        is_FS = Screen.fullScreen;
        cc=0;
        cc2=0;
        isPressed=false;
    }

    public void sec1p2()
    {
        if (cc==0)
        {
            cc=1;
        }
        else
        {
            if (cc==1)
            {
                cc=2;
            }
            else
            {
                cc=0;
            }
        }
    }
    public void sec1p1()
    {
        if (cc==2)
        {
            cc=0;
            SceneManager.LoadScene("Secret1");
        }
        else
        {
            cc=0;
        }
    }
    public void secUseless()
    {
        cc=0;
        cc2=0;
    }
    public void sec2p1()
    {
        if (cc2==0)
        {
            cc2=1;
        }
        else
        {
            cc2=0;
        }
    }
    public void sec2p4()
    {
        if (cc2==1)
        {
            cc2=2;
        }
        else
        {
            if (cc2==2)
            {
                cc2=0;
                SceneManager.LoadScene("Secret2");
            }
        }
    }
}

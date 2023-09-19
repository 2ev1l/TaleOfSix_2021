using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeEnd : MonoBehaviour
{
    void Awake()
    {
        GetComponent<AudioSource>().Play();
    }
    void Start()
    {
        Invoke("END",59f);
    }
    void END()
    {
        Buttons.isExit=true;
        Buttons.isLoad=true;
        GetComponent<AudioSource>().Stop();
        Invoke("L",0.66f);
    }
    void L()
    {
        
        SceneManager.LoadScene("TimeEnd");
    }
}

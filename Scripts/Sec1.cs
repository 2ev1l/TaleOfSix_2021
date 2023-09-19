using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sec1 : MonoBehaviour
{

    void Start()
    {
        Invoke("LoadSec1",30f);
    }

    void LoadSec1()
    {
        if (SceneManager.GetActiveScene().name == "1.1")
        {
            SceneManager.LoadScene("SuicideEnd");
        }
    }

}

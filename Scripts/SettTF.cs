using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettTF : MonoBehaviour
{
    public GameObject Settings;
    void Start()
    {   
        Settings.SetActive(true);
        Settings.SetActive(false);
    }
}

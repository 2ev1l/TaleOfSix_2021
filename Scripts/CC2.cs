using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class CC2 : MonoBehaviour
{
    
    string Check;
    IEnumerator MenuStartAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu");
        
        if (asyncLoad.progress == 1f) 
            {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));
            yield return null;
            }   
     }      
    void Awake()
    {
    Check = SceneManager.GetActiveScene().name;
    if (Check == "LOAD")
    {
     StartCoroutine("MenuStartAsync");
    }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FakeStar : MonoBehaviour
{
    bool load;

    void Start()
    {
        
        load = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
    if (other.gameObject.tag == "Player")
    {   
    StarCollect.CollectStar.Play();
    PlayerOnCollision.StarC1+=1;
    Destroy(gameObject);
    }
    }
    void Update()
    {
        //Debug.Log(PlayerOnCollision.StarC1);
        if (PlayerOnCollision.StarC1==8 && !load)
        {
            load = true;
            Buttons.isExit=true;
            Buttons.isLoad=true;
            Invoke("AB",0.66f);
            PlayerOnCollision.StarC1=0;
        }
    }
    void AB()
    {
        SceneManager.LoadScene("Secret3");
    }
}

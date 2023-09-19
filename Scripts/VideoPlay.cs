using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoPlay : MonoBehaviour
{
    bool BGR = false;
    public static VideoPlayer BG;
    bool prepare;
    byte c;
    void Awake()
    {
        c=255;
        BG = GetComponent<VideoPlayer>();
        BG.Prepare();
        InvokeRepeating("isprepare",0f,0.001f);
    }
    void isprepare()
    {
        if (BG.isPrepared && !BGR)
        {
            BG.Play();
            BGR = true;
            InvokeRepeating("color",0f,0.01f);
            CancelInvoke("isprepare");
            //Debug.Log("SDF");
        }
    }
    void color()
    {
        c-=5;
        GetComponent<Image>().color=new Color32(c,c,c,c);
        if (c==0) 
        {
            CancelInvoke("color");
        }
    }
    void Update()
    {
        if (BG.isPrepared && !BGR)
        {
            //BG.Play();
            //BGR = true;
            //Destroy(GetComponent<Image> ());
        }
    }
    
}

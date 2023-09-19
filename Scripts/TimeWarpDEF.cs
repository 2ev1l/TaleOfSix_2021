using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeWarpDEF : MonoBehaviour
{
    public Text display_Text;
    
    void Start()
    {
        InvokeRepeating("Text",0f,0.1f);
    }
    void Text()
    {
        display_Text.text=((400/(1f / Time.unscaledDeltaTime))%3).ToString("0")+"%";
    }

}

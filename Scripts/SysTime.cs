using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
public class SysTime : MonoBehaviour
{
    public Text display_Text;
    public Text display_Text2;
    void Update()
    {
        display_Text.text=System.DateTime.Now.ToString("HH:mm");
        display_Text2.text=System.DateTime.Now.ToString("MM.dd, yyyy");
    }
}

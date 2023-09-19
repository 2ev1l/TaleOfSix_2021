using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Steamworks;
using System.IO;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class Resolution : MonoBehaviour
{
public Dropdown DropDown;
static List<string> m_DropOptions1 = new List<string>() { "1280x720", "1366x768", "1920x1080", ""};
static List<string> m_DropOptions2 = new List<string>() { "1280x720", "1366x768", ""};
static List<string> m_DropOptions3 = new List<string>() { "1280x720",""};
int x;
int y;
void Start()
{
    
    foreach (var res in Screen.resolutions)
    {
        x=res.width; 
        y=res.height;
    }
    if (x*y <2560*1440 && x*y >=1920*1080)
    {
        //Debug.Log("SDA");
        DropDown.ClearOptions();
        DropDown.AddOptions(m_DropOptions1);
    }
    if (x*y <1920*1080 && x*y >=1366*768)
    {
        //Debug.Log("SDA2");
        DropDown.ClearOptions();
        DropDown.AddOptions(m_DropOptions2);
    }
    if (x*y <1366*768)
    {
        //Debug.Log("SDA3");
        DropDown.ClearOptions();
        DropDown.AddOptions(m_DropOptions3);
    }
}
public void DropD2()
{
    if (DropDown.value == 0)
    {
        //Debug.Log("0");
        Screen.SetResolution(1280, 720, Buttons.is_FS);
    }
    if (DropDown.value == 1)
    {
        // Debug.Log("1");
        Screen.SetResolution(1366, 768, Buttons.is_FS);
    }
    if (DropDown.value == 2)
    {
        // Debug.Log("2");
        Screen.SetResolution(1920, 1080, Buttons.is_FS);
    }
    if (DropDown.value == 3)
    {
        //Debug.Log("3");
        Screen.SetResolution(2560, 1440, Buttons.is_FS);
    }
    if (DropDown.value == 4)
    {
        //Debug.Log("4");
    }
}

}

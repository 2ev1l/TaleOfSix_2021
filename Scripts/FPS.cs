using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public int avgFrameRate;
    public Text display_Text;
    void Start()
    {
        InvokeRepeating("FPSSHOW",0f,1f);
    }
    public void FPSSHOW ()
    {
        float current = 0;
        current = current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString();
    }
}


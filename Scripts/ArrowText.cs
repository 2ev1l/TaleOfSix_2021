using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowText : MonoBehaviour
{
    public Text EditText;
    int C;
    void Start()
    {   
        C=-1;
        InvokeRepeating("ET",0f,0.25f);
    }

    void ET()
    {
        C+=1;
        if (C==0)
        EditText.text="";
        if (C==1)
        EditText.text=">";
        if (C==2)
        {
        EditText.text=">>";
        C=-1;
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unpausemusicbag : MonoBehaviour
{
    void Start()
    {
        DDONLOAD.audioData.UnPause();
        DDONLOAD.audioData2.UnPause();
        DDONLOAD.audioData3.UnPause();
    }

}

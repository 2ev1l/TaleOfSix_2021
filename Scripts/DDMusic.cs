using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDMusic : MonoBehaviour
{
    public static AudioSource audioData;
    void Awake()
    {
        audioData = GetComponent<AudioSource>();
    }
}


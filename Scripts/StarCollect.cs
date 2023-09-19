using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollect : MonoBehaviour
{
    public static AudioSource CollectStar;

    void Start()
    {
        CollectStar = GetComponent<AudioSource>();
    }

}

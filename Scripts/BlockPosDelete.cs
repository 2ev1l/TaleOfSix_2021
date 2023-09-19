using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockPosDelete : MonoBehaviour
{
    public GameObject BP1;
    public GameObject BP2;
    public GameObject BP3;
    public GameObject BP4;
    public GameObject BP5;
    public GameObject BP6;
    void Start()
    {
        BP1.SetActive(false);
        BP2.SetActive(false);
        BP3.SetActive(false);
        BP4.SetActive(false);
        BP5.SetActive(false);
        BP6.SetActive(false);
    }
}

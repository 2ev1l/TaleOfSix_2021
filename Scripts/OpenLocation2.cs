using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Steamworks;

public class OpenLocation2 : MonoBehaviour
{
    [SerializeField]
    public GameObject animaS;
    Animator animS;
    public GameObject animaE;
    Animator animE;
    bool as_isDestroyed = false;
    bool ae_isDestroyed = false;
    void Awake()
    {
        animS = animaS.GetComponent<Animator>();
        animE = animaE.GetComponent<Animator>();
        if (Buttons.isLoad)
        {
        animaS.SetActive(true);
        }
        animaE.SetActive(true);
    }
    void Start()
    {
        if (Buttons.isLoad)
        {
            animS.SetBool("BLS", true);
            Buttons.isLoad=false;
        }
        
    }

    void Update()
    {
        if ((animS.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99) && (as_isDestroyed == false) )
            {
                animaS.SetActive(false);
                as_isDestroyed = true;
            }
        if ((animE.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99) && (ae_isDestroyed == false) )
            {
                //animaE.SetActive(false);
                ae_isDestroyed = true;
            }
        if (Buttons.isExit)
        {
            animE.SetBool("BLE", true);
            Buttons.isExit=false;
        }
    }
}

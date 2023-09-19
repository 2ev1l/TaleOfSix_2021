using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay2 : MonoBehaviour
{
    GameObject Player1;
    GameObject Player2;
    GameObject Player3;
    GameObject Player4;
    GameObject Player5;
    GameObject Player6;
    
    void Start()
    {
        Player1=OpenLocation.Player1;
        Player2=OpenLocation.Player2;
        Player3=OpenLocation.Player3;
        Player4=OpenLocation.Player4;
        Player5=OpenLocation.Player5;
        Player6=OpenLocation.Player6;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player1")
        {Player1.transform.parent = transform;}
        
        if(other.gameObject.name == "Player2")
        {Player2.transform.parent = transform;}

        if(other.gameObject.name == "Player3")
        {Player3.transform.parent = transform;}

        if(other.gameObject.name == "Player4")
        {Player4.transform.parent = transform;}

        if(other.gameObject.name == "Player5")
        {Player5.transform.parent = transform;}

        if(other.gameObject.name == "Player6")
        {Player6.transform.parent = transform;}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "Player1")
        {Player1.transform.parent = null;}

        if(other.gameObject.name == "Player2")
        {Player2.transform.parent = null;}

        if(other.gameObject.name == "Player3")
        {Player3.transform.parent = null;}

        if(other.gameObject.name == "Player4")
        {Player4.transform.parent = null;}

        if(other.gameObject.name == "Player5")
        {Player5.transform.parent = null;}

        if(other.gameObject.name == "Player6")
        {Player6.transform.parent = null;}
    }
}

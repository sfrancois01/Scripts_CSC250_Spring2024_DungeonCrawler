using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2Controller : MonoBehaviour
{
    private Player thePlayer;
    public TextMeshPro tm;

    void Start()
    {
        this.thePlayer = new Player(" Arianna ");
        tm.text = this.thePlayer.getName() + " -> " + this.thePlayer.getHP();


    }


    void Update()
    {


    }
}


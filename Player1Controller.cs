using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1Controller : MonoBehaviour
{

    private Player thePlayer;
    public TextMeshPro tm;
    public GameObject destinationGo;
    private float speed = 2.0f;

    void Start()
    {

        this.thePlayer = new Player(" Seth ");
        tm.text = this.thePlayer.getName() + " -> " + this.thePlayer.getHP();


    }


    private void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position, this.destinationGo.transform.position) > 2.0f)
        {
            this.gameObject.transform.position = Vector3.Slerp(this.gameObject.transform.position, this.destinationGo.transform.position, this.speed * Time.deltaTime);
        }

    }
}

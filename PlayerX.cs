using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlayerX : MonoBehaviour
{
    public GameObject NorthExit, SouthExit, EastExit, WestExit;
    private float speed = 3.0f;
   
    void Start()
    {
        //not our first scene
        if(!MySingleton.currentDirection.Equals("?"))
        {
            if(MySingleton.currentDirection.Equals("North"))
            {
                this.gameObject.transform.position = this.SouthExit.transform.position;
            }
        }
    }

    /* private void OnCollisionEnter(Collision collision) 
    {
        print("onCollision");
    }*/


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Door"))
        {
            MySingleton.currentDirection = "North";
           //ditorSceneManager.LoadScene("Scene2");
        }
        

    }
    private void Update()
    {
        
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.NorthExit.transform.position, this.speed * Time.deltaTime);
       
    }
}

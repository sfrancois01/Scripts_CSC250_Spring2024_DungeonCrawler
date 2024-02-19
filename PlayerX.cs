using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlayerX : MonoBehaviour
{
    public GameObject NorthExit, SouthExit, EastExit, WestExit;
    private float speed = 3.0f;
    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;

    private void turnOffExits()
    {
        this.NorthExit.gameObject.SetActive(false);
        this.SouthExit.gameObject.SetActive(false);
        this.EastExit.gameObject.SetActive(false);
        this.WestExit.gameObject.SetActive(false);

    }
    private void turnOnExits()
    {
        this.NorthExit.gameObject.SetActive(true);
        this.SouthExit.gameObject.SetActive(true);
        this.EastExit.gameObject.SetActive(true);
        this.WestExit.gameObject.SetActive(true);

    }

    void Start()
    {
        //not our first scene
        this.turnOffExits();
        if(!MySingleton.currentDirection.Equals("?"))
        {
            if(MySingleton.currentDirection.Equals("North"))
            {
                this.gameObject.transform.position = this.SouthExit.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("South"))
                {
                    this.gameObject.transform.position = this.NorthExit.transform.position;
                }
            else if (MySingleton.currentDirection.Equals("West"))
            {
                this.gameObject.transform.position = this.EastExit.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("East"))
            {
                this.gameObject.transform.position = this.WestExit.transform.position;
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
            EditorSceneManager.LoadScene("DungeonS1");
        }
        else if (other.CompareTag("MiddleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            this.amAtMiddleOfRoom = true;
            speed = 0;
        }
        

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "North";
            this.gameObject.transform.LookAt(this.NorthExit.transform.position);
            speed = 3.0f;

        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "South";
            //this.gameObject.transform.rotation = Vector3.RotateTowards(this.gameObject.transform.position, this.SouthExit.transform.position, 1.5f, this.speed * Time.deltaTime);
            this.gameObject.transform.LookAt(this.SouthExit.transform.position);
            speed = 3.0f;

        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "East";
            this.gameObject.transform.LookAt(this.EastExit.transform.position);
            speed = 3.0f;


        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "West";
            this.gameObject.transform.LookAt(this.WestExit.transform.position);
            speed = 3.0f;


        }
        //Make the player move in the current direction

        if (MySingleton.currentDirection.Equals("North"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.NorthExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("South"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.SouthExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("East"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.EastExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("West"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.WestExit.transform.position, this.speed * Time.deltaTime);
        }
    }
  
}

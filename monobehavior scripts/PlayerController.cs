using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    public GameObject middleOfTheRoom;
    private float speed = 5.0f;
    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;

    private void turnOffExits()
    {
        this.northExit.gameObject.SetActive(false);
        this.southExit.gameObject.SetActive(false);
        this.eastExit.gameObject.SetActive(false);
        this.westExit.gameObject.SetActive(false);

    }
    private void turnOnExits()
    {
        this.northExit.gameObject.SetActive(true);
        this.southExit.gameObject.SetActive(true);
        this.eastExit.gameObject.SetActive(true);
        this.westExit.gameObject.SetActive(true);

    }

    void Start()
    {
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
        this.turnOffExits();
        this.middleOfTheRoom.SetActive(false);


        if (!MySingleton.currentDirection.Equals("?"))
        {
            this.amMoving = true;

            this.middleOfTheRoom.SetActive(true);
            this.amAtMiddleOfRoom = false;

            if (MySingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.gameObject.transform.LookAt(this.northExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.gameObject.transform.LookAt(this.southExit.transform.position);

            }
            else if (MySingleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.gameObject.transform.LookAt(this.westExit.transform.position);

            }
            else if (MySingleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.gameObject.transform.LookAt(this.eastExit.transform.position);

            }
        }
        else
        {
            this.amMoving = false;
            this.amAtMiddleOfRoom = true;
            this.middleOfTheRoom.SetActive(false);
            this.gameObject.transform.position = this.middleOfTheRoom.transform.position;
        }
     
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Door"))
        {
            print("Loading Scene");
            EditorSceneManager.LoadScene("DungeonS1");        

        }
        else if (other.CompareTag("MiddleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            this.middleOfTheRoom.SetActive(false);
            this.turnOnExits();

            print("middle");
            this.amAtMiddleOfRoom = true;
            this.amMoving = false;
            MySingleton.currentDirection = "middle";

        }


    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("north"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);

            if (MySingleton.thePlayer.getCurrentRoom(getCurrentRoom()) = MySingleton.r1)
            {
                setCurrentRoom(getCurrentRoom()) = MySingleton.r2;
            }
            else if (MySingleton.thePlayer.getCurrentRoom(getCurrentRoom()) = MySingleton.r2)
            {
                setCurrentRoom(getCurrentRoom()) = MySingleton.r3;
            }
            else if (MySingleton.thePlayer.getCurrentRoom(getCurrentRoom()) = MySingleton.r3)
            {
                setCurrentRoom(getCurrentRoom()) = MySingleton.r6;
            }
           




        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("south"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            //this.gameObject.transform.rotation = Vector3.RotateTowards(this.gameObject.transform.position, this.SouthExit.transform.position, 1.5f, this.speed * Time.deltaTime);
            this.gameObject.transform.LookAt(this.southExit.transform.position);

            if (MySingleton.thePlayer.getCurrentRoom(getCurrentRoom()) = MySingleton.r6)
            {
                setCurrentRoom(getCurrentRoom()) = MySingleton.r3;
            }
            else if (MySingleton.thePlayer.getCurrentRoom(getCurrentRoom()) = MySingleton.r3)
            {
                setCurrentRoom(getCurrentRoom()) = MySingleton.r2;

            }
            else if(MySingleton.thePlayer.getCurrentRoom(getCurrentRoom()) = MySingleton.r2);
            {
                setCurrentRoom(getCurrentRoom()) = MySingleton.r1;

            }

        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("east"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);

            if (MySingleton.thePlayer.getCurrentRoom(getCurrentRoom()) = MySingleton.r4)
            {
                setCurrentRoom(getCurrentRoom()) = MySingleton.r3;

            }
            else if(MySingleton.thePlayer.getCurrentRoom(getCurrentRoom()) = MySingleton.r3)
            {
                setCurrentRoom(getCurrentRoom()) = MySingleton.r5;

            }


        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("west"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);

            if (MySingleton.thePlayer.getCurrentRoom(getCurrentRoom()) = MySingleton.r5) 
            {
                setCurrentRoom(getCurrentRoom()) = MySingleton.r3;

            }            
            else if(MySingleton.thePlayer.getCurrentRoom(getCurrentRoom()) = MySingleton.r3)
            {
                setCurrentRoom(getCurrentRoom()) = MySingleton.r4;

            }


        }
        //Make the player move in the current direction

        if (MySingleton.currentDirection.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.northExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.southExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.eastExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.westExit.transform.position, this.speed * Time.deltaTime);
        }
    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlayerX : MonoBehaviour
{
    public GameObject NorthExit;
    public GameObject SouthExit;
    public GameObject EastExit;
    public GameObject WestExit;
    public GameObject middleOfTheRoom;
    private float speed = 5.0f;
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
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
        this.turnOffExits();
        this.middleOfTheRoom.SetActive(false);


        if (!MySingleton.currentDirection.Equals("?"))
        {
            this.amMoving = true;

            this.middleOfTheRoom.SetActive(true);
            this.amAtMiddleOfRoom = false;

            if (MySingleton.currentDirection.Equals("North"))
            {
                this.gameObject.transform.position = this.SouthExit.transform.position;
                this.gameObject.transform.LookAt(this.NorthExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("South"))
            {
                this.gameObject.transform.position = this.NorthExit.transform.position;
                this.gameObject.transform.LookAt(this.SouthExit.transform.position);

            }
            else if (MySingleton.currentDirection.Equals("West"))
            {
                this.gameObject.transform.position = this.EastExit.transform.position;
                this.gameObject.transform.LookAt(this.WestExit.transform.position);

            }
            else if (MySingleton.currentDirection.Equals("East"))
            {
                this.gameObject.transform.position = this.WestExit.transform.position;
                this.gameObject.transform.LookAt(this.EastExit.transform.position);

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
    /*
    public void getOpposite(MySingleton.Direction)
    {
        if (MySingleton.currentDirection = "North")
            return MySingleton.oppositte = "South";
        else if (MySingleton.currentDirection = "South")
            return MySingleton.oppositte = "North";
        else if (MySingleton.currentDirection = "East")
            return MySingleton.oppositte = "West";
        else if (MySingleton.currentDirection = "West")
            return MySingleton.oppositte = "East";
        else if (MySingleton.oppositte = "?")
            return MySingleton.oppositte = "?";

        return null;
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);

        if (other.CompareTag("Door"))
        {
            print("Loading Scene");
            /* if(MySingleton.oppositte = MySingleto
                {

                }
                else
                {
                    EditorSceneManager.LoadScene(MySingleton.theRoom[1]);
                    //EditorSceneManager.LoadScene("DungeonS1");
                }*/
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
        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving && MySingleton.theCurrentRoom.isOpenDoor("North"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "North";
            this.gameObject.transform.LookAt(this.NorthExit.transform.position);
            

        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving && MySingleton.theCurrentRoom.isOpenDoor("South"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "South";
            //this.gameObject.transform.rotation = Vector3.RotateTowards(this.gameObject.transform.position, this.SouthExit.transform.position, 1.5f, this.speed * Time.deltaTime);
            this.gameObject.transform.LookAt(this.SouthExit.transform.position);
            

        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving && MySingleton.theCurrentRoom.isOpenDoor("East"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "East";
            this.gameObject.transform.LookAt(this.EastExit.transform.position);
           


        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving && MySingleton.theCurrentRoom.isOpenDoor("West"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "West";
            this.gameObject.transform.LookAt(this.WestExit.transform.position);
            


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

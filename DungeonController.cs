using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject[] closedDoors;

    // Start is called before the first frame update
    private string mapIndexToStringForExit(int index)
    {
        if (index == 0)
        {
            return "North";
        }
        else if (index == 1)
        {
            return "South";
        }
        else if (index == 2)
        {
            return "East";
        }
        else if (index == 3)
        {
            return "West";
        }
        else
        {
            return "?";
        }
    }
    void Start()
    {
        MySingleton.theCurrentRoom = new Room("a room");
        MySingleton.addRoom(MySingleton.theCurrentRoom); 

        int openDoorIndex = Random.Range(0, 4);
        this.closedDoors[openDoorIndex].SetActive(false); 
        MySingleton.theCurrentRoom.setOpenDoor(this.mapIndexToStringForExit(openDoorIndex));

        for (int i = 0; i < 4; i++)
        {
  
            if (openDoorIndex != i)
            {
               
                int coinFlip = Random.Range(0, 2);
                if (coinFlip == 1)
                {
                   
                    this.closedDoors[i].SetActive(false); 
                    MySingleton.theCurrentRoom.setOpenDoor(this.mapIndexToStringForExit(i));

                }
            }
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

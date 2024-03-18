using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string name;
    private Room currentRoom;
    public string score = 0;

    public Player(string name)
    {
        this.name = name;
        this.currentRoom = null;
    }

    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }

    public void setCurrentRoom(Room r)
    {
        this.currentRoom = r; 
    }

    public void setScore(string score) 
    {
        this.score = "Score: " + score.ToString();
    }
}
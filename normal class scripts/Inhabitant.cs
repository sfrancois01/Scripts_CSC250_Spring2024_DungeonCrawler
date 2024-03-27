using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inhabitant 
{
    protected string name;
    protected Room currentRoom;
    protected int health;
    protected int Armor;

    public Inhabitant(string name)
    {
        this.name = name;
        this.currentRoom = null;
        this.health = 10;
    }

    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }

    public void setCurrentRoom(Room r)
    {
        this.currentRoom = r;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string name;
    private int hp;

    public Player(string name)
    {
        this.hp = (int)Random.Range(10.0f, 20.0f);
        this.name = name;

    }
    public string getName()
    {
        return this.name;
    }

    public int getHP()
    {
        return this.hp;
    }

    public void display()
    {
        Debug.Log(this.name + " -> HP: " + this.hp);
    }
}

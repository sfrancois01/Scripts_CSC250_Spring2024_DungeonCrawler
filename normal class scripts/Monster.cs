using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster
{
    protected string name;
    protected int health;

    public Monster(int health)
    {
       
        this.health = 5;
        this.name = "monster";

    }
}

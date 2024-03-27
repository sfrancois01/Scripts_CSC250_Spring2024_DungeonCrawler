using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Inhabitant
{

    public Player(string name) : base(name)
    {
        Player Seth = new Player(name);

    }

    public void getHealth(Player player)
    {
        player.health = 50;

    }


}
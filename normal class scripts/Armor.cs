using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Inhabitant
{
    public Armor(int player) : base(health)
    {
        player.armor = armor + 10
    }
}

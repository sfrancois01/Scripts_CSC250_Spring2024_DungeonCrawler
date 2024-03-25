using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPellet : Pellet
{
 public ArmorPellet() : base(1)
    {
        base.name = base.name + " : ArmorPellet";
    }
}

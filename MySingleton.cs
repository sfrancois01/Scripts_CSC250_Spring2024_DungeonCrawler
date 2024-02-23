using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton 
{
    public static string currentDirection = "?";
    private static Room[] theRooms = new Room[100];
    private static int numRooms = 0;

    public static void addRoom(Room  r)
    {
        MySingleton.theRooms[numRooms] = r;
        MySingleton.numRooms++;
    }

    
}

﻿using UnityEngine;
using System.Collections;

public class gVar : MonoBehaviour {
    
    public static string player1 = "Green";
    public static string player2 = "Red";
    public static string player3 = "Purple";
    public static string player4 = "Blue";
    public static string direction = "up";

    public static bool player1Exists = false;
    public static bool player2Exists = false;
    public static bool player3Exists = false;
    public static bool player4Exists = false;

    public static int level = 1;
    public static int currentLocation = 1;
    public static int readyPlayers = 0;
    public static int requiredReadyPlayers = 0;

    public static Vector2 location1, location2, location3, location4;

}

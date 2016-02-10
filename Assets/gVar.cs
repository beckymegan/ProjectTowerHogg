using UnityEngine;
using System.Collections;

public class gVar : MonoBehaviour
{

    public static string player1 = "Grey";
    public static string player2 = "Grey";
    public static string player3 = "Grey";
    public static string player4 = "Grey";
    public static string direction = "up";

    public static bool player1Exists = false;
    public static bool player2Exists = false;
    public static bool player3Exists = false;
    public static bool player4Exists = false;

    public static bool justOpened = true;
    public static bool pauseMenuOpen = false;

    public static int level = 1;
    public static int currentLocation = 1;
    public static int readyPlayers = 0;
    public static int requiredReadyPlayers = 0;
    public static int numberPlayers = 0;

    public static int optionTime = 0;
    public static int readyCounter = 0;

    public static int gameWidth;
    public static int gameHeight;

    public static int greenShots = 0;
    public static int redShots = 0;
    public static int blueShots = 0;
    public static int purpleShots = 0;

    public static int greenShotsStored = 0;
    public static int redShotsStored = 0;
    public static int blueShotsStored = 0;
    public static int purpleShotsStored = 0;

    public static float volume = 1f;
    public static float musicVolume = 1f;

    public static Vector2 location1, location2, location3, location4;
    
    public static void resetVars()//reset all gVars
    {
        player1 = "Grey";
        player2 = "Grey";
        player3 = "Grey";
        player4 = "Grey";
        direction = "up";

        player1Exists = false;
        player2Exists = false;
        player3Exists = false;
        player4Exists = false;

        level = 1;
        currentLocation = 1;
        readyPlayers = 0;
        requiredReadyPlayers = 0;
        numberPlayers = 0;

        greenShots = 0;
        redShots = 0;
        blueShots = 0;
        purpleShots = 0;
    }

    public static void softReset()
    {
        greenShots = greenShotsStored;
        redShots = redShotsStored;
        blueShots = blueShotsStored;
        purpleShots = purpleShotsStored;
    }
}

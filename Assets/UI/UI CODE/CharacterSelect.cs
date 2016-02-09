using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharacterSelect : MonoBehaviour
{
    public int playerNumber;
    public Sprite oriSprite, selectedSprite;
    public AudioClip switchCharacter, selectCharacter;
    public CanvasGroup playButtonCanvas;
    public EventSystem eventSystem;
    public GameObject first;

    private int locationP1 = 1, locationP2 = 1, locationP3 = 1, locationP4 = 1;
    private int selectButtonPress = 1;//last player to press start
    private bool isReadyToPlay = false;
    private bool startGame = false;
    private bool changedMind = false; //prevents infinite changes to readyPlayers if a player selects a character then moves again
    private int menuCounter = 0;
    private int greenPlayers, redPlayers, bluePlayers, purplePlayers;
    bool p1wasTrue = false, p2wasTrue = false, p3wasTrue = false, p4wasTrue = false;

    private AudioSource audio;

    void Start()
    {
        Time.timeScale = 1;
        audio = GetComponent<AudioSource>();
        playButtonCanvas.interactable = false;
        eventSystem.SetSelectedGameObject(first);
    }

    void Update()
    {
        gVar.optionTime++;//prevent inputs for several frames after closing menus

        

        if (Time.timeScale == 1 && gVar.optionTime > 25)
        {
            gVar.readyCounter++;

            checkPlayers();
            menuCounter++;//increase counter

            //register color changes by left/right movement (MUST BE BEFORE CHARACTER SELECTION)
            if (gVar.player1Exists && (Input.GetAxis("Horizontal1") > 0 || Input.GetAxis("Horizontal1") < 0 || Input.GetButton("Back1")) && p1wasTrue == true)
            {
                p1wasTrue = false;
                setPlayerColor(1, -1);
            }
            else if (gVar.player2Exists && (Input.GetAxis("Horizontal2") > 0.5f || Input.GetAxis("Horizontal2") < -0.5f || Input.GetButton("Back2")) && p2wasTrue == true)
            {
                p2wasTrue = false;
                setPlayerColor(2, -1);
            }
            else if (gVar.player3Exists && (Input.GetAxis("Horizontal3") > 0.5f || Input.GetAxis("Horizontal3") < -0.5f || Input.GetButton("Back3")) && p3wasTrue == true)
            {
                p3wasTrue = false;
                setPlayerColor(3, -1);
            }
            else if (gVar.player4Exists && (Input.GetAxis("Horizontal4") > 0.5f || Input.GetAxis("Horizontal4") < -0.5f || Input.GetButton("Back4")) && p4wasTrue == true)
            {
                p4wasTrue = false;
                setPlayerColor(4, -1);
            }



            //player 1
            if (playerNumber == 1 && gVar.player1Exists)
            {
                if (Input.GetAxisRaw("Horizontal1") > 0 && menuCounter >= 20)
                {
                    menuCounter = 0;//reset counter

                    //play switching sound
                    audio.PlayOneShot(switchCharacter, 1f);

                    isReadyToPlay = false;//moved selection therefore not ready to play
                    this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                    locationP1++;
                    if (locationP1 > 4) { locationP1 = 1; }

                }
                if (Input.GetAxisRaw("Horizontal1") < 0 && menuCounter >= 20)
                {
                    menuCounter = 0;//reset counter

                    //play switching sound
                    audio.PlayOneShot(switchCharacter, 1f);

                    isReadyToPlay = false;//moved selection therefore not ready to play
                    this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                    locationP1--;
                    if (locationP1 < 1) { locationP1 = 4; }
                }

                //set character depending on location of player
                if (locationP1 == 1)
                {
                    gVar.player1 = "Green";
                    this.transform.position = new Vector2(-6f, this.transform.position.y);
                }
                else if (locationP1 == 2)
                {
                    gVar.player1 = "Red";
                    this.transform.position = new Vector2(-2f, this.transform.position.y);
                }
                else if (locationP1 == 3)
                {
                    gVar.player1 = "Blue";
                    this.transform.position = new Vector2(2f, this.transform.position.y);
                }
                else if (locationP1 == 4)
                {
                    gVar.player1 = "Purple";
                    this.transform.position = new Vector2(6f, this.transform.position.y);
                }

                //select character "i'm ready to play"
                if (Input.GetButtonDown("Jump1") && isReadyToPlay == false)
                {
                    p1wasTrue = true;
                    eventSystem.SetSelectedGameObject(first); //reset button
                    gVar.readyCounter = 0;
                    setPlayerColor(1, 1);

                    //play select sound
                    audio.PlayOneShot(selectCharacter, 1f);

                    this.GetComponent<SpriteRenderer>().sprite = selectedSprite;
                    isReadyToPlay = true; changedMind = true;
                    gVar.readyPlayers++; //increase number of players that are confirmed "ready" to start game
                }
                else if (isReadyToPlay == false)
                {
                    this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                    if (changedMind == true)
                    {
                        gVar.readyPlayers--; //decrease number of players that are confirmed "ready" to start game
                        changedMind = false;
                    }
                }
            }
            //Player 2
            else if (playerNumber == 2 && gVar.player2Exists)
            {
                if (Input.GetAxis("Horizontal2") == 1 && menuCounter >= 20)
                {
                    menuCounter = 0;//reset counter

                    //play switching sound
                    audio.PlayOneShot(switchCharacter, 1f);

                    isReadyToPlay = false;//moved selection therefore not ready to play
                    this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                    locationP2++;
                    if (locationP2 > 4) { locationP2 = 1; }

                }
                else if (Input.GetAxis("Horizontal2") == -1 && menuCounter >= 20)
                {
                    menuCounter = 0;//reset counter

                    //play switching sound
                    audio.PlayOneShot(switchCharacter, 1f);

                    isReadyToPlay = false;//moved selection therefore not ready to play
                    this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                    locationP2--;
                    if (locationP2 < 1) { locationP2 = 4; }
                }

                if (locationP2 == 1)
                {
                    gVar.player2 = "Green";
                    this.transform.position = new Vector2(-6f, this.transform.position.y);
                }
                else if (locationP2 == 2)
                {
                    gVar.player2 = "Red";
                    this.transform.position = new Vector2(-2f, this.transform.position.y);
                }
                else if (locationP2 == 3)
                {
                    gVar.player2 = "Blue";
                    this.transform.position = new Vector2(2f, this.transform.position.y);
                }
                else if (locationP2 == 4)
                {
                    gVar.player2 = "Purple";
                    this.transform.position = new Vector2(6f, this.transform.position.y);
                }

                //select character "i'm ready to play"
                if (Input.GetButtonDown("Jump2") && isReadyToPlay == false)
                {
                    p2wasTrue = true;
                    eventSystem.SetSelectedGameObject(first); //reset button
                    gVar.readyCounter = 0;
                    setPlayerColor(2, 1);

                    //play select sound
                    audio.PlayOneShot(selectCharacter, 1f);

                    this.GetComponent<SpriteRenderer>().sprite = selectedSprite;
                    isReadyToPlay = true; changedMind = true;
                    gVar.readyPlayers++; //increase number of players that are confirmed "ready" to start game
                }
                else if (isReadyToPlay == false)
                {
                    this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                    if (changedMind == true)
                    {
                        gVar.readyPlayers--; //decrease number of players that are confirmed "ready" to start game
                        changedMind = false;
                    }
                }
            }
            //player 3
            else if (playerNumber == 3 && gVar.player3Exists)
            {
                if (Input.GetAxis("Horizontal3") == 1 && menuCounter >= 20)
                {
                    menuCounter = 0;//reset counter

                    //play switching sound
                    audio.PlayOneShot(switchCharacter, 1f);

                    isReadyToPlay = false;//moved selection therefore not ready to play
                    this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                    locationP3++;
                    if (locationP3 > 4) { locationP3 = 1; }

                }
                else if (Input.GetAxis("Horizontal3") == -1 && menuCounter >= 20)
                {
                    menuCounter = 0;//reset counter

                    //play switching sound
                    audio.PlayOneShot(switchCharacter, 1f);

                    isReadyToPlay = false;//moved selection therefore not ready to play
                    this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                    locationP3--;
                    if (locationP3 < 1) { locationP3 = 4; }
                }

                if (locationP3 == 1)
                {
                    gVar.player3 = "Green";
                    this.transform.position = new Vector2(-6f, this.transform.position.y);
                }
                else if (locationP3 == 2)
                {
                    gVar.player3 = "Red";
                    this.transform.position = new Vector2(-2f, this.transform.position.y);
                }
                else if (locationP3 == 3)
                {
                    gVar.player3 = "Blue";
                    this.transform.position = new Vector2(2f, this.transform.position.y);
                }
                else if (locationP3 == 4)
                {
                    gVar.player3 = "Purple";
                    this.transform.position = new Vector2(6f, this.transform.position.y);
                }

                //select character "i'm ready to play"
                if (Input.GetButtonDown("Jump3") && isReadyToPlay == false)
                {
                    p3wasTrue = true;
                    eventSystem.SetSelectedGameObject(first); //reset button
                    gVar.readyCounter = 0;
                    setPlayerColor(3, 1);

                    //play select sound
                    audio.PlayOneShot(selectCharacter, 1f);

                    this.GetComponent<SpriteRenderer>().sprite = selectedSprite;
                    isReadyToPlay = true; changedMind = true;
                    gVar.readyPlayers++; //increase number of players that are confirmed "ready" to start game
                }
                else if (isReadyToPlay == false)
                {
                    this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                    if (changedMind == true)
                    {
                        gVar.readyPlayers--; //decrease number of players that are confirmed "ready" to start game
                        changedMind = false;
                    }
                }
            }
            //player 4
            else if (playerNumber == 4 && gVar.player4Exists)
            {
                if (Input.GetAxis("Horizontal4") == 1 && menuCounter >= 20)
                {
                    menuCounter = 0;//reset counter

                    //play switching sound
                    audio.PlayOneShot(switchCharacter, 1f);

                    isReadyToPlay = false;//moved selection therefore not ready to play
                    this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                    locationP4++;
                    if (locationP4 > 4) { locationP4 = 1; }

                }
                else if (Input.GetAxis("Horizontal4") == -1 && menuCounter >= 20)
                {
                    menuCounter = 0;//reset counter

                    //play switching sound
                    audio.PlayOneShot(switchCharacter, 1f);

                    isReadyToPlay = false;//moved selection therefore not ready to play
                    this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                    locationP4--;
                    if (locationP4 < 1) { locationP4 = 4; }
                }

                if (locationP4 == 1)
                {
                    gVar.player4 = "Green";
                    this.transform.position = new Vector2(-6f, this.transform.position.y);
                }
                else if (locationP4 == 2)
                {
                    gVar.player4 = "Red";
                    this.transform.position = new Vector2(-2f, this.transform.position.y);
                }
                else if (locationP4 == 3)
                {
                    gVar.player4 = "Blue";
                    this.transform.position = new Vector2(2f, this.transform.position.y);
                }
                else if (locationP4 == 4)
                {
                    gVar.player4 = "Purple";
                    this.transform.position = new Vector2(6f, this.transform.position.y);
                }

                //select character "i'm ready to play"
                if (Input.GetButtonDown("Jump4") && isReadyToPlay == false)
                {
                    p4wasTrue = true;
                    eventSystem.SetSelectedGameObject(first); //reset button
                    gVar.readyCounter = 0;
                    setPlayerColor(4, 1);

                    //play select sound
                    audio.PlayOneShot(selectCharacter, 1f);

                    this.GetComponent<SpriteRenderer>().sprite = selectedSprite;
                    isReadyToPlay = true; changedMind = true;
                    gVar.readyPlayers++; //increase number of players that are confirmed "ready" to start game
                }
                else if (isReadyToPlay == false)
                {
                    this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                    if (changedMind == true)
                    {
                        gVar.readyPlayers--; //decrease number of players that are confirmed "ready" to start game
                        changedMind = false;
                    }
                }
            }

            //store which button was last selected
            if (Input.GetButtonDown("Jump1")) { selectButtonPress = 1; }
            else if (Input.GetButtonDown("Jump2")) { selectButtonPress = 2; }
            else if (Input.GetButtonDown("Jump3")) { selectButtonPress = 3; }
            else if (Input.GetButtonDown("Jump4")) { selectButtonPress = 4; }
            readyToPlay();
        }
    }

    void readyToPlay()
    {
        if (gVar.readyPlayers == gVar.requiredReadyPlayers && gVar.requiredReadyPlayers > 1 && isReadyToPlay == true && gVar.pauseMenuOpen == false && multipleCharacters()) //more than one player have joined and all joined players are ready to play
        {
            playButtonCanvas.interactable = true;
        }
        else
        {
            playButtonCanvas.interactable = false;
        }
    }

    public void setPlayerColor(int playerNumber, int incDec)
    {
        if (playerNumber == 1)
        {
            if (gVar.player1 == "Green")
            {
                gVar.greenShots += incDec;
            }
            else if (gVar.player1 == "Red")
            {
                gVar.redShots += incDec;
            }
            else if (gVar.player1 == "Blue")
            {
                gVar.blueShots += incDec;
            }
            else if (gVar.player1 == "Purple")
            {
                gVar.purpleShots += incDec;
            }
        }
        else if (playerNumber == 2)
        {
            if (gVar.player2 == "Green")
            {
                gVar.greenShots += incDec;
            }
            else if (gVar.player2 == "Red")
            {
                gVar.redShots += incDec;
            }
            else if (gVar.player2 == "Blue")
            {
                gVar.blueShots += incDec;
            }
            else if (gVar.player2 == "Purple")
            {
                gVar.purpleShots += incDec;
            }
        }
        else if (playerNumber == 3)
        {
            if (gVar.player3 == "Green")
            {
                gVar.greenShots += incDec;
            }
            else if (gVar.player3 == "Red")
            {
                gVar.redShots += incDec;
            }
            else if (gVar.player3 == "Blue")
            {
                gVar.blueShots += incDec;
            }
            else if (gVar.player3 == "Purple")
            {
                gVar.purpleShots += incDec;
            }
        }
        else if (playerNumber == 4)
        {
            if (gVar.player4 == "Green")
            {
                gVar.greenShots += incDec;
            }
            else if (gVar.player4 == "Red")
            {
                gVar.redShots += incDec;
            }
            else if (gVar.player4 == "Blue")
            {
                gVar.blueShots += incDec;
            }
            else if (gVar.player4 == "Purple")
            {
                gVar.purpleShots += incDec;
            }
        }
    }

    //check to see if there are multiple colors ready to play, eg can't start game with just greens
    bool multipleCharacters()
    {
        if (gVar.readyPlayers == 2 && (gVar.greenShots > 1 || gVar.redShots > 1 || gVar.blueShots > 1 || gVar.purpleShots > 1))
        {
            return false;
        }
        else if (gVar.readyPlayers == 3 && (gVar.greenShots > 2 || gVar.redShots > 2 || gVar.blueShots > 2 || gVar.purpleShots > 2))
        {
            return false;
        }
        else if (gVar.readyPlayers == 4 && (gVar.greenShots > 3 || gVar.redShots > 3 || gVar.blueShots > 3 || gVar.purpleShots > 3))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //check to make sure controller clicking play is a player that's in the game (and ready) and then load level
    public void playGame()
    {
        Update();

        //check to see which character pressed the play button and whether they exist as a player
        if (selectButtonPress == 1 && gVar.player1Exists == true)
        {
            startGame = true;
        }
        else if (selectButtonPress == 2 && gVar.player2Exists == true)
        {
            startGame = true;
        }
        else if (selectButtonPress == 3 && gVar.player3Exists == true)
        {
            startGame = true;
        }
        else if (selectButtonPress == 4 && gVar.player4Exists == true)
        {
            startGame = true;
        }

        //load level if player that pressed the button also exists
        if (startGame == true)
        {
            if (gVar.currentLocation == 1)
            {
                SceneManager.LoadScene("Level 1");
            }
            else if (gVar.currentLocation == 2)
            {
                SceneManager.LoadScene("Level 2");
            }
            else if (gVar.currentLocation == 3)
            {
                SceneManager.LoadScene("Level 3");
            }
            else if (gVar.currentLocation == 4)
            {
                SceneManager.LoadScene("Level 4");
            }
            else if (gVar.currentLocation == 5)
            {
                SceneManager.LoadScene("Level 5");
            }
        }
    }

    //if player doesn't exist, remove controller/keyboard sprite, otherwise give them correct sprite
    void checkPlayers()
    {
        if (playerNumber == 1 && gVar.player1Exists == false)
        {
            this.GetComponent<SpriteRenderer>().sprite = null;
        }
        if (playerNumber == 2 && gVar.player2Exists == false)
        {
            this.GetComponent<SpriteRenderer>().sprite = null;
        }
        if (playerNumber == 3 && gVar.player3Exists == false)
        {
            this.GetComponent<SpriteRenderer>().sprite = null;
        }
        if (playerNumber == 4 && gVar.player4Exists == false)
        {
            this.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    //reset player to beginning (eg just joined game, green character)
    public void restart()
    {
        if (playerNumber == 1)
        {
            locationP1 = 1;
        }
        else if (playerNumber == 2)
        {
            locationP2 = 1;
        }
        else if (playerNumber == 3)
        {
            locationP3 = 1;
        }
        else if (playerNumber == 4)
        {
            locationP4 = 1;
        }
        isReadyToPlay = false;
        changedMind = false;
    }

    //return if a player was ready to plays
    public bool getIsReady()
    {
        return isReadyToPlay;
    }

}

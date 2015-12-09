﻿using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour
{
    public CharacterSelectLogic logic;
    public int playerNumber;
    public Sprite oriSprite, selectedSprite;

    private int locationP1 = 1, locationP2 = 1, locationP3 = 1, locationP4 = 1;
    private bool isReadyToPlay = false;
    private bool changedMind = false; //prevents infinite changes to readyPlayers if a player selects a character then moves again

    void Start()
    {
    }

    void Update()
    {
        checkPlayers();

        if (gVar.readyPlayers == gVar.requiredReadyPlayers && gVar.requiredReadyPlayers > 1 && Input.GetButton("GSelect")) //more than one player have joined and all joined players are ready to play
        {
            if (gVar.currentLocation == 1)
            {
                Application.LoadLevel("Level 1");
            }
            else if (gVar.currentLocation == 2)
            {
                Application.LoadLevel("Level 2");
            }
            else if (gVar.currentLocation == 3)
            {
                Application.LoadLevel("Level 3");
            }
            else if (gVar.currentLocation == 4)
            {
                Application.LoadLevel("Level 4");
            }
            else if (gVar.currentLocation == 5)
            {
                Application.LoadLevel("Level 5");
            }
        }

        //player 1
        if (playerNumber == 1 && gVar.player1Exists)
        {
            if (Input.GetButtonDown("Horizontal1") && Input.GetAxisRaw("Horizontal1") == 1)
            {
                isReadyToPlay = false;//moved selection therefore not ready to play
                this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                locationP1++;
                if (locationP1 > 4) { locationP1 = 1; }

            }
            else if (Input.GetButtonDown("Horizontal1") && Input.GetAxisRaw("Horizontal1") == -1)
            {
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
            if (Input.GetButton("Jump1") && isReadyToPlay == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = selectedSprite;
                isReadyToPlay = true; changedMind = true;
                gVar.readyPlayers++; //increase number of players that are confirmed "ready" to start game
            }
            else if (isReadyToPlay == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                if (changedMind == true){
                    gVar.readyPlayers--; //decrease number of players that are confirmed "ready" to start game
                    changedMind = false;
                }
            }
        }
        //Player 2
        else if (playerNumber == 2 && gVar.player2Exists)
        {
            if (Input.GetButtonDown("Horizontal2Menu") && Input.GetAxisRaw("Horizontal2Menu") == 1)
            {
                isReadyToPlay = false;//moved selection therefore not ready to play
                this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                locationP2++;
                if (locationP2 > 4) { locationP2 = 1; }

            }
            else if (Input.GetButtonDown("Horizontal2Menu") && Input.GetAxisRaw("Horizontal2Menu") == -1)
            {
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
            if (Input.GetButton("Jump2") && isReadyToPlay == false)
            {
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
            if (Input.GetButtonDown("Horizontal3Menu") && Input.GetAxisRaw("Horizontal3Menu") == 1)
            {
                isReadyToPlay = false;//moved selection therefore not ready to play
                this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                locationP3++;
                if (locationP3 > 4) { locationP3 = 1; }

            }
            else if (Input.GetButtonDown("Horizontal3Menu") && Input.GetAxisRaw("Horizontal3Menu") == -1)
            {
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
            if (Input.GetButton("Jump3") && isReadyToPlay == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = selectedSprite;
                isReadyToPlay= true; changedMind = true;
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
            if (Input.GetButtonDown("Horizontal4Menu") && Input.GetAxisRaw("Horizontal4Menu") == 1)
            {
                isReadyToPlay = false;//moved selection therefore not ready to play
                this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                locationP4++;
                if (locationP4 > 4) { locationP4 = 1; }

            }
            else if (Input.GetButtonDown("Horizontal4Menu") && Input.GetAxisRaw("Horizontal4Menu") == -1)
            {
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
            if (Input.GetButton("Jump4") && isReadyToPlay == false)
            {
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

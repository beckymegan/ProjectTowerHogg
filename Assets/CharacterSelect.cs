using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {

    public string name;
    public int playerNumber;
    public Sprite oriSprite, selectedSprite;
    private int locationP1, locationP2;
    private static bool[] readyToPlay = { false, false };


    void Start()
    {
        readyToPlay[0] = false; readyToPlay[1] = false;
        this.GetComponent<SpriteRenderer>().sprite = oriSprite;
        locationP1 = 1;
        locationP2 = 1;
    }

    void Update()
    {
        if (readyToPlay[0] == true && readyToPlay[1]== true)
        {
            if(gVar.currentLocation == 1)
            {

            }
            else if (gVar.currentLocation == 2)
            {

            }
            else if (gVar.currentLocation == 3)
            {

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

        if (playerNumber == 1)
        {
            if (Input.GetButtonDown("Horizontal1") && Input.GetAxisRaw("Horizontal1") == 1)
            {
                readyToPlay[0] = false;//moved selection therefore not ready to play
                this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                locationP1++;
                if (locationP1 > 4) { locationP1 = 1; }

            }
            else if (Input.GetButtonDown("Horizontal1") && Input.GetAxisRaw("Horizontal1") == -1)
            {
                readyToPlay[0] = false;//moved selection therefore not ready to play
                this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                locationP1--;
                if (locationP1 < 1) { locationP1 = 4; }
            }

            if (locationP1 == 1)
            {
                gVar.player1 = "Green";
                this.transform.position = new Vector2(-6f, -2.5f);
            }
            else if (locationP1 == 2)
            {
                gVar.player1 = "Red";
                this.transform.position = new Vector2(-2f, -2.5f);
            }
            else if (locationP1 == 3)
            {
                gVar.player1 = "Blue";
                this.transform.position = new Vector2(2f, -2.5f);
            }
            else if (locationP1 == 4)
            {
                gVar.player1 = "Purple";
                this.transform.position = new Vector2(6f, -2.5f);
            }

            //select character "i'm ready to play"
            if (Input.GetButtonDown("Jump1") && readyToPlay[0]== false)
            {
                this.GetComponent<SpriteRenderer>().sprite = selectedSprite;
                readyToPlay[0] = true;
            }
        }
        //Player 2
        else if (playerNumber == 2)
        {
            if (Input.GetButtonDown("Horizontal2Menu") && Input.GetAxisRaw("Horizontal2Menu") == 1)
            {
                readyToPlay[1] = false;//moved selection therefore not ready to play
                this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                locationP2++;
                if (locationP2 > 4) { locationP2 = 1; }

            }
            else if (Input.GetButtonDown("Horizontal2Menu") && Input.GetAxisRaw("Horizontal2Menu") == -1)
            {
                readyToPlay[1] = false;//moved selection therefore not ready to play
                this.GetComponent<SpriteRenderer>().sprite = oriSprite;
                locationP2--;
                if (locationP2 < 1) { locationP2 = 4; }
            }

            if (locationP2 == 1)
            {
                gVar.player2 = "Green";
                this.transform.position = new Vector2(-6f, -1);
            }
            else if (locationP2 == 2)
            {
                gVar.player2 = "Red";
                this.transform.position = new Vector2(-2f, -1);
            }
            else if (locationP2 == 3)
            {
                gVar.player2 = "Blue";
                this.transform.position = new Vector2(2f, -1);
            }
            else if (locationP2 == 4)
            {
                gVar.player2 = "Purple";
                this.transform.position = new Vector2(6f, -1);
            }

            //select character "i'm ready to play"
            if (Input.GetButtonDown("Jump2") && readyToPlay[1] == false)
            {
                this.GetComponent<SpriteRenderer>().sprite = selectedSprite;
                readyToPlay[1] = true;
            }
        }
    }

    public string getName()
    {
        return name;
    }
}

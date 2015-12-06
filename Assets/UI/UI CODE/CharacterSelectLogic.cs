using UnityEngine;
using System.Collections;

public class CharacterSelectLogic : MonoBehaviour {
    
    public CharacterSelect characterSelectCode;
    public GameObject player1, player2, player3, player4;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //join game
        if (Input.GetButtonUp("Jump1") && gVar.player1Exists == false)
        {
            gVar.player1Exists = true;
            gVar.requiredReadyPlayers++; //increase number of players that need to be confirmed "ready" to start game
            player1.GetComponent<CharacterSelect>().restart();
        }
        else if (Input.GetButtonUp("Jump2") && gVar.player2Exists == false)
        {
            gVar.player2Exists = true;
            gVar.requiredReadyPlayers++;
            player2.GetComponent<CharacterSelect>().restart();
        }
        else if (Input.GetButtonUp("Jump3") && gVar.player3Exists == false)
        {
            gVar.player3Exists = true;
            gVar.requiredReadyPlayers++;
            player3.GetComponent<CharacterSelect>().restart();
        }
        else if (Input.GetButtonUp("Jump4") && gVar.player4Exists == false)
        {
            gVar.player4Exists = true;
            gVar.requiredReadyPlayers++;
            player4.GetComponent<CharacterSelect>().restart();
        }
        
        //back out of game
        if (Input.GetButtonUp("Back1") && gVar.player1Exists == true)
        {
            gVar.player1Exists = false;
            gVar.requiredReadyPlayers--; //decrease number of players that need to be confirmed "ready" to start game

            if (player1.GetComponent<CharacterSelect>().getIsReady())//if player claimed to have been ready before "quitting" then drop number of ready players by one
            {
                gVar.readyPlayers--;
            }
        }
        else if (Input.GetButtonUp("Back2") && gVar.player2Exists == true)
        {
            gVar.player2Exists = false;
            gVar.requiredReadyPlayers--;

            if (player2.GetComponent<CharacterSelect>().getIsReady())
            {
                gVar.readyPlayers--;
            }
        }
        else if (Input.GetButtonUp("Back3") && gVar.player3Exists == true)
        {
            gVar.player3Exists = false;
            gVar.requiredReadyPlayers--;

            if (player3.GetComponent<CharacterSelect>().getIsReady())
            {
                gVar.readyPlayers--;
            }
        }
        else if (Input.GetButtonUp("Back4") && gVar.player4Exists == true)
        {
            gVar.player4Exists = false;
            gVar.requiredReadyPlayers--;

            if (player4.GetComponent<CharacterSelect>().getIsReady())
            {
                gVar.readyPlayers--;
            }
        }
    }
}

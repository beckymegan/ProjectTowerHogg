using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public GameObject player1, player2, player3, player4;
    public GameObject lives1, lives2, lives3, lives4;

	void Start () {

        //delete all players that don't exist along with their health
        if (gVar.player1Exists == false)
        {
            Destroy(player1);
            Destroy(lives1);
        }

        if (gVar.player2Exists == false)
        {
            Destroy(player2);
            Destroy(lives2);
        }

        if (gVar.player3Exists == false)
        {
            Destroy(player3);
            Destroy(lives3);
        }

        if (gVar.player4Exists == false)
        {
            Destroy(player4);
            Destroy(lives4);
        }

    }
	
	// Update is called once per frame
	void Update () {

    }
}

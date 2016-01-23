using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public GameObject player1, player2, player3, player4;

	void Start () {

        //delete all players that don't exist along with their health
        if (gVar.player1Exists == false)
        {
            Destroy(player1);
        }

        if (gVar.player2Exists == false)
        {
            Destroy(player2);
        }

        if (gVar.player3Exists == false)
        {
            Destroy(player3);
        }

        if (gVar.player4Exists == false)
        {
            Destroy(player4);
        }

    }
}

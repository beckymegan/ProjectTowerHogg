using UnityEngine;
using System.Collections;

public class colorCharacters : MonoBehaviour {

    public SpriteRenderer self;
    public int playerNumber;
    public Sprite greenSprite, redSprite, blueSprite, purpleSprite;
    
    // Use this for initialization
	void Start () {
        Debug.Log("wat");
        //change sprite based on previously selected data
        if (playerNumber == 1)
        {
            if (gVar.player1 == "Green")
            {
                self.sprite = greenSprite;
            }
            else if (gVar.player1 == "Red")
            {
                self.sprite = redSprite;
            }
            else if (gVar.player1 == "Blue")
            {
                self.sprite = blueSprite;
            }
            else if (gVar.player1 == "Purple")
            {
                self.sprite = purpleSprite;
            }
        }
        else if (playerNumber == 2)
        {
            if (gVar.player2 == "Green")
            {
                self.sprite = greenSprite;
            }
            else if (gVar.player2 == "Red")
            {
                self.sprite = redSprite;
            }
            else if (gVar.player2 == "Blue")
            {
                self.sprite = blueSprite;
            }
            else if (gVar.player2 == "Purple")
            {
                self.sprite = purpleSprite;
            }
        }
    }
}

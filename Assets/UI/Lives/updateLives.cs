using UnityEngine;
using System.Collections;

public class updateLives : MonoBehaviour
{

    public Sprite B1, B2, B3, B4, B5, B6, B7, B8, B9;
    public Sprite G1, G2, G3, G4, G5, G6, G7, G8, G9;
    public Sprite R1, R2, R3, R4, R5, R6, R7, R8, R9;
    public Sprite P1, P2, P3, P4, P5, P6, P7, P8, P9;

    //change lives to correct number/color
    public void livesUpdate(int playerNumber, int lives)
    {
        if(playerNumber == 1)
        {
            livesUpdate1(lives);
        }
        else if (playerNumber == 2)
        {
            livesUpdate2(lives);
        }
        else if (playerNumber == 3)
        {
            livesUpdate3(lives);
        }
        else if (playerNumber == 4)
        {
            livesUpdate4(lives);
        }
    }

    //change lives number to correct lives number + color
    void livesUpdate1(int lives)
    {
        if (gVar.player1 == "Green")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = G9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = G8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = G7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = G6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = G5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = G4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = G3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = G2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = G1;
            }
        }
        else if (gVar.player1 == "Blue")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = B9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = B8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = B7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = B6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = B5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = B4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = B3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = B2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = B1;
            }
        }
        else if (gVar.player1 == "Red")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = R9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = R8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = R7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = R6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = R5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = R4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = R3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = R2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = R1;
            }
        }
        else if (gVar.player1 == "Purple")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = P9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = P8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = P7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = P6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = P5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = P4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = P3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = P2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = P1;
            }
        }
    }

    void livesUpdate2(int lives)
    {
        if (gVar.player2 == "Green")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = G9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = G8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = G7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = G6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = G5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = G4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = G3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = G2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = G1;
            }
        }
        else if (gVar.player2 == "Blue")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = B9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = B8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = B7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = B6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = B5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = B4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = B3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = B2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = B1;
            }
        }
        else if (gVar.player2 == "Red")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = R9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = R8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = R7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = R6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = R5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = R4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = R3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = R2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = R1;
            }
        }
        else if (gVar.player2 == "Purple")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = P9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = P8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = P7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = P6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = P5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = P4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = P3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = P2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = P1;
            }
        }
    }

    void livesUpdate3(int lives)
    {
        if (gVar.player3 == "Green")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = G9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = G8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = G7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = G6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = G5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = G4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = G3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = G2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = G1;
            }
        }
        else if (gVar.player3 == "Blue")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = B9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = B8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = B7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = B6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = B5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = B4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = B3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = B2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = B1;
            }
        }
        else if (gVar.player3 == "Red")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = R9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = R8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = R7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = R6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = R5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = R4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = R3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = R2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = R1;
            }
        }
        else if (gVar.player3 == "Purple")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = P9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = P8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = P7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = P6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = P5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = P4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = P3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = P2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = P1;
            }
        }
    }

    void livesUpdate4(int lives)
    {
        if (gVar.player4 == "Green")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = G9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = G8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = G7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = G6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = G5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = G4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = G3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = G2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = G1;
            }
        }
        else if (gVar.player4 == "Blue")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = B9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = B8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = B7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = B6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = B5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = B4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = B3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = B2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = B1;
            }
        }
        else if (gVar.player4 == "Red")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = R9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = R8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = R7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = R6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = R5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = R4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = R3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = R2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = R1;
            }
        }
        else if (gVar.player4 == "Purple")
        {
            if (lives == 9)
            {
                this.GetComponent<SpriteRenderer>().sprite = P9;
            }
            else if (lives == 8)
            {
                this.GetComponent<SpriteRenderer>().sprite = P8;
            }
            else if (lives == 7)
            {
                this.GetComponent<SpriteRenderer>().sprite = P7;
            }
            else if (lives == 6)
            {
                this.GetComponent<SpriteRenderer>().sprite = P6;
            }
            else if (lives == 5)
            {
                this.GetComponent<SpriteRenderer>().sprite = P5;
            }
            else if (lives == 4)
            {
                this.GetComponent<SpriteRenderer>().sprite = P4;
            }
            else if (lives == 3)
            {
                this.GetComponent<SpriteRenderer>().sprite = P3;
            }
            else if (lives == 2)
            {
                this.GetComponent<SpriteRenderer>().sprite = P2;
            }
            else if (lives == 1)
            {
                this.GetComponent<SpriteRenderer>().sprite = P1;
            }
        }
    }
}

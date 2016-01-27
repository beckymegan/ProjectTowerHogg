using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class openOptions : MonoBehaviour
{
    public CanvasGroup optionsScreen;
    public GameObject optionsPanel;

    private Color GREEN, RED, BLUE, PURPLE, GREY;

    void Start()
    {
        //set colors
        GREEN = new Color(0.435f, 0.768f, 0.662f, 0.75f);
        RED = new Color(0.945f, 0.611f, 0.717f, 0.75f);
        BLUE = new Color(0.553f, 0.710f, 0.906f, 0.75f);
        PURPLE = new Color(0.615f, 0.611f, 0.945f, 0.75f);
        GREY = new Color(0.5f, 0.5f, 0.5f, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        //press options button, pauses game
        if (Input.GetButtonDown("Options1") || Input.GetButtonDown("Options2") || Input.GetButtonDown("Options3") || Input.GetButtonDown("Options4"))
        {
            //if options is pressed in either menu color grey
            if(SceneManager.GetActiveScene().name == "Character Select" || SceneManager.GetActiveScene().name == "Level Select")
            {
                optionsPanel.GetComponent<Image>().color = GREY;
            }
            else //otherwise, color background according to the player's color
            {
                colorBackground();
            }

            optionsScreen.interactable = true;
            optionsScreen.alpha = 1;
            Time.timeScale = 0;
        }
    }

    //changes background of pause to reflect color of paused character
    void colorBackground()
    {
        if (Input.GetButtonDown("Options1"))
        {
            if (gVar.player1 == "Green")
            {
                optionsPanel.GetComponent<Image>().color = GREEN;
            }
            else if (gVar.player1 == "Red")
            {
                optionsPanel.GetComponent<Image>().color = RED;
            }
            else
            if (gVar.player1 == "Blue")
            {
                optionsPanel.GetComponent<Image>().color = BLUE;
            }
            else if (gVar.player1 == "Purple")
            {
                optionsPanel.GetComponent<Image>().color = PURPLE;
            }
        }
        else if (Input.GetButtonDown("Options2"))
        {
            if (gVar.player2 == "Green")
            {
                optionsPanel.GetComponent<Image>().color = GREEN;
            }
            else if (gVar.player2 == "Red")
            {
                optionsPanel.GetComponent<Image>().color = RED;
            }
            else
            if (gVar.player2 == "Blue")
            {
                optionsPanel.GetComponent<Image>().color = BLUE;
            }
            else if (gVar.player2 == "Purple")
            {
                optionsPanel.GetComponent<Image>().color = PURPLE;
            }
        }
        else if (Input.GetButtonDown("Options3"))
        {
            if (gVar.player3 == "Green")
            {
                optionsPanel.GetComponent<Image>().color = GREEN;
            }
            else if (gVar.player3 == "Red")
            {
                optionsPanel.GetComponent<Image>().color = RED;
            }
            else
            if (gVar.player3 == "Blue")
            {
                optionsPanel.GetComponent<Image>().color = BLUE;
            }
            else if (gVar.player3 == "Purple")
            {
                optionsPanel.GetComponent<Image>().color = PURPLE;
            }
        }
        else if (Input.GetButtonDown("Options4"))
        {
            if (gVar.player4 == "Green")
            {
                optionsPanel.GetComponent<Image>().color = GREEN;
            }
            else if (gVar.player4 == "Red")
            {
                optionsPanel.GetComponent<Image>().color = RED;
            }
            else
            if (gVar.player4 == "Blue")
            {
                optionsPanel.GetComponent<Image>().color = BLUE;
            }
            else if (gVar.player4 == "Purple")
            {
                optionsPanel.GetComponent<Image>().color = PURPLE;
            }
        }
    }
}

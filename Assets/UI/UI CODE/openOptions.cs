using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class openOptions : MonoBehaviour
{
    public CanvasGroup pauseScreen;
    public GameObject pausePanel, controlsPanel;
    public EventSystem eventSystem;

    private Color GREEN, RED, BLUE, PURPLE, GREY;

    void Start()
    {
        //set colors
        GREEN = new Color(0.435f, 0.768f, 0.662f, 0.85f);
        RED = new Color(0.945f, 0.611f, 0.717f, 0.85f);
        BLUE = new Color(0.553f, 0.710f, 0.906f, 0.85f);
        PURPLE = new Color(0.615f, 0.611f, 0.945f, 0.85f);
        GREY = new Color(0.95f, 0.95f, 0.95f, 0.85f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Options1"))//allow player 1 only to select buttons in pause menu
        {
            this.GetComponent<Options>().playerUsingMenu = 1;
            eventSystem.GetComponent<StandaloneInputModule>().verticalAxis = "Vertical1";
            eventSystem.GetComponent<StandaloneInputModule>().submitButton = "Jump1";
        }
        else if (Input.GetButtonDown("Options2"))//allow player 2 only to select buttons in pause menu
        {
            this.GetComponent<Options>().playerUsingMenu = 2;
            eventSystem.GetComponent<StandaloneInputModule>().verticalAxis = "Vertical2";
            eventSystem.GetComponent<StandaloneInputModule>().submitButton = "Jump2";
        }
        else if (Input.GetButtonDown("Options3"))//allow player 3 only to select buttons in pause menu
        {
            this.GetComponent<Options>().playerUsingMenu = 3;
            eventSystem.GetComponent<StandaloneInputModule>().verticalAxis = "Vertical3";
            eventSystem.GetComponent<StandaloneInputModule>().submitButton = "Jump3";
        }
        else if (Input.GetButtonDown("Options4"))//allow player 4 only to select buttons in pause menu
        {
            this.GetComponent<Options>().playerUsingMenu = 4;
            eventSystem.GetComponent<StandaloneInputModule>().verticalAxis = "Vertical4";
            eventSystem.GetComponent<StandaloneInputModule>().submitButton = "Jump4";
        }

        //press options button, pauses game
        if (Input.GetButtonDown("Options1") || Input.GetButtonDown("Options2") || Input.GetButtonDown("Options3") || Input.GetButtonDown("Options4"))
        {
            //if options is pressed in either menu color grey
            if (SceneManager.GetActiveScene().name == "Character Select" || SceneManager.GetActiveScene().name == "Level Select" || SceneManager.GetActiveScene().name == "Start Game")
            {
                pausePanel.GetComponent<Image>().color = GREY;
            }
            else //otherwise, color background according to the player's color
            {
                colorBackground();
            }

            pauseScreen.interactable = true;
            pauseScreen.alpha = 1;
            Time.timeScale = 0;
        }
    }

    //open options menu without pressing start
    public void openOptionsMenu()
    {
        pausePanel.GetComponent<Image>().color = GREY;
        controlsPanel.GetComponent<Image>().color = GREY;
        pauseScreen.interactable = true;
        pauseScreen.alpha = 1;
        Time.timeScale = 0;
    }

    //changes background of pause to reflect color of paused character
    void colorBackground()
    {
        if (Input.GetButtonDown("Options1"))
        {
            if (gVar.player1 == "Green")
            {
                pausePanel.GetComponent<Image>().color = GREEN;
                controlsPanel.GetComponent<Image>().color = GREEN;
            }
            else if (gVar.player1 == "Red")
            {
                pausePanel.GetComponent<Image>().color = RED;
                controlsPanel.GetComponent<Image>().color = RED;
            }
            else if (gVar.player1 == "Blue")
            {
                pausePanel.GetComponent<Image>().color = BLUE;
                controlsPanel.GetComponent<Image>().color = BLUE;
            }
            else if (gVar.player1 == "Purple")
            {
                pausePanel.GetComponent<Image>().color = PURPLE;
                controlsPanel.GetComponent<Image>().color = PURPLE;
            }
        }
        else if (Input.GetButtonDown("Options2"))
        {
            if (gVar.player2 == "Green")
            {
                pausePanel.GetComponent<Image>().color = GREEN;
                controlsPanel.GetComponent<Image>().color = GREEN;
            }
            else if (gVar.player2 == "Red")
            {
                pausePanel.GetComponent<Image>().color = RED;
                controlsPanel.GetComponent<Image>().color = RED;
            }
            else
            if (gVar.player2 == "Blue")
            {
                pausePanel.GetComponent<Image>().color = BLUE;
                controlsPanel.GetComponent<Image>().color = BLUE;
            }
            else if (gVar.player2 == "Purple")
            {
                pausePanel.GetComponent<Image>().color = PURPLE;
                controlsPanel.GetComponent<Image>().color = PURPLE;
            }
        }
        else if (Input.GetButtonDown("Options3"))
        {
            if (gVar.player3 == "Green")
            {
                pausePanel.GetComponent<Image>().color = GREEN;
                controlsPanel.GetComponent<Image>().color = GREEN;
            }
            else if (gVar.player3 == "Red")
            {
                pausePanel.GetComponent<Image>().color = RED;
                controlsPanel.GetComponent<Image>().color = RED;
            }
            else if (gVar.player3 == "Blue")
            {
                pausePanel.GetComponent<Image>().color = BLUE;
                controlsPanel.GetComponent<Image>().color = BLUE;
            }
            else if (gVar.player3 == "Purple")
            {
                pausePanel.GetComponent<Image>().color = PURPLE;
                controlsPanel.GetComponent<Image>().color = PURPLE;
            }
        }
        else if (Input.GetButtonDown("Options4"))
        {
            if (gVar.player4 == "Green")
            {
                pausePanel.GetComponent<Image>().color = GREEN;
                controlsPanel.GetComponent<Image>().color = GREEN;
            }
            else if (gVar.player4 == "Red")
            {
                pausePanel.GetComponent<Image>().color = RED;
                controlsPanel.GetComponent<Image>().color = RED;
            }
            else if (gVar.player4 == "Blue")
            {
                pausePanel.GetComponent<Image>().color = BLUE;
                controlsPanel.GetComponent<Image>().color = BLUE;
            }
            else if (gVar.player4 == "Purple")
            {
                pausePanel.GetComponent<Image>().color = PURPLE;
                controlsPanel.GetComponent<Image>().color = PURPLE;
            }
        }
    }
}

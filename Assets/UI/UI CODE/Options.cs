using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class Options : MonoBehaviour
{
    public int playerUsingMenu = 0;

    public CanvasGroup pauseMenu, howToPlayCanvas;
    public Dropdown fullscreenDropdown;
    public Slider musicSlider, sfxSlider;
    public GameObject resumeButton, playButton, startButton, backHowToButton;
    public AudioClip switchNoise;
    public AudioSource aud;
    public EventSystem eventSystem;

    private int maxGameWidth, maxGameHeight;
    private Resolution[] resolutions;
    private GameObject pause, oldButton, newButton;

    void Start()
    {
        if (gVar.justOpened == true && Screen.fullScreen == false)//if game is opened for the first time and the game is in full screen
        {
            gVar.gameHeight = Screen.height;//store chosen non-fullscreen resolution
            if (gVar.gameHeight == 720) { gVar.gameWidth = 1280; }
            else if (gVar.gameHeight == 768) { gVar.gameWidth = 1366; }
            else if (gVar.gameHeight == 900) { gVar.gameWidth = 1600; }
            gVar.justOpened = false;
        }
        else if (gVar.justOpened == true && Screen.fullScreen == true)//if game is opened for the first time but the game is not in full screen
        {
            gVar.gameHeight = 720;//store 1280x720
            gVar.gameWidth = 1280;
            gVar.justOpened = false;
        }

        //find max resolution
        resolutions = Screen.resolutions;
        maxGameWidth = resolutions[resolutions.Length - 1].width;
        maxGameHeight = resolutions[resolutions.Length - 1].height;

        //set fullscreen dropdown to match current settings
        if (Screen.fullScreen == true)
        {
            fullscreenDropdown.value = 0;
        }
        else if (Screen.fullScreen == false)
        {
            fullscreenDropdown.value = 1;
        }

        //set sliders to current values
        musicSlider.value = gVar.musicVolume;
        sfxSlider.value = gVar.sfxVolume;
    }

    void Update()
    {
           if (eventSystem.currentSelectedGameObject != null)//prevent mouse clicking on UI elements
        {
            newButton = eventSystem.currentSelectedGameObject.gameObject;

            //if back button is pressed by player who opened it, close
            if ((pauseMenu.alpha == 1) && ((playerUsingMenu == 1 && Input.GetButtonDown("Back1")) || (playerUsingMenu == 2 && Input.GetButtonDown("Back2"))
                    || (playerUsingMenu == 3 || Input.GetButtonDown("Back3")) || (playerUsingMenu == 4 && Input.GetButtonDown("Back4")) || (playerUsingMenu == 0 && Input.GetButtonDown("GBack"))))
                {
                    resume();
                }

                //play noise if button is switched
                if (!newButton.Equals(oldButton) && !aud.isPlaying && Time.timeSinceLevelLoad > 0.5f)
                {
                    if(eventSystem.firstSelectedGameObject.name.Equals("Resume")==false)//menu screen
                {
                    aud.PlayOneShot(switchNoise, gVar.sfxVolume);
                }
                    else if (pauseMenu.alpha == 1)//not menu screen but pause menu is open
                {
                    aud.PlayOneShot(switchNoise, gVar.sfxVolume);
                }
                }

                if (SceneManager.GetActiveScene().name == "Start Game")
                {
                    if (pauseMenu.alpha == 1 && gVar.pauseMenuOpen == false)
                    {
                        gVar.pauseMenuOpen = true;
                        eventSystem.SetSelectedGameObject(resumeButton);
                    }
                    else if (pauseMenu.alpha == 0 && gVar.pauseMenuOpen == true && eventSystem.currentSelectedGameObject.Equals(backHowToButton) == false)
                    {
                        gVar.pauseMenuOpen = false;
                        eventSystem.SetSelectedGameObject(startButton);

                    }
                }
                else
                {
                    if (pauseMenu.alpha == 1 && gVar.pauseMenuOpen == false)
                    {
                        gVar.pauseMenuOpen = true;
                        eventSystem.SetSelectedGameObject(resumeButton);
                    }
                    else if (pauseMenu.alpha == 0 && gVar.pauseMenuOpen == true && eventSystem.currentSelectedGameObject.Equals(backHowToButton) == false)
                    {
                        gVar.pauseMenuOpen = false;
                        if (playButton != null) { eventSystem.SetSelectedGameObject(playButton); }
                    }
                }
                oldButton = eventSystem.currentSelectedGameObject.gameObject;
            }
            else//reset pointer if mouse was clicked
            {
                eventSystem.SetSelectedGameObject(newButton);
            }
    }

    //resume game
    public void resume()
    {
        eventSystem.GetComponent<StandaloneInputModule>().verticalAxis = "GVertical";
        eventSystem.GetComponent<StandaloneInputModule>().submitButton = "GSelect";
        gVar.optionTime = 0;
        pauseMenu.GetComponent<CanvasGroup>().alpha = 0;
        pauseMenu.GetComponent<CanvasGroup>().interactable = false;
        howToPlayCanvas.GetComponent<CanvasGroup>().alpha = 0;
        howToPlayCanvas.GetComponent<CanvasGroup>().interactable = false;
        Time.timeScale = 1;
    }

    //change to/from fullscreen
    public void changeFullscreen(Dropdown dropdown)
    {
        if (dropdown.value == 0)//fullscreen
        {
            Screen.SetResolution(maxGameWidth, maxGameHeight, true);
        }
        else if (dropdown.value == 1)//not fullscreen
        {
            Screen.SetResolution(gVar.gameWidth, gVar.gameHeight, false);
        }
    }

    //change music volume
    public void musicVolume(float volume)
    {
        gVar.musicVolume = musicSlider.value;
    }

    //change SFX volume
    public void sfxVolume(float volume)
    {
        gVar.sfxVolume = sfxSlider.value;
        eventSystem.GetComponent<AudioSource>().volume = gVar.sfxVolume;
    }

    //return to level select menu
    public void menu()
    {
        playerUsingMenu = 0; //any player can close
        gVar.optionTime = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("Level Select");
    }

    public void next()
    {
        gVar.optionTime = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("Character Select");
    }

    //restart level
    public void restart()
    {
        gVar.softReset();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    //open up how to play menu
    public void howToPlay()
    {
        howToPlayCanvas.GetComponent<CanvasGroup>().alpha = 1;
        howToPlayCanvas.GetComponent<CanvasGroup>().interactable = true;
        pauseMenu.GetComponent<CanvasGroup>().alpha = 0;
        pauseMenu.GetComponent<CanvasGroup>().interactable = false;
        eventSystem.SetSelectedGameObject(backHowToButton);
    }

    //return to pause menu after closing howtoplay menu
    public void resumeHowTo()
    {
        howToPlayCanvas.GetComponent<CanvasGroup>().alpha = 0;
        howToPlayCanvas.GetComponent<CanvasGroup>().interactable = false;
        pauseMenu.GetComponent<CanvasGroup>().alpha = 1;
        pauseMenu.GetComponent<CanvasGroup>().interactable = true;
        eventSystem.SetSelectedGameObject(resumeButton);
    }

    //quit game
    public void quit()
    {
        Application.Quit();
    }
}

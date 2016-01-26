using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Options : MonoBehaviour
{

    public CanvasGroup pauseMenu;
    public Dropdown fullscreenDropdown;
    public Slider musicSlider, sfxSlider;

    private int maxGameWidth, maxGameHeight;
    private Resolution[] resolutions;

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
        sfxSlider.value = gVar.volume;
    }

    //resume game
    public void resume()
    {
        gVar.optionTime = 0;
        pauseMenu.GetComponent<CanvasGroup>().alpha = 0;
        pauseMenu.GetComponent<CanvasGroup>().interactable = false;
        Time.timeScale = 1;
    }

    //change to/from fullscreen
    public void changeFullscreen(int fullscreenOption)
    {
        if (fullscreenOption == 0)//fullscreen
        {
            Screen.SetResolution(maxGameWidth, maxGameHeight, true);
        }
        else if (fullscreenOption == 1)//not fullscreen
        {
            Screen.SetResolution(gVar.gameWidth, gVar.gameHeight, false);
        }
    }

    //change music volume
    public void musicVolume(float volume)
    {
        gVar.musicVolume = volume;
    }

    //change SFX volume
    public void sfxVolume(float volume)
    {
        gVar.volume = volume;
    }

    //return to level select menu
    public void menu()
    {
        gVar.optionTime = 0;
        gVar.resetVars();
        Time.timeScale = 1;
        SceneManager.LoadScene("Level Select");
    }

    //quit game
    public void quit()
    {
        Application.Quit();
    }
}

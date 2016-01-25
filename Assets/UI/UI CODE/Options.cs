using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Options : MonoBehaviour
{

    public CanvasGroup pauseMenu;
    public Dropdown fullscreenDropdown;
    public Slider musicSlider, sfxSlider;

    private int screenSizeWidth, screenSizeHeight;
    private Resolution[] resolutions;

    void Start()
    {
        //find max resolution
        resolutions = Screen.resolutions;
        screenSizeWidth = resolutions[resolutions.Length - 1].width;
        screenSizeHeight = resolutions[resolutions.Length - 1].height;

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
            Screen.SetResolution(screenSizeWidth, screenSizeHeight, true);
        }
        else if (fullscreenOption == 1)//not fullscreen
        {
            Screen.SetResolution(1280, 720, false);
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

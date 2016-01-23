using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Options : MonoBehaviour {

    public CanvasGroup pauseMenu, audioMenu;
    public GameObject eventSystem, resumeButton;

    //resume game
	public void resume()
    {
        gVar.optionTime = 0;
        pauseMenu.GetComponent<CanvasGroup>().alpha = 0;
        pauseMenu.GetComponent<CanvasGroup>().interactable = false;
        Time.timeScale = 1;
    }

    //open audio menu
    public void audio()
    {
        gVar.optionTime = 0;
        pauseMenu.GetComponent<CanvasGroup>().alpha = 0;
        pauseMenu.GetComponent<CanvasGroup>().interactable = false;
        audioMenu.GetComponent<CanvasGroup>().alpha = 1;
        audioMenu.GetComponent<CanvasGroup>().interactable = true;
    }

    //return to level select menu
    public void quit()
    {
        gVar.optionTime = 0;
        gVar.resetVars();
        Time.timeScale = 1;
        SceneManager.LoadScene("Level Select");
    }

    public void backAudio()
    {
        gVar.optionTime = 0;
        audioMenu.GetComponent<CanvasGroup>().alpha = 0;
        audioMenu.GetComponent<CanvasGroup>().interactable = false;
        pauseMenu.GetComponent<CanvasGroup>().alpha = 1;
        pauseMenu.GetComponent<CanvasGroup>().interactable = true;
    }
}

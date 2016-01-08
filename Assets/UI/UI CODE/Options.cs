using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Options : MonoBehaviour {

    public CanvasGroup optionsMenu;

    //resume game
	public void resume()
    {
        optionsMenu.alpha = 0;
        Time.timeScale = 1;
    }

    //return to level select menu
    public void menu()
    {
        gVar.resetVars();
        SceneManager.LoadScene("Level Select");
        Time.timeScale = 1;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Options : MonoBehaviour {
   
    //resume game
	public void resume()
    {
        gVar.optionTime = 0;
        GetComponent<CanvasGroup>().alpha = 0;
        Time.timeScale = 1;
        GetComponent<CanvasGroup>().interactable = false;
    }

    //return to level select menu
    public void menu()
    {
        gVar.optionTime = 0;
        gVar.resetVars();
        SceneManager.LoadScene("Level Select");
        Time.timeScale = 1;
    }
}

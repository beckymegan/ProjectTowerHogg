using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public CanvasGroup gameoverMenu;
    public Sprite greenSprite, redSprite, blueSprite, purpleSprite;
    public GameObject winner, platform, first;
    public EventSystem eventSystem;

    private bool justOpened = true;

    // Use this for initialization
    void Start()
    {
        platform.GetComponent<SpriteRenderer>().enabled = false;
        winner.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if only one team is left
        if (gVar.numberPlayers == gVar.redShotsStored || gVar.numberPlayers == gVar.blueShotsStored || gVar.numberPlayers == gVar.greenShotsStored || gVar.numberPlayers == gVar.purpleShotsStored)
        {
            if (justOpened == true)
            {
                eventSystem.GetComponent<StandaloneInputModule>().verticalAxis = "GVertical"; //allow all users to select buttons in gameover menu
                eventSystem.SetSelectedGameObject(first);//change selected button

                Time.timeScale = 0;

                gameoverMenu.alpha = 1;
                gameoverMenu.interactable = true;
                platform.GetComponent<SpriteRenderer>().enabled = true;
                winner.GetComponent<SpriteRenderer>().enabled = true;
                justOpened = false;

                if (gVar.greenShots > 0)
                {
                    winner.GetComponent<SpriteRenderer>().sprite = greenSprite;
                }
                else if (gVar.redShots > 0)
                {
                    winner.GetComponent<SpriteRenderer>().sprite = redSprite;
                }
                else if (gVar.blueShots > 0)
                {
                    winner.GetComponent<SpriteRenderer>().sprite = blueSprite;
                }
                else if (gVar.purpleShots > 0)
                {
                    winner.GetComponent<SpriteRenderer>().sprite = purpleSprite;
                }
            }
        }
    }
}

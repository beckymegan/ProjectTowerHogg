using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class openOptions : MonoBehaviour
{

    public CanvasGroup optionsScreen;

    // Update is called once per frame
    void Update()
    {
        //press options button, pauses game
        if (Input.GetButtonDown("GOptions"))
        {
            optionsScreen.interactable = true;
            optionsScreen.alpha = 1;
            Time.timeScale = 0;
        }
    }
}

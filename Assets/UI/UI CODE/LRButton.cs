using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LRButton : MonoBehaviour {

    public string givenDirection;
    public GameObject logic;
    public SpriteRenderer continueButton;
    public Sprite cPressed;

    public void OnMouseDown()
    {
        if (givenDirection.Equals("rotateRight"))
        {
            logic.GetComponent<LevelSwitch>().levelPressed("left");

        }
        else if (givenDirection.Equals("rotateLeft"))
        {
            logic.GetComponent<LevelSwitch>().levelPressed("right");
        }
        else if (givenDirection.Equals("continue"))
        {
            continueButton.sprite = cPressed;
            gVar.level = gVar.currentLocation;
            SceneManager.LoadScene("Character Select");
        }
    }
}

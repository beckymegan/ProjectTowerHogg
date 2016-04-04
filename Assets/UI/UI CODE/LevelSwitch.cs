using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSwitch : MonoBehaviour
{
    public float speedTime, speedScale;

    public GameObject level1, level2, level3, level4, level5, emptyButton;
    public AudioClip switchLevel, selectLevel;
    public Button next;
    public EventSystem eventSystem;
    public Vector2 front, right, left, back;

    private int level, menuCounter;
    private string loadingDir;

    private Transform l1, l5, l4, l3, l2;

    // Use this for initialization
    void Start()
    {
        gVar.resetVars();//reset all values

        Time.timeScale = 1;
        menuCounter = 0;

        l1 = level1.GetComponent<Transform>();
        l5 = level5.GetComponent<Transform>();
        l4 = level4.GetComponent<Transform>();
        l3 = level3.GetComponent<Transform>();
        l2 = level2.GetComponent<Transform>();

        gVar.currentLocation = 1;
        loadingDir = "stop";
    }

    // Update is called once per frame
    void Update()
    {
        gVar.optionTime++;

        if (Time.timeScale == 1)
        {
            menuCounter++;
            levelPressed();
        }

    }

    public void levelPressed()
    {
        //rotate levels right
        if ((((Input.GetAxisRaw("Horizontal1") > 0 || Input.GetAxisRaw("Horizontal2") > 0 || Input.GetAxisRaw("Horizontal3") > 0 || Input.GetAxisRaw("Horizontal4") > 0) && menuCounter >= 20)))
        {
            //reset counter for controllers
            menuCounter = 0;
            
            gVar.currentLocation++;
            loadingDir = "left";

            //play switching sound
            GetComponent<AudioSource>().PlayOneShot(switchLevel, gVar.sfxVolume);
        }
        //rotate levels left
        else if ((((Input.GetAxisRaw("Horizontal1") < 0 || Input.GetAxisRaw("Horizontal2") < 0 || Input.GetAxisRaw("Horizontal3") < 0 || Input.GetAxisRaw("Horizontal4") < 0) && menuCounter >= 20)))
        {
            //reset counter for controllers
            menuCounter = 0;
            
            gVar.currentLocation--;
            loadingDir = "right";

            //play switching sound
            GetComponent<AudioSource>().PlayOneShot(switchLevel, gVar.sfxVolume);
        }

        //loops level select so gVar.currentLocation must be 1-5
        if (gVar.currentLocation > 5)
        {
            gVar.currentLocation = 1;
        }
        else if (gVar.currentLocation < 1)
        {
            gVar.currentLocation = 5;
        }

        levelSwitch();
    }

    //SPINS THE LEVEL SELECT MENU AROUND
    public void levelSwitch()
    {
        //rotate levels left if next button is not selected
        if (loadingDir.Equals("left") && eventSystem.currentSelectedGameObject.Equals(next) == false)
        {
            if (gVar.currentLocation == 2)
            {
                //back to right
                l3.position = Vector2.MoveTowards(l3.position, right, speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 2);
                if (l3.localScale.x < 0.18f)
                {
                    l3.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //right to center
                l2.position = Vector2.MoveTowards(l2.position, front, speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 1);
                if (l2.localScale.x < 0.35f)
                {
                    l2.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to left
                l1.position = Vector2.MoveTowards(l1.position, left, speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 1);
                if (l1.localScale.x > 0.18f)
                {
                    l1.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //left to back
                l5.position = Vector2.MoveTowards(l5.position, back, speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 3);
                if (l5.localScale.x > 0)
                {
                    l5.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 3)
            {
                //back to right
                l4.position = Vector2.MoveTowards(l4.position, right, speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 2);
                if (l4.localScale.x < 0.18f)
                {
                    l4.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //right to center
                l3.position = Vector2.MoveTowards(l3.position, front, speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 1);
                if (l3.localScale.x < 0.35f)
                {
                    l3.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to left
                l2.position = Vector2.MoveTowards(l2.position, left, speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 1);
                if (l2.localScale.x > 0.18f)
                {
                    l2.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //left to back
                l1.position = Vector2.MoveTowards(l1.position, back, speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 3);
                if (l1.localScale.x > 0)
                {
                    l1.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 4)
            {
                //back to right
                l5.position = Vector2.MoveTowards(l5.position, right, speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 2);
                if (l5.localScale.x < 0.18f)
                {
                    l5.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //right to center
                l4.position = Vector2.MoveTowards(l4.position, front, speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 1);
                if (l4.localScale.x < 0.35f)
                {
                    l4.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to left
                l3.position = Vector2.MoveTowards(l3.position, left, speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 1);
                if (l3.localScale.x > 0.18f)
                {
                    l3.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //left to back
                l2.position = Vector2.MoveTowards(l2.position, back, speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 3);
                if (l2.localScale.x > 0)
                {
                    l2.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 5)
            {
                //back to right
                l1.position = Vector2.MoveTowards(l1.position, right, speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 2);
                if (l1.localScale.x < 0.18f)
                {
                    l1.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //right to center
                l5.position = Vector2.MoveTowards(l5.position, front, speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 1);
                if (l5.localScale.x < 0.35f)
                {
                    l5.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to left
                l4.position = Vector2.MoveTowards(l4.position, left, speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 1);
                if (l4.localScale.x > 0.18f)
                {
                    l4.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //left to back
                l3.position = Vector2.MoveTowards(l3.position, back, speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 3);
                if (l3.localScale.x > 0)
                {
                    l3.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 1)
            {
                //back to right
                l2.position = Vector2.MoveTowards(l2.position, right, speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 2);
                if (l2.localScale.x < 0.18f)
                {
                    l2.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //right to center
                l1.position = Vector2.MoveTowards(l1.position, front, speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 1);
                if (l1.localScale.x < 0.35f)
                {
                    l1.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to left
                l5.position = Vector2.MoveTowards(l5.position, left, speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 1);
                if (l5.localScale.x > 0.18f)
                {
                    l5.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //left to back
                l4.position = Vector2.MoveTowards(l4.position, back, speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 3);
                if (l4.localScale.x > 0)
                {
                    l4.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
        }
        else if (loadingDir.Equals("right") && eventSystem.currentSelectedGameObject.Equals(next) == false)
        {
            if (gVar.currentLocation == 1)
            {
                //back to left
                l5.position = Vector2.MoveTowards(l5.position, left, speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 2);
                if (l5.localScale.x < 0.18f)
                {
                    l5.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //left to center
                l1.position = Vector2.MoveTowards(l1.position, front, speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 1);
                if (l1.localScale.x < 0.35f)
                {
                    l1.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to right
                l2.position = Vector2.MoveTowards(l2.position, right, speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 1);
                if (l2.localScale.x > 0.18f)
                {
                    l2.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //right to back
                l3.position = Vector2.MoveTowards(l3.position, back, speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 3);
                if (l3.localScale.x > 0)
                {
                    l3.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 5)
            {
                //back to left
                l4.position = Vector2.MoveTowards(l4.position, left, speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 2);
                if (l4.localScale.x < 0.18f)
                {
                    l4.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //left to center
                l5.position = Vector2.MoveTowards(l5.position, front, speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 1);
                if (l5.localScale.x < 0.35f)
                {
                    l5.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to right
                l1.position = Vector2.MoveTowards(l1.position, right, speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 1);
                if (l1.localScale.x > 0.18f)
                {
                    l1.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //right to back
                l2.position = Vector2.MoveTowards(l2.position, back, speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 3);
                if (l2.localScale.x > 0)
                {
                    l2.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 4)
            {
                //back to left
                l3.position = Vector2.MoveTowards(l3.position, left, speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 2);
                if (l3.localScale.x < 0.18f)
                {
                    l3.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //left to center
                l4.position = Vector2.MoveTowards(l4.position, front, speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 1);
                if (l4.localScale.x < 0.35f)
                {
                    l4.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to right
                l5.position = Vector2.MoveTowards(l5.position, right, speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 1);
                if (l5.localScale.x > 0.18f)
                {
                    l5.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //right to back
                l1.position = Vector2.MoveTowards(l1.position, back, speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 3);
                if (l1.localScale.x > 0)
                {
                    l1.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 3)
            {
                //back to left
                l2.position = Vector2.MoveTowards(l2.position, left, speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 2);
                if (l2.localScale.x < 0.18f)
                {
                    l2.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //left to center
                l3.position = Vector2.MoveTowards(l3.position, front, speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 1);
                if (l3.localScale.x < 0.35f)
                {
                    l3.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to right
                l4.position = Vector2.MoveTowards(l4.position, right, speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 1);
                if (l4.localScale.x > 0.18f)
                {
                    l4.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //right to back
                l5.position = Vector2.MoveTowards(l5.position, back, speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 3);
                if (l5.localScale.x > 0)
                {
                    l5.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 2)
            {
                //back to left
                l1.position = Vector2.MoveTowards(l1.position, left, speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 2);
                if (l1.localScale.x < 0.18f)
                {
                    l1.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //left to center
                l2.position = Vector2.MoveTowards(l2.position, front, speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 1);
                if (l2.localScale.x < 0.35f)
                {
                    l2.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to right
                l3.position = Vector2.MoveTowards(l3.position, right, speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 1);
                if (l3.localScale.x > 0.18f)
                {
                    l3.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //right to back
                l4.position = Vector2.MoveTowards(l4.position, back, speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 3);
                if (l4.localScale.x > 0)
                {
                    l4.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
        }
    }

}

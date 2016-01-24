using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSwitch : MonoBehaviour
{
    public GameObject level1, level2, level3, level4, level5;
    public float speedTime, speedScale;
    public AudioClip switchLevel, selectLevel;

    private Transform l1, l5, l4, l3, l2;

    private int level, menuCounter;
    private string loadingDir;
    private bool canChange, switchToCharacter;


    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        menuCounter = 0;

        l1 = level1.GetComponent<Transform>();
        l5 = level5.GetComponent<Transform>();
        l4 = level4.GetComponent<Transform>();
        l3 = level3.GetComponent<Transform>();
        l2 = level2.GetComponent<Transform>();

        gVar.currentLocation = 1;
        loadingDir = "stop";
        canChange = true; switchToCharacter = false;
    }

    // Update is called once per frame
    void Update()
    {
        gVar.optionTime++;

        if (Time.timeScale == 1)
        {
            menuCounter++;
            levelPressed("stop");
            if (Input.GetButtonDown("GSelect") && gVar.optionTime > 25)//level select, go to character select
            {
                //play select sound
                GetComponent<AudioSource>().PlayOneShot(selectLevel, 1f);
                switchToCharacter = true;
            }

            //switch to character select after sound is finished
            if (!GetComponent<AudioSource>().isPlaying && switchToCharacter && gVar.optionTime > 25)
            {
                gVar.level = gVar.currentLocation;
                SceneManager.LoadScene("Character Select");
            }
        }

    }

    public void levelPressed(string direction)
    {

        //right arrow button OR right bumper on controller OR right arrow is pressed and levels are not currently in rotation ROTATE LEFT
        if ((((Input.GetAxisRaw("Horizontal1") > 0 || Input.GetAxisRaw("Horizontal2") > 0 || Input.GetAxisRaw("Horizontal3") > 0 || Input.GetAxisRaw("Horizontal4") > 0) && menuCounter >= 20)
            || direction.Equals("right")) && canChange == true)
        {
            //reset counter for controllers
            menuCounter = 0;

            //rightSlider.sprite = rSlidePressed;
            gVar.currentLocation++;
            loadingDir = "left";
            canChange = false;

            //play switching sound
            GetComponent<AudioSource>().PlayOneShot(switchLevel, 1f);
        }
        //left arrow button OR left bumper on controller OR left arrow is pressed and levels are not currently in rotation ROTATE RIGHT
        else if ((((Input.GetAxisRaw("Horizontal1") < 0 || Input.GetAxisRaw("Horizontal2") < 0 || Input.GetAxisRaw("Horizontal3") < 0 || Input.GetAxisRaw("Horizontal4") < 0) && menuCounter >= 20)
            || direction.Equals("left")) && canChange == true)
        {
            //reset counter for controllers
            menuCounter = 0;

            //leftSlider.sprite = lSlidePressed;
            gVar.currentLocation--;
            loadingDir = "right";
            canChange = false;

            //play switching sound
            GetComponent<AudioSource>().PlayOneShot(switchLevel, 1f);
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
        /* COORDS
            BACK - Vector2.MoveTowards(l4.position, new Vector2(0, 0.5f), speedTime); new Vector3(l4.position.x, l4.position.y, 3);
            RIGHT - Vector2.MoveTowards(l5.position, new Vector2(1, 0.185f), speedTime); new Vector3(l5.position.x, l5.position.y, 2);
            CENTER - Vector2.MoveTowards(l1.position, new Vector2(0, -0.125F), speedTime); new Vector3(l1.position.x, l1.position.y, 1);
            LEFT - Vector2.MoveTowards(l1.position, new Vector3(-1, 0.185f), speedTime); new Vector3(l1.position.x, l1.position.y, 1);
            SCALE (GENERAL) - l4.localScale += new Vector3(0.01f, 0.01f, 0);
        */

        if (loadingDir.Equals("left"))
        {
            if (gVar.currentLocation == 2)
            {
                //back to right
                l3.position = Vector2.MoveTowards(l3.position, new Vector2(1, 0.31f), speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 2);
                if (l3.localScale.x < 0.50f)
                {
                    l3.localScale += new Vector3(speedScale, speedScale, 0);
                }
                else
                {
                    canChange = true;
                }
                //right to center
                l2.position = Vector2.MoveTowards(l2.position, new Vector2(0, 0), speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 1);
                if (l2.localScale.x < 1)
                {
                    l2.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to left
                l1.position = Vector2.MoveTowards(l1.position, new Vector3(-1, 0.31f), speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 1);
                if (l1.localScale.x > 0.50f)
                {
                    l1.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //left to back
                l5.position = Vector2.MoveTowards(l5.position, new Vector2(0, 0.50f), speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 3);
                if (l5.localScale.x > 0)
                {
                    l5.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 3)
            {
                //back to right
                l4.position = Vector2.MoveTowards(l4.position, new Vector2(1, 0.31f), speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 2);
                if (l4.localScale.x < 0.50f)
                {
                    l4.localScale += new Vector3(speedScale, speedScale, 0);
                }
                else
                {
                    canChange = true;
                }
                //right to center
                l3.position = Vector2.MoveTowards(l3.position, new Vector2(0, 0), speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 1);
                if (l3.localScale.x < 1)
                {
                    l3.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to left
                l2.position = Vector2.MoveTowards(l2.position, new Vector3(-1, 0.31f), speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 1);
                if (l2.localScale.x > 0.50f)
                {
                    l2.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //left to back
                l1.position = Vector2.MoveTowards(l1.position, new Vector2(0, 0.50f), speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 3);
                if (l1.localScale.x > 0)
                {
                    l1.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 4)
            {
                //back to right
                l5.position = Vector2.MoveTowards(l5.position, new Vector2(1, 0.31f), speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 2);
                if (l5.localScale.x < 0.50f)
                {
                    l5.localScale += new Vector3(speedScale, speedScale, 0);
                }
                else
                {
                    canChange = true;
                }
                //right to center
                l4.position = Vector2.MoveTowards(l4.position, new Vector2(0, 0), speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 1);
                if (l4.localScale.x < 1)
                {
                    l4.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to left
                l3.position = Vector2.MoveTowards(l3.position, new Vector3(-1, 0.31f), speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 1);
                if (l3.localScale.x > 0.50f)
                {
                    l3.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //left to back
                l2.position = Vector2.MoveTowards(l2.position, new Vector2(0, 0.50f), speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 3);
                if (l2.localScale.x > 0)
                {
                    l2.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 5)
            {
                //back to right
                l1.position = Vector2.MoveTowards(l1.position, new Vector2(1, 0.31f), speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 2);
                if (l1.localScale.x < 0.50f)
                {
                    l1.localScale += new Vector3(speedScale, speedScale, 0);
                }
                else
                {
                    canChange = true;
                }
                //right to center
                l5.position = Vector2.MoveTowards(l5.position, new Vector2(0, 0), speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 1);
                if (l5.localScale.x < 1)
                {
                    l5.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to left
                l4.position = Vector2.MoveTowards(l4.position, new Vector3(-1, 0.31f), speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 1);
                if (l4.localScale.x > 0.50f)
                {
                    l4.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //left to back
                l3.position = Vector2.MoveTowards(l3.position, new Vector2(0, 0.50f), speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 3);
                if (l3.localScale.x > 0)
                {
                    l3.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 1)
            {
                //back to right
                l2.position = Vector2.MoveTowards(l2.position, new Vector2(1, 0.31f), speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 2);
                if (l2.localScale.x < 0.50f)
                {
                    l2.localScale += new Vector3(speedScale, speedScale, 0);
                }
                else
                {
                    canChange = true;
                }
                //right to center
                l1.position = Vector2.MoveTowards(l1.position, new Vector2(0, 0), speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 1);
                if (l1.localScale.x < 1)
                {
                    l1.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to left
                l5.position = Vector2.MoveTowards(l5.position, new Vector3(-1, 0.31f), speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 1);
                if (l5.localScale.x > 0.50f)
                {
                    l5.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //left to back
                l4.position = Vector2.MoveTowards(l4.position, new Vector2(0, 0.50f), speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 3);
                if (l4.localScale.x > 0)
                {
                    l4.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
        }
        else if (loadingDir.Equals("right"))
        {
            if (gVar.currentLocation == 1)
            {
                //back to left
                l5.position = Vector2.MoveTowards(l5.position, new Vector2(-1, 0.31f), speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 2);
                if (l5.localScale.x < 0.50f)
                {
                    l5.localScale += new Vector3(speedScale, speedScale, 0);
                }
                else
                {
                    canChange = true;
                }
                //left to center
                l1.position = Vector2.MoveTowards(l1.position, new Vector2(0, 0), speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 1);
                if (l1.localScale.x < 1)
                {
                    l1.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to right
                l2.position = Vector2.MoveTowards(l2.position, new Vector3(1, 0.31f), speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 1);
                if (l2.localScale.x > 0.50f)
                {
                    l2.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //right to back
                l3.position = Vector2.MoveTowards(l3.position, new Vector2(0, 0.50f), speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 3);
                if (l3.localScale.x > 0)
                {
                    l3.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 5)
            {
                //back to left
                l4.position = Vector2.MoveTowards(l4.position, new Vector2(-1, 0.31f), speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 2);
                if (l4.localScale.x < 0.50f)
                {
                    l4.localScale += new Vector3(speedScale, speedScale, 0);
                }
                else
                {
                    canChange = true;
                }
                //left to center
                l5.position = Vector2.MoveTowards(l5.position, new Vector2(0, 0), speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 1);
                if (l5.localScale.x < 1)
                {
                    l5.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to right
                l1.position = Vector2.MoveTowards(l1.position, new Vector3(1, 0.31f), speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 1);
                if (l1.localScale.x > 0.50f)
                {
                    l1.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //right to back
                l2.position = Vector2.MoveTowards(l2.position, new Vector2(0, 0.50f), speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 3);
                if (l2.localScale.x > 0)
                {
                    l2.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 4)
            {
                //back to left
                l3.position = Vector2.MoveTowards(l3.position, new Vector2(-1, 0.31f), speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 2);
                if (l3.localScale.x < 0.50f)
                {
                    l3.localScale += new Vector3(speedScale, speedScale, 0);
                }
                else
                {
                    canChange = true;
                }
                //left to center
                l4.position = Vector2.MoveTowards(l4.position, new Vector2(0, 0), speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 1);
                if (l4.localScale.x < 1)
                {
                    l4.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to right
                l5.position = Vector2.MoveTowards(l5.position, new Vector3(1, 0.31f), speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 1);
                if (l5.localScale.x > 0.50f)
                {
                    l5.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //right to back
                l1.position = Vector2.MoveTowards(l1.position, new Vector2(0, 0.50f), speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 3);
                if (l1.localScale.x > 0)
                {
                    l1.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 3)
            {
                //back to left
                l2.position = Vector2.MoveTowards(l2.position, new Vector2(-1, 0.31f), speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 2);
                if (l2.localScale.x < 0.50f)
                {
                    l2.localScale += new Vector3(speedScale, speedScale, 0);
                }
                else
                {
                    canChange = true;
                }
                //left to center
                l3.position = Vector2.MoveTowards(l3.position, new Vector2(0, 0), speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 1);
                if (l3.localScale.x < 1)
                {
                    l3.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to right
                l4.position = Vector2.MoveTowards(l4.position, new Vector3(1, 0.31f), speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 1);
                if (l4.localScale.x > 0.50f)
                {
                    l4.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //right to back
                l5.position = Vector2.MoveTowards(l5.position, new Vector2(0, 0.50f), speedTime);
                l5.position = new Vector3(l5.position.x, l5.position.y, 3);
                if (l5.localScale.x > 0)
                {
                    l5.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
            else if (gVar.currentLocation == 2)
            {
                //back to left
                l1.position = Vector2.MoveTowards(l1.position, new Vector2(-1, 0.31f), speedTime);
                l1.position = new Vector3(l1.position.x, l1.position.y, 2);
                if (l1.localScale.x < 0.50f)
                {
                    l1.localScale += new Vector3(speedScale, speedScale, 0);
                }
                else
                {
                    canChange = true;
                }
                //left to center
                l2.position = Vector2.MoveTowards(l2.position, new Vector2(0, 0), speedTime);
                l2.position = new Vector3(l2.position.x, l2.position.y, 1);
                if (l2.localScale.x < 1)
                {
                    l2.localScale += new Vector3(speedScale, speedScale, 0);
                }
                //center to right
                l3.position = Vector2.MoveTowards(l3.position, new Vector3(1, 0.31f), speedTime);
                l3.position = new Vector3(l3.position.x, l3.position.y, 1);
                if (l3.localScale.x > 0.50f)
                {
                    l3.localScale -= new Vector3(speedScale, speedScale, 0);
                }
                //right to back
                l4.position = Vector2.MoveTowards(l4.position, new Vector2(0, 0.50f), speedTime);
                l4.position = new Vector3(l4.position.x, l4.position.y, 3);
                if (l4.localScale.x > 0)
                {
                    l4.localScale -= new Vector3(speedScale, speedScale, 0);
                }
            }
        }
    }

}

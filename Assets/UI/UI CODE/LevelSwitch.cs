using UnityEngine;
using System.Collections;

public class LevelSwitch : MonoBehaviour
{
    public GameObject level1, level2, level3, level4, level5;
    public SpriteRenderer leftSlider, rightSlider, continueButton;
    public Sprite lSlide, lSlidePressed, rSlide, rSlidePressed, cPressed;
    private Transform l1, l5, l4, l3, l2;
    
    private int level;
    private string loadingDir;
    private bool canChange;


    // Use this for initialization
    void Start()
    {
        l1 = level1.GetComponent<Transform>();
        l5 = level5.GetComponent<Transform>();
        l4 = level4.GetComponent<Transform>();
        l3 = level3.GetComponent<Transform>();
        l2 = level2.GetComponent<Transform>();

        gVar.currentLocation = 1;
        loadingDir = "stop";
        canChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        levelPressed("stop");

        if(Input.GetButtonDown("GSelect"))//level select, go to character select
        {
            //continueButton.sprite = cPressed;
            gVar.level = gVar.currentLocation;
            Application.LoadLevel("Character Select");
        }

    }

    public void levelPressed(string direction)
    {
        //right arrow button OR right bumper on controller OR right arrow is pressed and levels are not currently in rotation ROTATE LEFT
        if (((Input.GetButtonDown("Horizontal1") && Input.GetAxisRaw("Horizontal1") == 1) || direction.Equals("right") ||
            (Input.GetButtonDown("GMenu") && Input.GetAxisRaw("GMenu") == 1)) && canChange == true)
        {
            //rightSlider.sprite = rSlidePressed;
            gVar.currentLocation++;
            loadingDir = "left";
            canChange = false;
        }
        //left arrow button OR left bumper on controller OR left arrow is pressed and levels are not currently in rotation ROTATE RIGHT
        else if (((Input.GetButtonDown("Horizontal1") && Input.GetAxisRaw("Horizontal1") == -1) || direction.Equals("left") || 
            (Input.GetButtonDown("GMenu") && Input.GetAxisRaw("GMenu") == -1)) && canChange == true)
        {
            //leftSlider.sprite = lSlidePressed;
            gVar.currentLocation--;
            loadingDir = "right";
            canChange = false;
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
            BACK - Vector2.MoveTowards(l4.position, new Vector2(0, 0.5f), 0.02f); new Vector3(l4.position.x, l4.position.y, 3);
            RIGHT - Vector2.MoveTowards(l5.position, new Vector2(1, 0.185f), 0.02f); new Vector3(l5.position.x, l5.position.y, 2);
            CENTER - Vector2.MoveTowards(l1.position, new Vector2(0, -0.125F), 0.02f); new Vector3(l1.position.x, l1.position.y, 1);
            LEFT - Vector2.MoveTowards(l1.position, new Vector3(-1, 0.185f), 0.02f); new Vector3(l1.position.x, l1.position.y, 1);
            SCALE (GENERAL) - l4.localScale += new Vector3(0.01f, 0.01f, 0);
        */

        if (loadingDir.Equals("left"))
        {
            if (gVar.currentLocation == 2)
            {
                //back to right
                l3.position = Vector2.MoveTowards(l3.position, new Vector2(1, 0.31f), 0.02f);
                l3.position = new Vector3(l3.position.x, l3.position.y, 2);
                if (l3.localScale.x < 0.62)
                {
                    l3.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                else
                {
                    canChange = true;
                }
                //right to center
                l2.position = Vector2.MoveTowards(l2.position, new Vector2(0, 0), 0.02f);
                l2.position = new Vector3(l2.position.x, l2.position.y, 1);
                if (l2.localScale.x < 1)
                {
                    l2.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                //center to left
                l1.position = Vector2.MoveTowards(l1.position, new Vector3(-1, 0.31f), 0.02f);
                l1.position = new Vector3(l1.position.x, l1.position.y, 1);
                if (l1.localScale.x > 0.62)
                {
                    l1.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
                //left to back
                l5.position = Vector2.MoveTowards(l5.position, new Vector2(0, 0.62f), 0.02f);
                l5.position = new Vector3(l5.position.x, l5.position.y, 3);
                if (l5.localScale.x > 0)
                {
                    l5.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
            }
            else if (gVar.currentLocation == 3)
            {
                //back to right
                l4.position = Vector2.MoveTowards(l4.position, new Vector2(1, 0.31f), 0.02f);
                l4.position = new Vector3(l4.position.x, l4.position.y, 2);
                if (l4.localScale.x < 0.62)
                {
                    l4.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                else
                {
                    canChange = true;
                }
                //right to center
                l3.position = Vector2.MoveTowards(l3.position, new Vector2(0, 0), 0.02f);
                l3.position = new Vector3(l3.position.x, l3.position.y, 1);
                if (l3.localScale.x < 1)
                {
                    l3.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                //center to left
                l2.position = Vector2.MoveTowards(l2.position, new Vector3(-1, 0.31f), 0.02f);
                l2.position = new Vector3(l2.position.x, l2.position.y, 1);
                if (l2.localScale.x > 0.62)
                {
                    l2.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
                //left to back
                l1.position = Vector2.MoveTowards(l1.position, new Vector2(0, 0.62f), 0.02f);
                l1.position = new Vector3(l1.position.x, l1.position.y, 3);
                if (l1.localScale.x > 0)
                {
                    l1.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
            }
            else if (gVar.currentLocation == 4)
            {
                //back to right
                l5.position = Vector2.MoveTowards(l5.position, new Vector2(1, 0.31f), 0.02f);
                l5.position = new Vector3(l5.position.x, l5.position.y, 2);
                if (l5.localScale.x < 0.62)
                {
                    l5.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                else
                {
                    canChange = true;
                }
                //right to center
                l4.position = Vector2.MoveTowards(l4.position, new Vector2(0, 0), 0.02f);
                l4.position = new Vector3(l4.position.x, l4.position.y, 1);
                if (l4.localScale.x < 1)
                {
                    l4.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                //center to left
                l3.position = Vector2.MoveTowards(l3.position, new Vector3(-1, 0.31f), 0.02f);
                l3.position = new Vector3(l3.position.x, l3.position.y, 1);
                if (l3.localScale.x > 0.62)
                {
                    l3.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
                //left to back
                l2.position = Vector2.MoveTowards(l2.position, new Vector2(0, 0.62f), 0.02f);
                l2.position = new Vector3(l2.position.x, l2.position.y, 3);
                if (l2.localScale.x > 0)
                {
                    l2.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
            }
            else if (gVar.currentLocation == 5)
            {
                //back to right
                l1.position = Vector2.MoveTowards(l1.position, new Vector2(1, 0.31f), 0.02f);
                l1.position = new Vector3(l1.position.x, l1.position.y, 2);
                if (l1.localScale.x < 0.62)
                {
                    l1.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                else
                {
                    canChange = true;
                }
                //right to center
                l5.position = Vector2.MoveTowards(l5.position, new Vector2(0, 0), 0.02f);
                l5.position = new Vector3(l5.position.x, l5.position.y, 1);
                if (l5.localScale.x < 1)
                {
                    l5.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                //center to left
                l4.position = Vector2.MoveTowards(l4.position, new Vector3(-1, 0.31f), 0.02f);
                l4.position = new Vector3(l4.position.x, l4.position.y, 1);
                if (l4.localScale.x > 0.62)
                {
                    l4.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
                //left to back
                l3.position = Vector2.MoveTowards(l3.position, new Vector2(0, 0.62f), 0.02f);
                l3.position = new Vector3(l3.position.x, l3.position.y, 3);
                if (l3.localScale.x > 0)
                {
                    l3.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
            }
            else if (gVar.currentLocation == 1)
            {
                //back to right
                l2.position = Vector2.MoveTowards(l2.position, new Vector2(1, 0.31f), 0.02f);
                l2.position = new Vector3(l2.position.x, l2.position.y, 2);
                if (l2.localScale.x < 0.62)
                {
                    l2.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                else
                {
                    canChange = true;
                }
                //right to center
                l1.position = Vector2.MoveTowards(l1.position, new Vector2(0, 0), 0.02f);
                l1.position = new Vector3(l1.position.x, l1.position.y, 1);
                if (l1.localScale.x < 1)
                {
                    l1.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                //center to left
                l5.position = Vector2.MoveTowards(l5.position, new Vector3(-1, 0.31f), 0.02f);
                l5.position = new Vector3(l5.position.x, l5.position.y, 1);
                if (l5.localScale.x > 0.62)
                {
                    l5.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
                //left to back
                l4.position = Vector2.MoveTowards(l4.position, new Vector2(0, 0.62f), 0.02f);
                l4.position = new Vector3(l4.position.x, l4.position.y, 3);
                if (l4.localScale.x > 0)
                {
                    l4.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
            }
        }
        else if (loadingDir.Equals("right"))
        {
            if (gVar.currentLocation == 1)
            {
                //back to left
                l5.position = Vector2.MoveTowards(l5.position, new Vector2(-1, 0.31f), 0.02f);
                l5.position = new Vector3(l5.position.x, l5.position.y, 2);
                if (l5.localScale.x < 0.62)
                {
                    l5.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                else
                {
                    canChange = true;
                }
                //left to center
                l1.position = Vector2.MoveTowards(l1.position, new Vector2(0, 0), 0.02f);
                l1.position = new Vector3(l1.position.x, l1.position.y, 1);
                if (l1.localScale.x < 1)
                {
                    l1.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                //center to right
                l2.position = Vector2.MoveTowards(l2.position, new Vector3(1, 0.31f), 0.02f);
                l2.position = new Vector3(l2.position.x, l2.position.y, 1);
                if (l2.localScale.x > 0.62)
                {
                    l2.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
                //right to back
                l3.position = Vector2.MoveTowards(l3.position, new Vector2(0, 0.62f), 0.02f);
                l3.position = new Vector3(l3.position.x, l3.position.y, 3);
                if (l3.localScale.x > 0)
                {
                    l3.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
            }
            else if (gVar.currentLocation == 5)
            {
                //back to left
                l4.position = Vector2.MoveTowards(l4.position, new Vector2(-1, 0.31f), 0.02f);
                l4.position = new Vector3(l4.position.x, l4.position.y, 2);
                if (l4.localScale.x < 0.62)
                {
                    l4.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                else
                {
                    canChange = true;
                }
                //left to center
                l5.position = Vector2.MoveTowards(l5.position, new Vector2(0, 0), 0.02f);
                l5.position = new Vector3(l5.position.x, l5.position.y, 1);
                if (l5.localScale.x < 1)
                {
                    l5.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                //center to right
                l1.position = Vector2.MoveTowards(l1.position, new Vector3(1, 0.31f), 0.02f);
                l1.position = new Vector3(l1.position.x, l1.position.y, 1);
                if (l1.localScale.x > 0.62)
                {
                    l1.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
                //right to back
                l2.position = Vector2.MoveTowards(l2.position, new Vector2(0, 0.62f), 0.02f);
                l2.position = new Vector3(l2.position.x, l2.position.y, 3);
                if (l2.localScale.x > 0)
                {
                    l2.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
            }
            else if (gVar.currentLocation == 4)
            {
                //back to left
                l3.position = Vector2.MoveTowards(l3.position, new Vector2(-1, 0.31f), 0.02f);
                l3.position = new Vector3(l3.position.x, l3.position.y, 2);
                if (l3.localScale.x < 0.62)
                {
                    l3.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                else
                {
                    canChange = true;
                }
                //left to center
                l4.position = Vector2.MoveTowards(l4.position, new Vector2(0, 0), 0.02f);
                l4.position = new Vector3(l4.position.x, l4.position.y, 1);
                if (l4.localScale.x < 1)
                {
                    l4.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                //center to right
                l5.position = Vector2.MoveTowards(l5.position, new Vector3(1, 0.31f), 0.02f);
                l5.position = new Vector3(l5.position.x, l5.position.y, 1);
                if (l5.localScale.x > 0.62)
                {
                    l5.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
                //right to back
                l1.position = Vector2.MoveTowards(l1.position, new Vector2(0, 0.62f), 0.02f);
                l1.position = new Vector3(l1.position.x, l1.position.y, 3);
                if (l1.localScale.x > 0)
                {
                    l1.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
            }
            else if (gVar.currentLocation == 3)
            {
                //back to left
                l2.position = Vector2.MoveTowards(l2.position, new Vector2(-1, 0.31f), 0.02f);
                l2.position = new Vector3(l2.position.x, l2.position.y, 2);
                if (l2.localScale.x < 0.62)
                {
                    l2.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                else
                {
                    canChange = true;
                }
                //left to center
                l3.position = Vector2.MoveTowards(l3.position, new Vector2(0, 0), 0.02f);
                l3.position = new Vector3(l3.position.x, l3.position.y, 1);
                if (l3.localScale.x < 1)
                {
                    l3.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                //center to right
                l4.position = Vector2.MoveTowards(l4.position, new Vector3(1, 0.31f), 0.02f);
                l4.position = new Vector3(l4.position.x, l4.position.y, 1);
                if (l4.localScale.x > 0.62)
                {
                    l4.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
                //right to back
                l5.position = Vector2.MoveTowards(l5.position, new Vector2(0, 0.62f), 0.02f);
                l5.position = new Vector3(l5.position.x, l5.position.y, 3);
                if (l5.localScale.x > 0)
                {
                    l5.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
            }
            else if (gVar.currentLocation == 2)
            {
                //back to left
                l1.position = Vector2.MoveTowards(l1.position, new Vector2(-1, 0.31f), 0.02f);
                l1.position = new Vector3(l1.position.x, l1.position.y, 2);
                if (l1.localScale.x < 0.62)
                {
                    l1.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                else
                {
                    canChange = true;
                }
                //left to center
                l2.position = Vector2.MoveTowards(l2.position, new Vector2(0, 0), 0.02f);
                l2.position = new Vector3(l2.position.x, l2.position.y, 1);
                if (l2.localScale.x < 1)
                {
                    l2.localScale += new Vector3(0.0098f, 0.0098f, 0);
                }
                //center to right
                l3.position = Vector2.MoveTowards(l3.position, new Vector3(1, 0.31f), 0.02f);
                l3.position = new Vector3(l3.position.x, l3.position.y, 1);
                if (l3.localScale.x > 0.62)
                {
                    l3.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
                //right to back
                l4.position = Vector2.MoveTowards(l4.position, new Vector2(0, 0.62f), 0.02f);
                l4.position = new Vector3(l4.position.x, l4.position.y, 3);
                if (l4.localScale.x > 0)
                {
                    l4.localScale -= new Vector3(0.0098f, 0.0098f, 0);
                }
            }
        }
    }

}

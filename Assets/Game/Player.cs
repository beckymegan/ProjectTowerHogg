using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public bool isInvisible = false;
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    public int stunTime;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    Controller2D controller;

    public int playerNumber;

    int lives;
    int stunTimer;
    bool hurt = false;
    bool rocketShot;
    float gravity;
    float jumpVelocity;
    Vector2 input = new Vector2(0, 0);
    Vector3 velocity;
    float velocityXSmoothing;

    Material material;
    Renderer rend;
    Object shotRocket;
    Animator anim;

    public GameObject rocket;
    public GameObject heart5, heart4, heart3, heart2, heart1;
    public CanvasGroup gameOverScreen;
    public Sprite blueSprite, redSprite, greenSprite, purpleSprite;

    void Start ()
    {
        Time.timeScale = 1;//start time
        gameOverScreen.alpha = 0;
        anim = this.GetComponent<Animator>();

        controller = GetComponent<Controller2D>();

        //calculate jumpVelocity and gravity with some maths (Known: jumpHeight, timeToJumpApex && solve: gravity, jumpVelocity)
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        lives = 5;
        stunTimer = stunTime;
        rocketShot = false;

        SpriteRenderer rend = this.GetComponent<SpriteRenderer>();

        //character selection
        if (playerNumber == 1 && gVar.player1Exists == true)
        {
            if (gVar.player1 == "Green")
            {
                rend.sprite = greenSprite;
                anim.SetInteger("Color", 0);
            }
            else if (gVar.player1 == "Red")
            {
                rend.sprite = redSprite;
                anim.SetInteger("Color", 1);
            }
            else if (gVar.player1 == "Blue")
            {
                rend.sprite = blueSprite;
                anim.SetInteger("Color", 2);
            }
            else if (gVar.player1 == "Purple")
            {
                rend.sprite = purpleSprite;
                anim.SetInteger("Color", 3);
            }
        }
        else if (playerNumber == 2 && gVar.player2Exists == true)
        {
            if (gVar.player2 == "Green")
            {
                rend.sprite = greenSprite;
                anim.SetInteger("Color", 0);
            }
            else if (gVar.player2 == "Red")
            {
                rend.sprite = redSprite;
                anim.SetInteger("Color", 1);
            }
            else if (gVar.player2 == "Blue")
            {
                rend.sprite = blueSprite;
                anim.SetInteger("Color", 2);
            }
            else if (gVar.player2 == "Purple")
            {
                rend.sprite = purpleSprite;
                anim.SetInteger("Color", 3);
            }
        }
        else if (playerNumber == 3 && gVar.player3Exists == true)
        {
            if (gVar.player3 == "Green")
            {
                rend.sprite = greenSprite;
                anim.SetInteger("Color", 0);
            }
            else if (gVar.player3 == "Red")
            {
                rend.sprite = redSprite;
                anim.SetInteger("Color", 1);
            }
            else if (gVar.player3 == "Blue")
            {
                rend.sprite = blueSprite;
                anim.SetInteger("Color", 2);
            }
            else if (gVar.player3 == "Purple")
            {
                rend.sprite = purpleSprite;
                anim.SetInteger("Color", 3);
            }
        }
        else if (playerNumber == 4 && gVar.player4Exists == true)
        {
            if (gVar.player4 == "Green")
            {
                rend.sprite = greenSprite;
                anim.SetInteger("Color", 0);
            }
            else if (gVar.player4 == "Red")
            {
                rend.sprite = redSprite;
                anim.SetInteger("Color", 1);
            }
            else if (gVar.player4 == "Blue")
            {
                rend.sprite = blueSprite;
                anim.SetInteger("Color", 2);
            }
            else if (gVar.player4 == "Purple")
            {
                rend.sprite = purpleSprite;
                anim.SetInteger("Color", 3);
            }
        }
        anim.SetBool("isWalkingLeft", false);
        anim.SetBool("isWalkingRight", false);
    }

    void Update()
    {
        anim.SetInteger("isShooting", 0);

        //count through hit timer, revert to un hurt after finished
        if (stunTimer != stunTime)
        {
            stunTimer++;
            hurt = true;
        }
        else
        {
            hurt = false;
            anim.SetBool("isHurtRight", false);
            anim.SetBool("isHurtLeft", false);
        }
            //is player hitting roof or on ground
            if (controller.collisions.above || controller.collisions.below)
            {
                velocity.y = 0;
            }

            this.health(); //calculate health


        if (hurt == false)
        {
            //Player 1
            if (playerNumber == 1 && gVar.player1Exists == true)
            {
                gVar.location1 = this.GetComponent<Transform>().position;
                input = new Vector2(Input.GetAxisRaw("Horizontal1"), 0);

                if (Input.GetAxisRaw("Horizontal1") > 0)
                {
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", true);
                }
                else if (Input.GetAxisRaw("Horizontal1") < 0)
                {
                    anim.SetBool("isWalkingRight", false);
                    anim.SetBool("isWalkingLeft", true);
                }
                else
                {
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", false);
                }


                if (Input.GetButtonDown("Jump1") && Mathf.Abs(velocity.y) < 1f)//jump
                {
                    velocity.y = jumpVelocity;
                }

                if (Mathf.Abs(velocity.y) > 1)//change to jump animation
                {
                    anim.SetBool("isJumping", true);
                }
                else if (controller.collisions.below == true)
                {
                    anim.SetBool("isJumping", false);
                }

                //if rocket shot by player still exists
                if (GameObject.Find("rocketP1") != null)
                {
                    rocketShot = true;
                }
                else
                {
                    rocketShot = false;
                }

                //check if rocket hasn't been destroyed yet
                if (rocketShot == false)
                {
                    //depending on button pressed, spawn rocket that travels in direction chosen
                    if (Input.GetButtonDown("ShootLeft1"))
                    {
                        shotRocket = Instantiate(rocket, new Vector3(this.transform.position.x - 1f, this.transform.position.y), Quaternion.identity);
                        gVar.direction = "left";
                        rocketShot = true;
                        anim.SetInteger("isShooting", 1);
                        //name rocket
                        shotRocket.name = "rocketP1";
                    }

                    if (Input.GetButtonDown("ShootRight1"))
                    {
                        shotRocket = Instantiate(rocket, new Vector3(this.transform.position.x + 1f, this.transform.position.y), Quaternion.identity);
                        gVar.direction = "right";
                        rocketShot = true;
                        anim.SetInteger("isShooting", 2);
                        //name rocket
                        shotRocket.name = "rocketP1";
                    }
                }

            }
            //Player #2
            else if (playerNumber == 2 && gVar.player2Exists == true)
            {
                gVar.location2 = this.GetComponent<Transform>().position;
                input = new Vector2(Input.GetAxisRaw("Horizontal2"),0);

                if (Input.GetAxisRaw("Horizontal2") > 0)
                {
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", true);
                }
                else if (Input.GetAxisRaw("Horizontal2") < 0)
                {
                    anim.SetBool("isWalkingRight", false);
                    anim.SetBool("isWalkingLeft", true);
                }
                else
                {
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", false);
                }
                
                if (Input.GetButtonDown("Jump2") && Mathf.Abs(velocity.y) < 1f)//jump
                {
                    velocity.y = jumpVelocity;
                }

                if (Mathf.Abs(velocity.y) > 1)//change to jump animation
                {
                    anim.SetBool("isJumping", true);
                }
                else if (controller.collisions.below == true)
                {
                    anim.SetBool("isJumping", false);
                }

                //if rocket shot by player still exists
                if (GameObject.Find("rocketP2") != null)
                {
                    rocketShot = true;
                }
                else
                {
                    rocketShot = false;
                }

                //check if rocket hasn't been destroyed yet
                if (rocketShot == false)
                {
                    //depending on button pressed, spawn rocket that travels in direction chosen
                    if (Input.GetButtonDown("ShootLeft2"))
                    {
                        shotRocket = Instantiate(rocket, new Vector3(this.transform.position.x - 1f, this.transform.position.y), Quaternion.identity);
                        gVar.direction = "left";
                        rocketShot = true;
                        anim.SetInteger("isShooting", 1);
                        //name rocket
                        shotRocket.name = "rocketP2";
                    }

                    if (Input.GetButtonDown("ShootRight2"))
                    {
                        shotRocket = Instantiate(rocket, new Vector3(this.transform.position.x + 1f, this.transform.position.y), Quaternion.identity);
                        gVar.direction = "right";
                        rocketShot = true;
                        anim.SetInteger("isShooting", 2);
                        //name rocket
                        shotRocket.name = "rocketP2";
                    }
                }
            }

            //Player #3
            else if (playerNumber == 3 && gVar.player3Exists == true)
            {
                gVar.location3 = this.GetComponent<Transform>().position;
                input = new Vector2(Input.GetAxisRaw("Horizontal3"),0);

                if (Input.GetAxisRaw("Horizontal3") > 0)
                {
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", true);
                }
                else if (Input.GetAxisRaw("Horizontal3") < 0)
                {
                    anim.SetBool("isWalkingRight", false);
                    anim.SetBool("isWalkingLeft", true);
                }
                else
                {
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", false);
                }

                if (Input.GetButtonDown("Jump3") && Mathf.Abs(velocity.y) < 1f)//jump
                {
                    velocity.y = jumpVelocity;
                }

                if (Mathf.Abs(velocity.y) > 1)//change to jump animation
                {
                    anim.SetBool("isJumping", true);
                }
                else if (controller.collisions.below == true)
                {
                    anim.SetBool("isJumping", false);
                }

                //if rocket shot by player still exists
                if (GameObject.Find("rocketP3") != null)
                {
                    rocketShot = true;
                }
                else
                {
                    rocketShot = false;
                }

                //check if rocket hasn't been destroyed yet
                if (rocketShot == false)
                {
                    //depending on button pressed, spawn rocket that travels in direction chosen
                    if (Input.GetButtonDown("ShootLeft3"))
                    {
                        shotRocket = Instantiate(rocket, new Vector3(this.transform.position.x - 1f, this.transform.position.y), Quaternion.identity);
                        gVar.direction = "left";
                        rocketShot = true;
                        anim.SetInteger("isShooting", 1);
                        //name rocket
                        shotRocket.name = "rocketP3";
                    }

                    if (Input.GetButtonDown("ShootRight3"))
                    {
                        shotRocket = Instantiate(rocket, new Vector3(this.transform.position.x + 1f, this.transform.position.y), Quaternion.identity);
                        gVar.direction = "right";
                        rocketShot = true;
                        anim.SetInteger("isShooting", 2);
                        //name rocket
                        shotRocket.name = "rocketP3";
                    }
                }
            }

            //Player #4
            else if (playerNumber == 4 && gVar.player4Exists == true)
            {
                gVar.location2 = this.GetComponent<Transform>().position;
                input = new Vector2(Input.GetAxisRaw("Horizontal4"),0);

                if (Input.GetAxisRaw("Horizontal4") > 0)
                {
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", true);
                }
                else if (Input.GetAxisRaw("Horizontal4") < 0)
                {
                    anim.SetBool("isWalkingRight", false);
                    anim.SetBool("isWalkingLeft", true);
                }
                else
                {
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", false);
                }

                if (Input.GetButtonDown("Jump4") && Mathf.Abs(velocity.y) < 1f)//jump
                {
                    velocity.y = jumpVelocity;
                }

                if (Mathf.Abs(velocity.y) > 1)//change to jump animation
                {
                    anim.SetBool("isJumping", true);
                }
                else if (controller.collisions.below == true)
                {
                    anim.SetBool("isJumping", false);
                }

                //if rocket shot by player still exists
                if (GameObject.Find("rocketP4") != null)
                {
                    rocketShot = true;
                }
                else
                {
                    rocketShot = false;
                }

                //check if rocket hasn't been destroyed yet
                if (rocketShot == false)
                {
                    //depending on button pressed, spawn rocket that travels in direction chosen
                    if (Input.GetButtonDown("ShootLeft4"))
                    {
                        shotRocket = Instantiate(rocket, new Vector3(this.transform.position.x - 1f, this.transform.position.y), Quaternion.identity);
                        gVar.direction = "left";
                        rocketShot = true;
                        anim.SetInteger("isShooting", 1);
                        //name rocket
                        shotRocket.name = "rocketP4";
                    }

                    if (Input.GetButtonDown("ShootRight4"))
                    {
                        shotRocket = Instantiate(rocket, new Vector3(this.transform.position.x + 1f, this.transform.position.y), Quaternion.identity);
                        gVar.direction = "right";
                        rocketShot = true;
                        anim.SetInteger("isShooting", 2);
                        //name rocket
                        shotRocket.name = "rocketP4";
                    }
                }
            }
            //smooth movements
            float targetVelocityX = input.x * moveSpeed;
            //                                                                                 if player is on the ground use ATGrounded, if in the air use ATAirbourne
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        } else
        {
            velocity.x = input.x * 1.5f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Rocket")//if hit by rocket, lose life & play sound
        {
            if(coll.gameObject.GetComponent<Rocket>().getDirection() == "right")
            {
                anim.SetBool("isHurtRight", true);
                controller.Move(new Vector2(20, 15) * Time.deltaTime);
            }
            else if (coll.gameObject.GetComponent<Rocket>().getDirection() == "left")
            {
                anim.SetBool("isHurtLeft", true);
                controller.Move(new Vector2(-20, 15) * Time.deltaTime);
            }
            else if (coll.gameObject.GetComponent<Rocket>().getDirection() == "up")
            {
                controller.Move(new Vector2(0, 15) * Time.deltaTime);
            }
            lives--;
            stunTimer = 0;
        }
    }

    //calculates and displays number of hearts for each character
    void health()
    {
        if (lives == 4)
        {
            Destroy(heart5);
        }
        else if (lives == 3)
        {
            Destroy(heart4);
        }
        else if (lives == 2)
        {
            Destroy(heart3);
        }
        else if (lives == 1)
        {
            Destroy(heart2);
        }
        else if (lives == 0)
        {
            Destroy(heart1);
            Time.timeScale = 0;
            gameOverScreen.alpha = 1;
            this.transform.Translate(-50, -50, 0);
            if (Input.GetButton("Jump1")||Input.GetButton("Jump2") || Input.GetButton("Jump3") || Input.GetButton("Jump4"))
            {
                Application.LoadLevel(Application.loadedLevelName);
                Time.timeScale = 1;
            }
        }
    }
        
    void OnBecameInvisible()//if invisible loop to other x/y direction
    {
        if(this.GetComponent<Transform>().position.y < -11)//if invisible under -11 (bottom) reverse y
        {
            Vector3 location = new Vector3(this.GetComponent<Transform>().position.x, (-1) * (this.GetComponent<Transform>().position.y), 0);
            this.GetComponent<Transform>().position = location;
        }
        else if (this.GetComponent<Transform>().position.y > 12)//if invisible above 12 (top) reverse y and subtract a bit
        {
            Vector3 location = new Vector3(this.GetComponent<Transform>().position.x, (-1) * (this.GetComponent<Transform>().position.y-1), 0);
            this.GetComponent<Transform>().position = location;
        }
        else //if invisible and  between 5 and -5 (eg left or right) reverse x
        {
            Vector3 location = new Vector3((-1)*(this.GetComponent<Transform>().position.x),this.GetComponent<Transform>().position.y, 0);
            this.GetComponent<Transform>().position = location;
        }
    }

    public void loseHealth() //drop lives by 1 when run
    {
        lives--;
    }

}

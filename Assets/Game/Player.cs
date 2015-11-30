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
    public Player otherPlayer1;
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

        rend = GetComponent<Renderer>();

        //character selection
        if (playerNumber == 1) {
            if (gVar.player1 == "Green")
            {
                anim.SetInteger("Color", 0);
            }
            else if (gVar.player1 == "Red")
            {
                anim.SetInteger("Color", 1);
            }
            else if (gVar.player1 == "Blue")
            {
                anim.SetInteger("Color", 2);
            }
            else if (gVar.player1 == "Purple")
            {
                anim.SetInteger("Color", 3);
            }
        }
        else if (playerNumber == 2)
        {
            if (gVar.player2 == "Green")
            {
                anim.SetInteger("Color", 0);
            }
            else if (gVar.player2 == "Red")
            {
                anim.SetInteger("Color", 1);
            }
            else if (gVar.player2 == "Blue")
            {
                anim.SetInteger("Color", 2);
            }
            else if (gVar.player2 == "Purple")
            {
                anim.SetInteger("Color", 3);
            }
        }
        anim.SetBool("isWalkingLeft", false);
        anim.SetBool("isWalkingRight", false);
    }

    void Update()
    {
        //Debug.Log(velocity.y);
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
            if (playerNumber == 1)
            {
                gVar.location1 = this.GetComponent<Transform>().position;
                input = new Vector2(Input.GetAxisRaw("Horizontal1"), Input.GetAxisRaw("Vertical1"));

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


                if (Input.GetButtonDown("Jump1") && Mathf.Abs(velocity.y) < 0.5)//jump
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
                    if (Input.GetButtonDown("ShootUp1"))
                    {
                        shotRocket = Instantiate(rocket, new Vector3(this.transform.position.x, this.transform.position.y + 1f), Quaternion.identity);
                        gVar.direction = "up";
                        rocketShot = true;
                        //name and brand rocket
                        shotRocket.name = "rocketP1";
                    }

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
            else if (playerNumber == 2)
            {
                gVar.location2 = this.GetComponent<Transform>().position;
                input = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));

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
                
                if (Input.GetButtonDown("Jump2") && Mathf.Abs(velocity.y) < 0.5)//jump
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
                    if (Input.GetButtonDown("ShootUp2"))
                    {
                        shotRocket = Instantiate(rocket, new Vector3(this.transform.position.x, this.transform.position.y + 1f), Quaternion.identity);
                        gVar.direction = "up";
                        rocketShot = true;
                        //name rocket
                        shotRocket.name = "rocketP2";
                    }

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
            otherPlayer1.transform.Translate(-50, -50, 0);
            if (Input.GetButton("Jump1")||Input.GetButton("Jump2"))
            {
                Application.LoadLevel(Application.loadedLevelName);
                Time.timeScale = 1;
            }
        }
    }
        
    void OnBecameInvisible()//if invisible loop to other x/y direction
    {
        if(this.GetComponent<Transform>().position.y>10 || this.GetComponent<Transform>().position.y < -10)//if invisible and above 5/under -5 (eg top or bottom) reverse y
        {
            Vector3 location = new Vector3(this.GetComponent<Transform>().position.x, (-1) * (this.GetComponent<Transform>().position.y), 0);
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

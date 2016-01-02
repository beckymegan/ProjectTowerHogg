using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{

    public bool isInvisible = false;
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    public int stunTime;
    public int rocketShots;
    public AudioClip pickupsound;
    
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    Controller2D controller;

    public int playerNumber;

    int lives, color;
    int stunTimer;
    bool hurt = false;
    float gravity;
    float jumpVelocity;
    Vector2 input = new Vector2(0, 0);
    Vector3 velocity;
    float velocityXSmoothing;

    Material material;
    Renderer rend;
    Object shotRocket;
    Animator anim;
    AudioSource audio;

    public GameObject rocket, objLives;
    public CanvasGroup gameOverScreen;
    public Sprite blueSprite, redSprite, greenSprite, purpleSprite;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        Time.timeScale = 1;//start time
        gameOverScreen.alpha = 0;
        anim = this.GetComponent<Animator>();

        controller = GetComponent<Controller2D>();

        //calculate jumpVelocity and gravity with some maths (Known: jumpHeight, timeToJumpApex && solve: gravity, jumpVelocity)
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        lives = 5;
        stunTimer = stunTime;

        SpriteRenderer rend = this.GetComponent<SpriteRenderer>();

        //character selection
        if (playerNumber == 1 && gVar.player1Exists == true)//if player is player1 and player1 exists
        {
            if (gVar.player1 == "Green")//check if player1 is registered as green
            {
                //if green, change sprite to green, increase number of possible green team shots by one and start
                rend.sprite = greenSprite;
                gVar.greenShots++;
                anim.SetInteger("Color", 0);
                color = 0;
            }
            else if (gVar.player1 == "Red")
            {
                rend.sprite = redSprite;
                gVar.redShots++;
                anim.SetInteger("Color", 1);
                color = 1;
            }
            else if (gVar.player1 == "Blue")
            {
                rend.sprite = blueSprite;
                gVar.blueShots++;
                anim.SetInteger("Color", 2);
                color = 2;
            }
            else if (gVar.player1 == "Purple")
            {
                rend.sprite = purpleSprite;
                gVar.purpleShots++;
                anim.SetInteger("Color", 3);
                color = 3;
            }
        }
        else if (playerNumber == 2 && gVar.player2Exists == true)
        {
            if (gVar.player2 == "Green")
            {
                rend.sprite = greenSprite;
                gVar.greenShots++;
                anim.SetInteger("Color", 0);
                color = 0;
            }
            else if (gVar.player2 == "Red")
            {
                rend.sprite = redSprite;
                gVar.redShots++;
                anim.SetInteger("Color", 1);
                color = 1;
            }
            else if (gVar.player2 == "Blue")
            {
                rend.sprite = blueSprite;
                gVar.blueShots++;
                anim.SetInteger("Color", 2);
                color = 2;
            }
            else if (gVar.player2 == "Purple")
            {
                rend.sprite = purpleSprite;
                gVar.purpleShots++;
                anim.SetInteger("Color", 3);
                color = 3;
            }
        }
        else if (playerNumber == 3 && gVar.player3Exists == true)
        {
            if (gVar.player3 == "Green")
            {
                rend.sprite = greenSprite;
                gVar.greenShots++;
                anim.SetInteger("Color", 0);
                color = 0;
            }
            else if (gVar.player3 == "Red")
            {
                rend.sprite = redSprite;
                gVar.redShots++;
                anim.SetInteger("Color", 1);
                color = 1;
            }
            else if (gVar.player3 == "Blue")
            {
                rend.sprite = blueSprite;
                gVar.blueShots++;
                anim.SetInteger("Color", 2);
                color = 2;
            }
            else if (gVar.player3 == "Purple")
            {
                rend.sprite = purpleSprite;
                gVar.purpleShots++;
                anim.SetInteger("Color", 3);
                color = 3;
            }
        }
        else if (playerNumber == 4 && gVar.player4Exists == true)
        {
            if (gVar.player4 == "Green")
            {
                rend.sprite = greenSprite;
                gVar.greenShots++;
                anim.SetInteger("Color", 0);
                color = 0;
            }
            else if (gVar.player4 == "Red")
            {
                rend.sprite = redSprite;
                gVar.redShots++;
                anim.SetInteger("Color", 1);
                color = 1;
            }
            else if (gVar.player4 == "Blue")
            {
                rend.sprite = blueSprite;
                gVar.blueShots++;
                anim.SetInteger("Color", 2);
                color = 2;
            }
            else if (gVar.player4 == "Purple")
            {
                rend.sprite = purpleSprite;
                gVar.purpleShots++;
                anim.SetInteger("Color", 3);
                color = 3;
            }
        }
        //set player to standing by making both isWalkingLeft and isWalkingRight false
        anim.SetBool("isWalkingLeft", false);
        anim.SetBool("isWalkingRight", false);
    }

    void Update()
    {
        anim.SetInteger("isShooting", 0);//timer to 

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
                //move player and set animations for movement
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

                if (Input.GetButtonDown("ShootLeft1"))
                {
                    shootLeft();
                }

                if (Input.GetButtonDown("ShootRight1"))
                {
                    shootRight();
                }
            }

            //Player #2
            else if (playerNumber == 2 && gVar.player2Exists == true)
            {
                gVar.location2 = this.GetComponent<Transform>().position;
                input = new Vector2(Input.GetAxisRaw("Horizontal2"), 0);

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

                if (Input.GetButtonDown("ShootLeft2"))
                {
                    shootLeft();
                }

                if (Input.GetButtonDown("ShootRight2"))
                {
                    shootRight();
                }

            }

            //Player #3
            else if (playerNumber == 3 && gVar.player3Exists == true)
            {
                gVar.location3 = this.GetComponent<Transform>().position;
                input = new Vector2(Input.GetAxisRaw("Horizontal3"), 0);

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

                if (Input.GetButtonDown("ShootLeft3"))
                {
                    shootLeft();
                }

                if (Input.GetButtonDown("ShootRight3"))
                {
                    shootRight();
                }
            }

            //Player #4
            else if (playerNumber == 4 && gVar.player4Exists == true)
            {
                gVar.location2 = this.GetComponent<Transform>().position;
                input = new Vector2(Input.GetAxisRaw("Horizontal4"), 0);

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

                if (Input.GetButtonDown("ShootLeft4"))
                {
                    shootLeft();
                }

                if (Input.GetButtonDown("ShootRight4"))
                {
                    shootRight();
                }
            }
            //smooth movements
            float targetVelocityX = input.x * moveSpeed;
            //                                                                                 if player is on the ground use ATGrounded, if in the air use ATAirbourne
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        }
        else
        {
            velocity.x = input.x * 1.5f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);

        //Reset level if health is equal to 0 and A/Space is pressed
        if (Input.GetButton("GStart") && lives == 0)
        {
            gVar.resetVars();
            SceneManager.LoadScene("Level Select");
            Time.timeScale = 1;
        }

    }

    void shootLeft()//shoot ball left (shootRight is the same with directions changed)
    {
        gVar.direction = "left";
        if (color == 0 && gVar.greenShots > 0)
        {//if color is green and green has more than one shot left
            gVar.greenShots--;//drop shots by one
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x - 0.95f, this.transform.position.y), Quaternion.identity);//create green ball moving left
            shotRocket.GetComponent<Rocket>().color(color);//color ball green
        }
        else if (color == 1 && gVar.redShots > 0)
        {
            gVar.redShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x - 0.95f, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
        }
        else if (color == 2 && gVar.blueShots > 0)
        {
            gVar.blueShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x - 0.95f, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
        }
        else if (color == 3 && gVar.purpleShots > 0)
        {
            gVar.purpleShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x - 0.95f, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
        }
        anim.SetInteger("isShooting", 1);
    }

    void shootRight()
    {
        gVar.direction = "right";
        if (color == 0 && gVar.greenShots > 0)
        {
            gVar.greenShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x + 0.95f, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
        }
        else if (color == 1 && gVar.redShots > 0)
        {
            gVar.redShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x + 0.95f, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
        }
        else if (color == 2 && gVar.blueShots > 0)
        {
            gVar.blueShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x + 0.95f, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
        }
        else if (color == 3 && gVar.purpleShots > 0)
        {
            gVar.purpleShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x + 0.95f, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
        }
        anim.SetInteger("isShooting", 2);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Ball"))
        {
            audio.PlayOneShot(pickupsound, 1f);
            if (coll.gameObject.gameObject.GetComponent<Rocket>().colorShot != this.color)//if player color doesn't match ball color, lose health
            {
                loseHealth();
            }
        }
    }

    //calculates and displays number of hearts for each character
    void health()
    {
        if (lives > 0)
        {
            objLives.GetComponent<Transform>().position = new Vector2(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y + 1.3f);
            objLives.GetComponent<updateLives>().livesUpdate(playerNumber, lives);
        }
        else if (lives == 0)
        {
            Destroy(objLives);
            Time.timeScale = 0;
            gameOverScreen.alpha = 1;
            this.transform.Translate(-50, -50, 0);
        }
    }

    void OnBecameInvisible()//if invisible loop to other x/y direction
    {
        if (this.GetComponent<Transform>().position.y < -11)//if invisible under -11 (bottom) reverse y
        {
            Vector3 location = new Vector3(this.GetComponent<Transform>().position.x, (-1) * (this.GetComponent<Transform>().position.y), 0);
            this.GetComponent<Transform>().position = location;
        }
        else if (this.GetComponent<Transform>().position.y > 12)//if invisible above 12 (top) reverse y and subtract a bit
        {
            Vector3 location = new Vector3(this.GetComponent<Transform>().position.x, (-1) * (this.GetComponent<Transform>().position.y - 1), 0);
            this.GetComponent<Transform>().position = location;
        }
        else //if invisible and  between 5 and -5 (eg left or right) reverse x
        {
            Vector3 location = new Vector3((-1) * (this.GetComponent<Transform>().position.x), this.GetComponent<Transform>().position.y, 0);
            this.GetComponent<Transform>().position = location;
        }
    }

    public void loseHealth() //drop lives by 1 when run
    {
        lives--;
    }

}

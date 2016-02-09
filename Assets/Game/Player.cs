﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    public bool isInvisible = false;
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    public float startX, startY;
    public int stunTime, playerNumber, color = 1;

    public AudioClip pickupAudio, painAudio, throwAudio, jumpAudio;
    public GameObject playerParticleSystem, rocket, objLives, shield;
    public Sprite greenSprite, redSprite, blueSprite, purpleSprite;
    public Material materialSelf;
    public Vector3[] possibleRespawnLocations = new Vector3[5];

    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float gravity, jumpVelocity, velocityXSmoothing, bufferDistance;
    float moveSpeed = 6;
    int lives = 5;
    int stunTimer;
    bool hurt = false;

    Controller2D controller;
    Vector2 input = new Vector2(0, 0);
    Vector3 velocity;
    Material material;
    Renderer rend;
    Object shotRocket;
    Shield playerShield;
    Animator anim;
    AudioSource audio;
    Color GREEN, RED, BLUE, PURPLE;
    Color colorSelf;

    void Start()
    {
        //set number of players
        gVar.numberPlayers = gVar.readyPlayers;

        //set colors
        GREEN = new Color(0.435f, 0.768f, 0.662f);
        RED = new Color(0.945f, 0.611f, 0.717f);
        BLUE = new Color(0.553f, 0.710f, 0.906f);
        PURPLE = new Color(0.615f, 0.611f, 0.945f);

        audio = GetComponent<AudioSource>();
        Time.timeScale = 1;//start time
        anim = this.GetComponent<Animator>();

        controller = GetComponent<Controller2D>();

        //calculate jumpVelocity and gravity with some maths (Known: jumpHeight, timeToJumpApex && solve: gravity, jumpVelocity)
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        SpriteRenderer rend = this.GetComponent<SpriteRenderer>();
        //character selection
        if (playerNumber == 1 && gVar.player1Exists == true)//if player is player1 and player1 exists
        {
            if (gVar.player1 == "Green")//check if player1 is registered as green
            {
                //if green, change sprite to green, increase number of possible green team shots by one, set particle color and start
                rend.sprite = greenSprite;
                anim.SetInteger("Color", 1);
                color = 0;
                colorSelf = GREEN;
            }
            else if (gVar.player1 == "Red")
            {
                rend.sprite = redSprite;
                anim.SetInteger("Color", 2);
                color = 1;
                colorSelf = RED;
            }
            else if (gVar.player1 == "Blue")
            {
                rend.sprite = blueSprite;
                anim.SetInteger("Color", 3);
                color = 2;
                colorSelf = BLUE;
            }
            else if (gVar.player1 == "Purple")
            {
                rend.sprite = purpleSprite;
                anim.SetInteger("Color", 4);
                color = 3;
                colorSelf = PURPLE;
            }
        }
        else if (playerNumber == 2 && gVar.player2Exists == true)
        {
            if (gVar.player2 == "Green")
            {
                rend.sprite = greenSprite;
                anim.SetInteger("Color", 1);
                color = 0;
                colorSelf = GREEN;
            }
            else if (gVar.player2 == "Red")
            {
                rend.sprite = redSprite;
                anim.SetInteger("Color", 2);
                color = 1;
                colorSelf = RED;
            }
            else if (gVar.player2 == "Blue")
            {
                rend.sprite = blueSprite;
                anim.SetInteger("Color", 3);
                color = 2;
                colorSelf = BLUE;
            }
            else if (gVar.player2 == "Purple")
            {
                rend.sprite = purpleSprite;
                anim.SetInteger("Color", 4);
                color = 3;
                colorSelf = PURPLE;
            }
        }
        else if (playerNumber == 3 && gVar.player3Exists == true)
        {
            if (gVar.player3 == "Green")
            {
                rend.sprite = greenSprite;
                anim.SetInteger("Color", 1);
                color = 0;
                colorSelf = GREEN;
            }
            else if (gVar.player3 == "Red")
            {
                rend.sprite = redSprite;
                anim.SetInteger("Color", 2);
                color = 1;
                colorSelf = RED;
            }
            else if (gVar.player3 == "Blue")
            {
                rend.sprite = blueSprite;
                anim.SetInteger("Color", 3);
                color = 2;
                colorSelf = BLUE;
            }
            else if (gVar.player3 == "Purple")
            {
                rend.sprite = purpleSprite;
                anim.SetInteger("Color", 4);
                color = 3;
                colorSelf = PURPLE;
            }
        }
        else if (playerNumber == 4 && gVar.player4Exists == true)
        {
            if (gVar.player4 == "Green")
            {
                rend.sprite = greenSprite;
                anim.SetInteger("Color", 1);
                color = 0;
                colorSelf = GREEN;
            }
            else if (gVar.player4 == "Red")
            {
                rend.sprite = redSprite;
                anim.SetInteger("Color", 2);
                color = 1;
                colorSelf = RED;
            }
            else if (gVar.player4 == "Blue")
            {
                rend.sprite = blueSprite;
                anim.SetInteger("Color", 3);
                color = 2;
                colorSelf = BLUE;
            }
            else if (gVar.player4 == "Purple")
            {
                rend.sprite = purpleSprite;
                anim.SetInteger("Color", 4);
                color = 3;
                colorSelf = PURPLE;
            }
        }

        //set player to standing by making both isWalkingLeft and isWalkingRight false
        anim.SetBool("isWalkingLeft", false);
        anim.SetBool("isWalkingRight", false);
    }

    void Update()
    {
        gVar.optionTime++;

        anim.SetInteger("isShooting", 0);

        //is player hitting roof or on ground
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        this.health(); //calculate health

        if (Time.timeScale == 1)
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

                if (Input.GetButtonDown("Jump1") && Mathf.Abs(velocity.y) < 1f && gVar.optionTime > 25)//jump
                {
                    //play jump audio
                    audio.PlayOneShot(jumpAudio, gVar.volume * 0.85f);

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

                if (Input.GetButtonDown("Jump2") && Mathf.Abs(velocity.y) < 1f && gVar.optionTime > 25)//jump if jump is pressed, velocity is 0, and suffient time has passed since options menu close
                {
                    //play jump audio
                    audio.PlayOneShot(jumpAudio, gVar.volume * 0.85f);

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

                if (Input.GetButtonDown("Jump3") && Mathf.Abs(velocity.y) < 1f && gVar.optionTime > 25)//jump
                {
                    //play jump audio
                    audio.PlayOneShot(jumpAudio, gVar.volume * 0.85f);

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

                if (Input.GetButtonDown("Jump4") && Mathf.Abs(velocity.y) < 1f && gVar.optionTime > 25)//jump
                {
                    //play jump audio
                    audio.PlayOneShot(jumpAudio, gVar.volume * 0.85f);

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
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    public void Unhurt()
    {
        hurt = false;
    }

    void shootLeft()//shoot ball left (shootRight is the same with directions changed)
    {
        if (hurt == true)//if player has shield make bufferdistance further away than if no shield is present
        {
            bufferDistance = 1.6f;
        }
        else
        {
            bufferDistance = 1f;
        }

        gVar.direction = "left";
        if (color == 0 && gVar.greenShots > 0)
        {//if color is green and green has more than one shot left
            gVar.greenShots--;//drop shots by one
            //create green ball moving left that starts bufferDistance away from player
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x - bufferDistance, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);//color ball green
            audio.PlayOneShot(throwAudio, gVar.volume); //play throw sound
        }
        else if (color == 1 && gVar.redShots > 0)
        {
            gVar.redShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x - bufferDistance, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
            audio.PlayOneShot(throwAudio, gVar.volume); //play throw sound
        }
        else if (color == 2 && gVar.blueShots > 0)
        {
            gVar.blueShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x - bufferDistance, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
            audio.PlayOneShot(throwAudio, gVar.volume); //play throw sound
        }
        else if (color == 3 && gVar.purpleShots > 0)
        {
            gVar.purpleShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x - bufferDistance, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
            audio.PlayOneShot(throwAudio, gVar.volume); //play throw sound
        }
        anim.SetInteger("isShooting", 1);
    }

    void shootRight()//same as left but right
    {
        if (hurt == true)
        {
            bufferDistance = 1.6f;
        }
        else
        {
            bufferDistance = 1f;
        }

        gVar.direction = "right";
        if (color == 0 && gVar.greenShots > 0)
        {
            gVar.greenShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x + bufferDistance, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
            audio.PlayOneShot(throwAudio, gVar.volume); //play throw sound
        }
        else if (color == 1 && gVar.redShots > 0)
        {
            gVar.redShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x + bufferDistance, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
            audio.PlayOneShot(throwAudio, gVar.volume); //play throw sound
        }
        else if (color == 2 && gVar.blueShots > 0)
        {
            gVar.blueShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x + bufferDistance, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
            audio.PlayOneShot(throwAudio, gVar.volume); //play throw sound
        }
        else if (color == 3 && gVar.purpleShots > 0)
        {
            gVar.purpleShots--;
            GameObject shotRocket = (GameObject)Instantiate(rocket, new Vector3(this.transform.position.x + bufferDistance, this.transform.position.y), Quaternion.identity);
            shotRocket.GetComponent<Rocket>().color(color);
            audio.PlayOneShot(throwAudio, gVar.volume); //play throw sound
        }
        anim.SetInteger("isShooting", 2);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Material particleColor = new Material(materialSelf);
        particleColor.SetColor("_EmissionColor", colorSelf);
        if (coll.gameObject.tag.Equals("Ball"))
        {
            if (coll.gameObject.gameObject.GetComponent<Rocket>().colorShot != this.color)//if player color doesn't match ball color, lose health
            {
                //play pain audio
                audio.PlayOneShot(painAudio, gVar.volume);

                //create particle system for player dying
                GameObject particles = (GameObject)Instantiate(playerParticleSystem, this.GetComponent<Transform>().position, Quaternion.identity);
                particles.GetComponent<Renderer>().material = particleColor;
                Destroy(particles, 1f);

                //respawn player and lose health
                respawnPlayer();
                loseHealth();
                hurt = true;

                //create shield for player if shield does not currently exist
                if (GameObject.Find(color + "shield") == null)
                {
                    GameObject playerShield = (GameObject)Instantiate(shield, this.GetComponent<Transform>().position, Quaternion.identity);
                    playerShield.name = color + "shield";
                    playerShield.GetComponent<Shield>().setPlayer(this.gameObject);
                }
            }
            else //player color matches ball color
            {
                //play pickup audio
                audio.PlayOneShot(pickupAudio, gVar.volume);
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
            gVar.numberPlayers--;

            //remove shots according to players color
            if (color == 0)
            {
                gVar.greenShots--;
            }
            else if (color == 1)
            {
                gVar.redShots--;
            }
            else if (color == 2)
            {
                gVar.blueShots--;
            }
            else if (color == 3)
            {
                gVar.purpleShots--;
            }

            Destroy(objLives);
            Destroy(gameObject);
        }
    }

    //respawn the player in the best location, chosen randomly. (Best location = furthest away from other players as possible
    void respawnPlayer()
    {
        bool canRespawn = false;
        int numLoops = 0;
        int respawnLocation = 0;

        GameObject[] otherPlayers = GameObject.FindGameObjectsWithTag("Player");

        while (canRespawn == false && numLoops <= 10) //loop until player can respawn (or until it's looped 10 times) best case scenario, more than 9 units away
        {
            canRespawn = true;
            respawnLocation = (Random.Range(0, 5));//choose a random spawn location

            for (int i = 0; i < otherPlayers.Length; i++)//check all players against spawn location
            {
                //if player is less than 5 units away from potential spawn (eg don't spawn there)
                if (Vector3.Distance(otherPlayers[i].GetComponent<Transform>().position, possibleRespawnLocations[respawnLocation]) < 9)
                {
                    canRespawn = false;
                }
            }
            numLoops++;
        }

        numLoops = 0;

        while (canRespawn == false && numLoops <= 10) //loop until player can respawn (or until it's looped 10 times) worst case scenario, more than 4 units away
        {
            canRespawn = true;
            respawnLocation = (Random.Range(0, 5));//choose a random spawn location

            for (int i = 0; i < otherPlayers.Length; i++)//check all players against spawn location
            {
                //if player is less than 5 units away from potential spawn (eg don't spawn there)
                if (Vector3.Distance(otherPlayers[i].GetComponent<Transform>().position, possibleRespawnLocations[respawnLocation]) < 4)
                {
                    canRespawn = false;
                }
            }
            numLoops++;
        }

        this.GetComponent<Transform>().position = possibleRespawnLocations[respawnLocation];
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

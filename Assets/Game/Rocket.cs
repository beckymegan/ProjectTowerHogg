﻿using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public int shootSpeed;
    public float blastZone, xVelocity, yVelocity;
    public Sprite gRocket, rRocket, bRocket, pRocket;

    string direction;
    SpriteRenderer spriter;
    
    
    // Use this for initialization
	void Start () {
        direction = gVar.direction;
        spriter = this.GetComponent<SpriteRenderer>();
        this.color();
    }

    //render sprite image to match shooter
    void color()
    {
        if (name.Equals("rocketP1"))
        {
            if(gVar.player1.Equals("Green"))
            {
                spriter.sprite = gRocket;
            }
            else if (gVar.player1.Equals("Red"))
            {
                spriter.sprite = rRocket;
            }
            else if (gVar.player1.Equals("Blue"))
            {
                spriter.sprite = bRocket;
            }
            else if (gVar.player1.Equals("Purple"))
            {
                spriter.sprite = pRocket;
            }
        }
        else if (name.Equals("rocketP2"))
        {
            if (gVar.player2.Equals("Green"))
            {
                spriter.sprite = gRocket;
            }
            else if (gVar.player2.Equals("Red"))
            {
                spriter.sprite = rRocket;
            }
            else if (gVar.player2.Equals("Blue"))
            {
                spriter.sprite = bRocket;
            }
            else if (gVar.player2.Equals("Purple"))
            {
                spriter.sprite = pRocket;
            }
        }
        else if (name.Equals("rocketP3"))
        {
            if (gVar.player3.Equals("Green"))
            {
                spriter.sprite = gRocket;
            }
            else if (gVar.player3.Equals("Red"))
            {
                spriter.sprite = rRocket;
            }
            else if (gVar.player3.Equals("Blue"))
            {
                spriter.sprite = bRocket;
            }
            else if (gVar.player3.Equals("Purple"))
            {
                spriter.sprite = pRocket;
            }
        }
        else if (name.Equals("rocketP4"))
        {
            if (gVar.player4.Equals("Green"))
            {
                spriter.sprite = gRocket;
            }
            else if (gVar.player4.Equals("Red"))
            {
                spriter.sprite = rRocket;
            }
            else if (gVar.player4.Equals("Blue"))
            {
                spriter.sprite = bRocket;
            }
            else if (gVar.player4.Equals("Purple"))
            {
                spriter.sprite = pRocket;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (direction == "right")
        {
            float xvalue = this.GetComponent<Transform>().position.x + (xVelocity*Time.deltaTime);
            float yvalue = this.GetComponent<Transform>().position.y + (-yVelocity * Time.deltaTime * Time.deltaTime) + (yVelocity * Time.deltaTime);
            Vector2 shootLocation = new Vector2(xvalue, yvalue);
            this.GetComponent<Transform>().position = shootLocation;
        }
        else if (direction == "left")
        {
            float xvalue = this.GetComponent<Transform>().position.x + (-xVelocity * Time.deltaTime);
            float yvalue = this.GetComponent<Transform>().position.y + (-yVelocity * Time.deltaTime * Time.deltaTime) + (yVelocity * Time.deltaTime);
            Vector2 shootLocation = new Vector2(xvalue, yvalue);
            this.GetComponent<Transform>().position = shootLocation;
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
    }

    public string getDirection()
    {
        return direction;
    }

    void OnBecameInvisible()//if invisible loop to other x/y direction
    {
        if (this.GetComponent<Transform>().position.y > 5 || this.GetComponent<Transform>().position.y < -5)//if invisible and above 5/under -5 (eg top or bottom) reverse y
        {
            Vector3 location = new Vector3(this.GetComponent<Transform>().position.x, (-1) * (this.GetComponent<Transform>().position.y), 0);
            this.GetComponent<Transform>().position = location;
        }
        else //if invisible and  between 5 and -5 (eg left or right) reverse x
        {
            Vector3 location = new Vector3((-1) * (this.GetComponent<Transform>().position.x), this.GetComponent<Transform>().position.y, 0);
            this.GetComponent<Transform>().position = location;
        }
    }
}

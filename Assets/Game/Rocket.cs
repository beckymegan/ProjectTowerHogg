using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public int shootSpeed;
    public float blastZone, xVelocity, yVelocity;
    public Sprite gRocket, rRocket, bRocket, pRocket;

    private string direction;
    private bool wallcheck = false;
    private SpriteRenderer spriter;
    
    
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

        //if direction is right rotate rocket and shoot right
        if (direction == "right" && wallcheck == false)
        {
            this.GetComponent<Transform>().Rotate(new Vector3(0, 0, -330));
            this.GetComponent<Rigidbody2D>().AddForce(this.transform.right * shootSpeed);
            wallcheck = true;
        }
        else if (direction == "left" && wallcheck == false)
        {
            this.GetComponent<Transform>().Rotate(new Vector3(0, 0, 330));
            this.GetComponent<Rigidbody2D>().AddForce(-this.transform.right * shootSpeed);
            wallcheck = true;
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
           Destroy(gameObject);
        }
    }

    public string Direction()
    {
        return direction;
    }

    void OnBecameInvisible()//if invisible loop to other x/y direction
    {
        if (this.GetComponent<Transform>().position.y > 10 || this.GetComponent<Transform>().position.y < -10)//if invisible and above 5/under -5 (eg top or bottom) reverse y
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

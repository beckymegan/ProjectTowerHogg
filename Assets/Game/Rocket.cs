using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public int shootSpeed;
    public float blastZone;
    public Sprite gRocket, rRocket, bRocket, pRocket;

    Vector2 locSelf;
    string direction;
    bool blewUp;
    SpriteRenderer spriter;
    
    
    // Use this for initialization
	void Start () {
        direction = gVar.direction;
        spriter = this.GetComponent<SpriteRenderer>();
        blewUp = true;
        this.color();
        Destroy(gameObject, 0.4f);
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
    }
	
	// Update is called once per frame
	void Update () {
        locSelf = this.GetComponent<Transform>().position;

        //rocket travels in direction it was shot in
        if (direction == "up")
        {
            transform.Translate(Vector3.up * Time.deltaTime * shootSpeed);
        }
        else if (direction == "right")
        {
            transform.Translate(Vector3.right * Time.deltaTime * shootSpeed);
        }
        else if (direction == "left")
        {
            transform.Translate(Vector3.left * Time.deltaTime * shootSpeed);
        }
        else if (direction == "left")
        {
            transform.Translate(Vector3.left * Time.deltaTime * shootSpeed);
        }
        else if (direction == "down")
        {
            transform.Translate(Vector3.down * Time.deltaTime * shootSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            blewUp = false;
        }
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

using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{

    public int shootSpeed, colorShot;
    public float blastZone, xVelocity, yVelocity;
    public Sprite gRocket, rRocket, bRocket, pRocket;
    public GameObject ballParticleSystem;
    public Material shotColor;

    private string direction;
    private Color GREEN, RED, BLUE, PURPLE;
    private bool wallcheck = false;


    // Use this for initialization
    void Start()
    {
        direction = gVar.direction;
        //set colors
        GREEN = new Color(0.435f, 0.768f, 0.662f);
        RED = new Color(0.945f, 0.611f, 0.717f);
        BLUE = new Color(0.553f, 0.710f, 0.906f);
        PURPLE = new Color(0.615f, 0.611f, 0.945f);
    }

    //render sprite image to match shooter
    public void color(int colorShot)
    {
        this.colorShot = colorShot;
        if (colorShot == 0)//color sprite green
        {
            this.GetComponent<SpriteRenderer>().sprite = gRocket;
        }
        else if (colorShot == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = rRocket;
        }
        else if (colorShot == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = bRocket;
        }
        else if (colorShot == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = pRocket;
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        Material particleColor = new Material(shotColor);
        if (coll.gameObject.tag.Equals("Player"))//hit player
        {
            if (colorShot == 0)//if ball is green increase greenshots by one
            {
                gVar.greenShots++;
                particleColor.SetColor("_EmissionColor", GREEN);
            }
            else if (colorShot == 1)
            {
                gVar.redShots++;
                particleColor.SetColor("_EmissionColor", RED);
            }
            else if (colorShot == 2)
            {
                gVar.blueShots++;
                particleColor.SetColor("_EmissionColor", BLUE);
            }
            else if (colorShot == 3)
            {
                gVar.purpleShots++;
                particleColor.SetColor("_EmissionColor", PURPLE);
            }
            GameObject particles = (GameObject)Instantiate(ballParticleSystem, this.GetComponent<Transform>().position, Quaternion.identity);
            particles.GetComponent<Renderer>().material = particleColor;
            Destroy(particles, 0.5f);
            Destroy(gameObject);
        }
        else if (coll.gameObject.tag.Equals("Shield"))//hit shield
        {
            if (colorShot == 0)//if ball is green increase greenshots by one
            {
                gVar.greenShots++;
                particleColor.SetColor("_EmissionColor", GREEN);
            }
            else if (colorShot == 1)
            {
                gVar.redShots++;
                particleColor.SetColor("_EmissionColor", RED);
            }
            else if (colorShot == 2)
            {
                gVar.blueShots++;
                particleColor.SetColor("_EmissionColor", BLUE);
            }
            else if (colorShot == 3)
            {
                gVar.purpleShots++;
                particleColor.SetColor("_EmissionColor", PURPLE);
            }

            GameObject particles = (GameObject)Instantiate(ballParticleSystem, this.GetComponent<Transform>().position, Quaternion.identity);
            particles.GetComponent<Renderer>().material = particleColor;
            Destroy(particles, 0.5f);
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

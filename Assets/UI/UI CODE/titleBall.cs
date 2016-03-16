using UnityEngine;
using System.Collections;

public class titleBall : MonoBehaviour
{
    public int colorShot;
    public GameObject ballParticleSystem;
    public Sprite gRocket, rRocket, bRocket, pRocket;
    public Material shotColor;

    private Color GREEN, RED, BLUE, PURPLE;

    // Use this for initialization
    void Start ()
    {
        //set colors
        GREEN = new Color(0.435f, 0.768f, 0.662f);
        RED = new Color(0.945f, 0.611f, 0.717f);
        BLUE = new Color(0.553f, 0.710f, 0.906f);
        PURPLE = new Color(0.615f, 0.611f, 0.945f);

        //change sprite of ball to match color determined for ball
        if(colorShot == 0)
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

    //if ball falls off screen, destroy object without particles
    void Update()
    {
        if(this.GetComponent<Transform>().position.y < -5.5f)
        {
            Destroy(gameObject);
        }
    }

    //if ball collides with another ball, destroy both with particles
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Ball")
        {
            BallDestroy();
        }
    }

    //destroy ball with particles
    void BallDestroy()
    {
        Material particleColor = new Material(shotColor);
        if (colorShot == 0)//if ball is green increase greenshots by one
        {
            particleColor.SetColor("_EmissionColor", GREEN);
        }
        else if (colorShot == 1)
        {
            particleColor.SetColor("_EmissionColor", RED);
        }
        else if (colorShot == 2)
        {
            particleColor.SetColor("_EmissionColor", BLUE);
        }
        else
        {
            particleColor.SetColor("_EmissionColor", PURPLE);
        }

        GameObject particles = (GameObject)Instantiate(ballParticleSystem, this.GetComponent<Transform>().position, Quaternion.identity);
        particles.GetComponent<Renderer>().material = particleColor;
        Destroy(particles, 0.7f);
        Destroy(gameObject);
    }
}

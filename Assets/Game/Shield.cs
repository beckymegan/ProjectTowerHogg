using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{

    public int shieldTime, color;
    public Sprite greenShield, redShield, blueShield, purpleShield;
    public AudioClip shieldAudio;

    private float hurtTimer;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        //set color of shield
        if (player.GetComponent<Player>().color == 0)//if color is green set sprite to green and set color to green
        {
            this.GetComponent<SpriteRenderer>().sprite = greenShield;
            color = 0;
        }
        else if (player.GetComponent<Player>().color == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = redShield;
            color = 1;
        }
        else if (player.GetComponent<Player>().color == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = blueShield;
            color = 2;
        }
        else if (player.GetComponent<Player>().color == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = purpleShield;
            color = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)//if player exists
        {
            //follow players location
            this.GetComponent<Transform>().position = player.GetComponent<Transform>().position;

            hurtTimer += 1.0F * Time.deltaTime;
            if (hurtTimer >= shieldTime)
            {
                //remove shield and make player unhurt
                player.GetComponent<Player>().Unhurt();
                GameObject.Destroy(gameObject);
            }
            //start blinking to suggest that shield was going to disappear
            else if ((hurtTimer >= shieldTime - 1.25 && hurtTimer <= shieldTime - 1) || (hurtTimer >= shieldTime - .75 && hurtTimer <= shieldTime - 0.60) || (hurtTimer >= shieldTime - .45 && hurtTimer <= shieldTime - 0.35)
                 || (hurtTimer >= shieldTime - .25 && hurtTimer <= shieldTime - 0.15) || (hurtTimer >= shieldTime - .15 && hurtTimer <= shieldTime - 0.05))
            {
                this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                this.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                this.GetComponent<Collider2D>().enabled = true;
            }
            //follow players location
            this.GetComponent<Transform>().position = player.GetComponent<Transform>().position;
        }
        else//if player doesn't exist, destory self
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Ball"))//ball hits shield
        {
            //play audio when rocket hits shield
            GetComponent<AudioSource>().PlayOneShot(shieldAudio, gVar.volume);
        }
    }

public void setPlayer(GameObject player)
    {
        this.player = player;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {

    public float scrollSpeed;
    public Sprite back1, back2, back3, back4, back5;

    private SpriteRenderer sr;
	
    // Use this for initialization
	void Start () {
        sr = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(this.transform.position.x-scrollSpeed,this.transform.position.y,3.5f);
        if(gVar.currentLocation == 1)
        {
            sr.sprite = back1;
        }
        else if (gVar.currentLocation == 2)
        {
            sr.sprite = back2;
        }
        else if (gVar.currentLocation == 3)
        {
            sr.sprite = back3;
        }
        else if (gVar.currentLocation == 4)
        {
            sr.sprite = back4;
        }
        else if (gVar.currentLocation == 5)
        {
            sr.sprite = back5;
        }
        
        //loop background
        if ((this.GetComponent<Transform>().position.x < -20) && (SceneManager.GetActiveScene().name.Equals("Character Select")))
        {
            this.GetComponent<Transform>().position = new Vector3(19.67f, this.transform.position.y, 2);
        }

        if((this.GetComponent<Transform>().position.x < -6) && (SceneManager.GetActiveScene().name.Equals("Level Select")))
        {
            this.GetComponent<Transform>().position = new Vector3(5.9f, this.transform.position.y, 2);
        }
    }
}

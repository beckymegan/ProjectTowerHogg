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
    }

    void OnBecameInvisible()
    {
        if (Application.loadedLevel.Equals("Character Select"))
        {
            this.transform.position = new Vector3(21.56f, this.transform.position.y, 2);
        }
        else if (Application.loadedLevel.Equals("Level Select"))
        {
            this.transform.position = new Vector3(6.45f, this.transform.position.y, 5);
        }
    }
}

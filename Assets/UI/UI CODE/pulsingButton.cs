using UnityEngine;
using System.Collections;

public class pulsingButton : MonoBehaviour {

    public Sprite[] buttons = new Sprite[5];

    private int counter;

	// Use this for initialization
	void Start () {
        counter = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.GetComponent<SpriteRenderer>().sprite = buttons[gVar.currentLocation - 1];

        if (counter <= 60)
        {
            this.GetComponent<Transform>().localScale += new Vector3(Time.deltaTime * 0.05f, Time.deltaTime * 0.05f, 1);
        }
        else if (counter <= 120)
        {
            this.GetComponent<Transform>().localScale += new Vector3(Time.deltaTime * -0.05f, Time.deltaTime * -0.05f, 1);
        }
        else
        {
            counter = 0;
        }
        counter++;
    }
}

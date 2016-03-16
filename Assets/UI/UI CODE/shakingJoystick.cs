using UnityEngine;
using System.Collections;

public class shakingJoystick : MonoBehaviour {
    
    public Sprite[] joysticks = new Sprite[5];

    private int counter;

    private Vector3 start, finish;

	// Use this for initialization
	void Start () {
        counter = 0;
        start = Vector3.forward;
        finish = Vector3.back;
    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<SpriteRenderer>().sprite = joysticks[gVar.currentLocation-1];
        
        if (counter <= 120)
        {
            this.GetComponent<Transform>().Rotate(start, Time.deltaTime * 15, Space.Self);
        }
        if (counter <= 240)
        {
            this.GetComponent<Transform>().Rotate(finish, Time.deltaTime * 15, Space.Self);
        }
        else
        {
            counter = 0;
        }

        counter++;
    }
}

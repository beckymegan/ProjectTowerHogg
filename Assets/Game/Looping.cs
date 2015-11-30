using UnityEngine;
using System.Collections;

public class Looping : MonoBehaviour {
    
    Player play;

	// Use this for initialization
	void Start () {
        play = this.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
            
    }
}

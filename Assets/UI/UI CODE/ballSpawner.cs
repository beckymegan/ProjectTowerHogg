using UnityEngine;
using System.Collections;

public class ballSpawner : MonoBehaviour {
    
    public GameObject titleBall;

    private int counter, randomNumber, randomColor;
    private float randomLocation, randomScale;
    private GameObject newBall;


    // Use this for initialization
    void Start () {
        Time.timeScale = 1;

        counter = 0;
        randomNumber = Random.Range(30, 480);
    }
	
	// Update is called once per frame
	void Update () {
	    if(counter == randomNumber)
        {
            //get color, location, and scale of new ball
            randomColor = Random.Range(0, 4);
            randomLocation = Random.Range(-8.3f, 8.6f);
            randomScale = Random.Range(0.5f, 1f);

            //create new ball with data from above
            newBall = (GameObject)Instantiate(titleBall, new Vector3(randomLocation, 5.5f, 0f), Quaternion.identity);
            newBall.GetComponent<titleBall>().colorShot = randomColor;
            newBall.GetComponent<Transform>().localScale = new Vector3(randomScale, randomScale);

            //get new random number and reset counter
            counter = 0;
            randomNumber = Random.Range(30, 480);
        }
        //incrament counter
        counter++;
	}
}

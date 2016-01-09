using UnityEngine;
using System.Collections;

public class ShotsNum : MonoBehaviour {

    public GameObject shot1, shot2, shot3, shot4;
    public Sprite green, red, blue, purple;

    private GameObject[] shotArray = new GameObject[4];
    
	// Use this for initialization
	void Start () {
        shotArray[0] = shot1; shotArray[1] = shot2; shotArray[2] = shot3; shotArray[3] = shot4;//set array
    }
	
	// Update is called once per frame
	void Update () {
        int counter = 0; int arrayCounter = 0;

        //runs through the array and adds/removes shots depending on whether that shot exists or not.
        while (gVar.greenShots > counter)
        {
            shotArray[arrayCounter].GetComponent<SpriteRenderer>().sprite = green;
            arrayCounter++; counter++;
        }

        counter = 0;
        while (gVar.redShots > counter)
        {
            shotArray[arrayCounter].GetComponent<SpriteRenderer>().sprite = red;
            arrayCounter++; counter++;
        }

        counter = 0;
        while (gVar.blueShots > counter)
        {
            shotArray[arrayCounter].GetComponent<SpriteRenderer>().sprite = blue;
            arrayCounter++; counter++;
        }

        counter = 0;
        while (gVar.purpleShots > counter)
        {
            shotArray[arrayCounter].GetComponent<SpriteRenderer>().sprite = purple;
            arrayCounter++; counter++;
        }

        while(arrayCounter < 4)
        {
            shotArray[arrayCounter].GetComponent<SpriteRenderer>().sprite = null;
            arrayCounter++;
        }
    }
}

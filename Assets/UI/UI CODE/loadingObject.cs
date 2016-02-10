using UnityEngine;
using System.Collections;

public class loadingObject : MonoBehaviour
{

    public float speed, radius, position;
    private float coordX, coordY, coordZ, timeCounter;

    void Start()
    {
        Time.timeScale = 1;
        timeCounter = position*Mathf.PI;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;

        coordX = Mathf.Cos(timeCounter) * radius;
        coordY = Mathf.Sin(timeCounter) * radius;
        coordZ = 0;

        this.GetComponent<Transform>().position = new Vector3(coordX, coordY, coordZ);
    }
}

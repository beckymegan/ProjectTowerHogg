using UnityEngine;
using System.Collections;

public class SCREENSHOT : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Application.CaptureScreenshot("Screenshot.png");
            Debug.Log("SCREENSHOT");
        }
    }
}

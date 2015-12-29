using UnityEngine;
using System.Collections;

public class SCREENSHOT : MonoBehaviour
{
    private static int screenshotNum = 0;
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Application.CaptureScreenshot("Screenshot"+screenshotNum+".png");
            Debug.Log("SCREENSHOT "+ screenshotNum);
            screenshotNum++;
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SCREENSHOT : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("p")|| Input.GetKeyDown("joystick button 5"))
        {
            Application.CaptureScreenshot(SceneManager.GetActiveScene().name+" "+ System.DateTime.Now.Month+"-"+System.DateTime.Now.Day + "-" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + "-" + System.DateTime.Now.Second + ".png");
            Debug.Log(SceneManager.GetActiveScene().name + " " + System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Hour + "-" + System.DateTime.Now.Minute + "-" + System.DateTime.Now.Second);
        }
        else if (Input.GetKeyDown("k"))
        {
            SceneManager.LoadScene("Loading Screen");
        }
    }
}

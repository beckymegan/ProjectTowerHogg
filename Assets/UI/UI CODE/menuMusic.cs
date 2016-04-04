using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuMusic : MonoBehaviour
{
    public AudioClip music1, music2, music3, music4, music5, musicMenu;

    private bool isMenuMusicPlaying = false;

    void Awake()
    {
            this.GetComponent<AudioSource>().Play();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (this.GetComponent<AudioSource>().isPlaying == false)//loop music
        {
            this.GetComponent<AudioSource>().Play();
        }

        //change music dependent on level/if on menu screen
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            this.GetComponent<AudioSource>().clip = music1;
        }
        else if(SceneManager.GetActiveScene().name == "Level 2")
        {
            this.GetComponent<AudioSource>().clip = music2;
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            this.GetComponent<AudioSource>().clip = music3;
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            this.GetComponent<AudioSource>().clip = music4;
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            this.GetComponent<AudioSource>().clip = music5;
        }
        else
        {
            this.GetComponent<AudioSource>().clip = musicMenu;
        }

        this.GetComponent<AudioSource>().volume = gVar.musicVolume*0.5f;//set music volume half to what the slider says it should be
    }
}

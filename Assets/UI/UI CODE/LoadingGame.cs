using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingGame : MonoBehaviour
{
    private AsyncOperation async;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadALevel());
    }

    IEnumerator LoadALevel()
    {
        if (gVar.currentLocation == 1)
        {
            async = SceneManager.LoadSceneAsync("Level 1");
        }
        else if (gVar.currentLocation == 2)
        {
            async = SceneManager.LoadSceneAsync("Level 2");
        }
        else if (gVar.currentLocation == 3)
        {
            async = SceneManager.LoadSceneAsync("Level 3");
        }
        else if (gVar.currentLocation == 4)
        {
            async = SceneManager.LoadSceneAsync("Level 4");
        }
        else if (gVar.currentLocation == 5)
        {
            async = SceneManager.LoadSceneAsync("Level 5");
        }

        while (!async.isDone)
        {
            yield return null;
        }
    }
}

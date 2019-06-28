using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [SerializeField]private GameObject mainCamera;
    public void switchTo(int levelIndex)
    {
        mainCamera.GetComponent<AudioSource>().Pause();
        mainCamera.GetComponent<SceneFadeInOut>().startFadeOut(delegate() 
        {
            SceneManager.LoadScene(levelIndex);
        });
        
    }
}

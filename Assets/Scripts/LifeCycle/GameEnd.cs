using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [SerializeField]private GameObject mainCamera;
    public void switchTo(int levelIndex)
    {
        if(levelIndex==2)
        {
            GameManagement.levelSelect.showAnimation = true;
        }
        mainCamera.GetComponent<SceneFadeInOut>().startFadeOut(delegate() 
        {
            SceneManager.LoadScene(levelIndex);
        });
        
    }
}

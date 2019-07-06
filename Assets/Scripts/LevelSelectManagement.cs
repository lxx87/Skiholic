using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EsayAnimation;
using UnityEngine.SceneManagement;

public class LevelSelectManagement : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectPanel;
    // Start is called before the first frame update
    void Start()
    {
        if(!GameManagement.levelSelect.showAnimation)
        {
            GetComponent<SceneFadeInOut>().showFadeIn = false;
        }
        else
        {
            levelSelectPanel.GetComponent<EasyAnimation_Enlarge>().enabled = false;
            GameManagement.levelSelect.showAnimation = false;
        }
        GetComponent<SceneFadeInOut>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int index)
    {
        Debug.Log("load");
        SceneManager.LoadSceneAsync(index);
        GetComponent<SceneFadeInOut>().startFadeOut(delegate () { });
    }
}

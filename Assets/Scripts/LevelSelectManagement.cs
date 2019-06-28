using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EsayAnimation;
public class LevelSelectManagement : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectPanel;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManagement.levelSelect.showAnimation)
        {
            GetComponent<SceneFadeInOut>().enabled = true;
            levelSelectPanel.GetComponent<EasyAnimation_Enlarge>().enabled = false;
            GameManagement.levelSelect.showAnimation = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

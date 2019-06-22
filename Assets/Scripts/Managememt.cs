using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Managememt : MonoBehaviour
{
    public int choise = 0;
    [SerializeField] private Text[] achieveTexts;
    // Start is called before the first frame update
    void Start()
    {
        BaseAchievement[] achievements = GetComponents<BaseAchievement>();
        for(int i=0;i< achieveTexts.Length;i++)
        {
            achieveTexts[i].text = achievements[i].getDescription();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}

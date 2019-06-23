using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSettelment : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject settelmentPanel;
    private ScoreCaculate gameStateManager;
    private GameObject succeedPanel;
    private GameObject failPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = character.GetComponent<ScoreCaculate>();
        succeedPanel = settelmentPanel.transform.Find("GameSucceed").gameObject;
        failPanel = settelmentPanel.transform.Find("GameFailed").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameStateManager.isWin())
        {
            Debug.Log("GameSettelment: win");
            succeedPanel.SetActive(true);
            settelmentPanel.SetActive(true);
            succeed();
            stopAchievementJudge();
            enabled = false;
        }
        if(gameStateManager.isDeathOrFail())
        {
            Debug.Log("GameSettelment: fail");
            failPanel.SetActive(true);
            settelmentPanel.SetActive(true);
            stopAchievementJudge();
            enabled = false;
        }
    }

    private void succeed()
    {
        GameObject temp = succeedPanel.transform.Find("StarGet").gameObject;
        GameObject[] stars = new GameObject[3];
        stars[0] = temp.transform.Find("Star1").gameObject;
        stars[1] = temp.transform.Find("Star2").gameObject;
        stars[2] = temp.transform.Find("Star3").gameObject;
        Text[] descriptions = new Text[3];
        descriptions[0] = temp.transform.Find("Text1").
            gameObject.GetComponent<Text>();
        descriptions[1] = temp.transform.Find("Text2").
            gameObject.GetComponent<Text>();
        descriptions[2] = temp.transform.Find("Text3").
            gameObject.GetComponent<Text>();
        BaseAchievement[] achievements = GetComponents<BaseAchievement>();
        for(int i=0;i<achievements.Length;i++)
        {
            descriptions[i].text = achievements[i].getDescription();
        }
        StartCoroutine(showAnimation());

        IEnumerator showAnimation()
        {
            for (int i = 0; i < achievements.Length; i++)
            {
                stars[i].SetActive(true);
                if (!achievements[i].done())
                {
                    stars[i].GetComponent<Animator>().SetBool("show", false);
                }
                yield return new WaitForSeconds(1.0f);
            }
        }
    }

    private void stopAchievementJudge()
    {
        BaseAchievement[] achievements = GetComponents<BaseAchievement>();
        for (int i = 0; i < achievements.Length; i++)
        {
            achievements[i].enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Managememt : MonoBehaviour
{
    public int choise = 0;
    [SerializeField] private Text[] achieveTexts;
    [SerializeField] private DrawLine drawLine;
    private bool start = false;
    private bool click = false;
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

    public void setClick(bool c)
    {
        click = c;
    }

    public bool isClick()
    {
        return click;
    }

    private void OnGUI()
    {
        if(!start)
        {
            GUIStyle style = new GUIStyle
            {
                fontSize = 30,
            };
            string text = "辅助轨道长度: " + drawLine.getLength() + "m";
            Rect position = new Rect(10, Screen.height - 40, 1, 1);
            GUI.Label(position, text.ToString(), style);
        }
    }

    public void startGame()
    {
        start = true;
    }
}

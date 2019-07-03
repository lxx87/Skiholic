
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimitAchievement : BaseAchievement
{
    public int mostTime = 30;
    private int leftTime;
    private bool isDone = true;
    // Start is called before the first frame update
    void Start()
    {
        leftTime = mostTime;
        StartCoroutine(countDown());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator countDown()
    {
        while (leftTime > 0)
        {
            leftTime--;
            yield return new WaitForSeconds(1);
        }
        leftTime--;
        isDone = false;
    }

    private void OnGUI()
    {
        if (leftTime >= 0)
        {
            GUIStyle style = new GUIStyle
            {

                fontSize = 18,
            };
            string text = "剩余时间: " + leftTime.ToString() + "s";
            Rect position = new Rect(Screen.width / 2 - 45, 10, 1, 1);
            GUI.Label(position, text.ToString(), style);
        }
    }

    public override bool done()
    {
        return isDone;
    }

    public override string getDescription()
    {
        return "在" + (int)mostTime + "秒内完成比赛";
    }
}

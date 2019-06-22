using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAchievement : BaseAchievement
{
    [SerializeField] private GameObject player;
    public int baseCoinNum = 0;

    public override bool done()
    {
        return player.GetComponent<ScoreCaculate>().getCoinNum() >= baseCoinNum;
    }

    public override string getDescription()
    {
        return "收集" + baseCoinNum + "个金币";
    }
}

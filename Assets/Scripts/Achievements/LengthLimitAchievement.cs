using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengthLimitAchievement : BaseAchievement
{
    [SerializeField] private DrawLine drawer;
    public float maxLength = 0;

    public override bool done()
    {
        return drawer.getLength() <= maxLength;
    }

    public override string getDescription()
    {
        return "辅助轨道长度不超过" + string.Format("{0:0.00}", maxLength) + "m";
    }
}

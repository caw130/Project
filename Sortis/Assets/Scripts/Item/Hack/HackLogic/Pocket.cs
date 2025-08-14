using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : HackStatType
{
    public override void Equip()
    {
        InvokeOnUsed();
        UserStat.Instance.ChangHandSize(1);
    }

    public override void Unequip()
    {
        UserStat.Instance.ChangHandSize(-1);
    }
}

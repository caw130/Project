using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GB : HackStatType
{
    public override void Equip()
    {
        UserStat.Instance.ChangeMaxThrowCard(5);
    }

    public override void Unequip()
    {
        UserStat.Instance.ChangeMaxThrowCard(-5);
    }
}

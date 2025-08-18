using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jocker : HackStatType
{
    public override void Equip()
    {
        UserStat.Instance.ChangeZullNeedCard(-1);
    }

    public override void Unequip()
    {
        UserStat.Instance.ChangeZullNeedCard(1);
    }
}

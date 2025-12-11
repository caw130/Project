using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : HackStatType
{
    //Hack을 구매하면 실행
    public override void Equip()
    {
        InvokeOnUsed();
        UserStat.Instance.ChangHandSize(1);
    }

    //Hack을 판매하면 실행
    public override void Unequip()
    {
        UserStat.Instance.ChangHandSize(-1);
    }
}

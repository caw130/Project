using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleEgg : CheatEffectBase
{
    public override void Use()
    {
        _charges--;
        if (Goldmanager.Instance.Gold <= 20)
        {
            Goldmanager.Instance.MultipGold();
        }
        else
        {
            Goldmanager.Instance.GetGold(20);
        }
    }
}

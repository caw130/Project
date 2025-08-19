using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleWaffle : HackEventType
{
    public override void OnGameEvent(GameEventType type, object a, object b)
    {
        if (_data.Trigger.Contains(type))
        {
            if(Goldmanager.Instance.Gold <= 30)
            {
               Goldmanager.Instance.MultipGold();
            }
            else
            {
                Goldmanager.Instance.GetGold(30);
            }
            InvokeOnUsed();
        }
    }
}

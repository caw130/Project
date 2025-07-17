using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Midas : HackEventType
{

    public override void OnGameEvent(GameEventType type, object a, object b)
    {
        if(_data.Trigger.Contains(type))
        {
            Goldmanager.Instance.GetGold(2);
        }
    }

}

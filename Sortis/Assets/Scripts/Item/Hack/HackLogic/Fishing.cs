using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : HackEventType
{
    public override void OnGameEvent(GameEventType type, object a, object b)
    {
        if (_data.Trigger.Contains(type))
        {
            GameEvent.Raise(GameEventType.GetRandomItem);
            InvokeOnUsed();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormApple : HackEventType
{
    public override void OnGameEvent(GameEventType type, object a, object b)
    {
        if (_data.Trigger.Contains(type))
        {
            GameEvent.Raise(GameEventType.ClearThrowDeck);
            GameEvent.Raise(GameEventType.HackRemove,this);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : HackEventType
{
    int stack = 0;
    public override void OnGameEvent(GameEventType type, object a, object b)
    {
        if(_data.Trigger.Contains(type))
        {
            if(type == GameEventType.FirstTypeCardDrop)
            {
                stack++;
                InvokeOnUsed();
            }
            if(type == GameEventType.OnCardDiscard)
            {
                if(stack >=3)
                {
                    GameEvent.Raise(GameEventType.RemoveLastThrow);
                    InvokeOnUsed();
                }
                stack = 0;
            }
        }
    }
}

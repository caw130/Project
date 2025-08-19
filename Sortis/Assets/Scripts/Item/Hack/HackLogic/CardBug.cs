using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBug : HackEventType
{
    public override void OnGameEvent(GameEventType type, object a, object b)
    {
        if (_data.Trigger.Contains(type))
        {
            int idx = Random.Range(0, 5);
            if( idx == 0)
            {
                if (a is Card card)
                {
                    card.DestroyCardWithAnimation();
                    GameEvent.Raise(GameEventType.RemoveCard, card);
                    InvokeOnUsed();
                }
            }
            
        }
    }

}

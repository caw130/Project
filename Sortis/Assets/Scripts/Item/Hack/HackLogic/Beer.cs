using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : HackEventType
{
    [SerializeField] List<CardData> _cards;
    public override void OnGameEvent(GameEventType type, object a, object b)
    {

        if(_data.Trigger.Contains(type))
        {
            if(a is Card card)
            {
                int ran = Random.Range(0, _cards.Count-1);
                card.Setup(_cards[ran]);
                card.CardChanged();
                InvokeOnUsed();
            }
        }
    }
}

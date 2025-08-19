using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : CheatEffectBase
{
    public override void Use()
    {
        _charges--;
        GameEvent.Raise(GameEventType.GetThrowCard);
    }
}

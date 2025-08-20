using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam : CheatEffectBase
{
    public override void Use()
    {
        GameEvent.Raise(GameEventType.ShuffleHand);
        _charges--;
    }
}

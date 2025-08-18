using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainQ : CheatEffectBase
{
    public override void Use()
    {
        _charges--;
        GameEvent.Raise(GameEventType.HandReturn);
    }
}

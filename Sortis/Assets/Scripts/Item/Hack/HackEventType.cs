using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HackEventType : HackEffectBase
{
    public abstract void OnGameEvent(GameEventType type, object a, object b);
}

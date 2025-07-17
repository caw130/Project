using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ereaser : CheatEffectBase
{
    public override void OnClicked()
    {
        Use();
    }

    public override void Use()
    {
        _charges--;
        GameEvent.Raise(GameEventType.RemoveHand);
        if (_charges <= 0) Destroy(gameObject);
    }
}

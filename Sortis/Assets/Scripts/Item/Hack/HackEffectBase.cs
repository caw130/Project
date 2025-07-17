using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HackEffectBase : MonoBehaviour
{
    [SerializeField] protected HackData _data;
    public void Initialize(HackData data)
    {
        _data = data;
    }

    public abstract void OnGameEvent(GameEventType type, object a, object b);
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HackEffectBase : MonoBehaviour
{
    [SerializeField] protected HackData _data;

    public event Action OnUsed;
    protected void InvokeOnUsed() => OnUsed?.Invoke();
    public HackData Data => _data;
    public void Initialize(HackData data)
    {
        _data = data;
    }


}

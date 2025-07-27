using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CheatEffectBase : MonoBehaviour
{

    [SerializeField] protected CheatData _data;
    [SerializeField] protected int _charges;
    public CheatData Data => _data;
    public int Charges => _charges;

    public bool Clickable { get; set; } = true;

    public void Initialize(CheatData data)
    {
        _data = data;
        _charges = _data.Charges;
    }

    public abstract void Use();
}

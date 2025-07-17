using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    [SerializeField] int _maxHack;
    [SerializeField] int _maxCheat;
    [SerializeField] List<HackEffectBase> _hacks = new List<HackEffectBase>();
    
    public void GetItem(HackData data)
    {
        HackEffectBase hack = Instantiate(data.HackPrefab);
        hack.Initialize(data);
        _hacks.Add(hack);
    }
    public void InvokeHack(GameEventType type, object a = null, object b = null)
    {
        foreach (var hack in _hacks)
        {
            hack.OnGameEvent(type, a, b);
        }
    }
}

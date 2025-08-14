using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    [SerializeField] int _maxHack;
    [SerializeField] List<HackEffectBase> _hacks = new List<HackEffectBase>();
    [SerializeField] List<CheatEffectBase> _cheats = new List<CheatEffectBase>();
    [SerializeField] HackInventoryUi _hackInvnetory;
    [SerializeField] CheatInventoryUi _cheatInventory;
    [SerializeField] Shop _shop;
    public bool CanGetHack => _hacks.Count < _maxHack;
    public bool CanGetCheat => _cheats.Count < UserStat.Instance.MaxCheatSize;
    public void GetHack(HackData data)
    {
        HackEffectBase hack = Instantiate(data.HackPrefab);
        hack.Initialize(data);
        if(hack is HackStatType statHack)
        {
            statHack.Equip();
        }
        _hacks.Add(hack);
        _hackInvnetory.AddHack(hack);
    }
    public void GetCheat(CheatData data)
    {
        CheatEffectBase cheat = Instantiate(data.CheatPrefab,transform);
        cheat.transform.position = transform.position;
        cheat.Initialize(data);
        _cheats.Add(cheat);
        _cheatInventory.AddCheat(cheat);
    }
    public void InvokeHack(GameEventType type, object a = null, object b = null)
    {
        
        foreach (var hack in _hacks)
        {
            if (hack is HackEventType eventhack)
            {
                eventhack.OnGameEvent(type,a,b);
            }
        }
    }
    public void ClearInventory()
    {
        foreach(var hack in _hacks)
        {
            Destroy(hack.gameObject);
        }
        _hacks.Clear();
        foreach(var cheat in _cheats)
        {
            Destroy(cheat.gameObject);
        }
        _cheats.Clear();
        ResetInventory();
    }
    public void SellHack(HackEffectBase effectBase)
    {
        if (effectBase is HackStatType statHack)
        {
            statHack.Unequip();
        }
        _shop.SellHack(effectBase.Data);
        _hacks.Remove(effectBase);
        Destroy(effectBase.gameObject);
    }

    public void SellCheat(CheatEffectBase cheatBase)
    {
        _shop.SellCheat(cheatBase.Data);
        RemoveCheat(cheatBase);
    }
    public void RemoveCheat(CheatEffectBase cheatBase)
    {
        _cheats.Remove(cheatBase);
        Destroy(cheatBase.gameObject);
    }

    public void ResetInventory()
    {
        _cheatInventory.ResetInventory();
        _hackInvnetory.ResetInventory();
    }
}

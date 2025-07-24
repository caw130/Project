using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemInventory : MonoBehaviour
{
    [SerializeField] int _maxHack;
    [SerializeField] int _maxCheat;
    [SerializeField] List<HackEffectBase> _hacks = new List<HackEffectBase>();
    [SerializeField] List<CheatEffectBase> _cheats = new List<CheatEffectBase>();
    public bool CanGetHack => _hacks.Count < _maxHack;
    public bool CanGetCheat => _cheats.Count < _maxCheat;
    public void GetHack(HackData data)
    {
        HackEffectBase hack = Instantiate(data.HackPrefab);
        hack.Initialize(data);
        if(hack is HackStatType statHack)
        {
            statHack.Equip();
        }
        _hacks.Add(hack);
    }
    public void GetCheat(CheatData data)
    {
        CheatEffectBase cheat = Instantiate(data.CheatPrefab);
        cheat.Initialize(data);
        _cheats.Add(cheat);
    }
    public void InvokeHack(GameEventType type, object a = null, object b = null)
    {
        
        foreach (var hack in _hacks)
        {
            if (hack is HackEventType eventhack)
            {
                // 맞다면, 그 아이템의 이벤트 처리 함수를 호출
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
    }
    public void SellItem(ItemData data)
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        
    }
}

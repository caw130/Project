using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class Shop : MonoBehaviour
{
    [SerializeField] HackPool _hackPool;
    [SerializeField] CheatPool _cheatPool;
    [SerializeField] ItemInventory _inventory;
    [SerializeField] TextMeshProUGUI _rerollText;
    [SerializeField] TextMeshProUGUI _rerollClickText;
    [SerializeField] ShopItem[] _hackItems;
    [SerializeField] ShopItem[] _cheatItems;
    [SerializeField] ShopInteractive _shopAnim;

    int _rerollCost;

    public void Initialize()
    {
        foreach (var shop in _hackItems)
        {
            shop.Initialize(this);
            shop.ChangeState(false);
        }
        foreach (var shop in _cheatItems)
        {
            shop.Initialize(this);
            shop.ChangeState(false);
        }
    }
    public void ShopClose()
    {
        _shopAnim.Hide();
        GameEvent.Raise(GameEventType.StartNewRound);
    }
    public void ShopOpen()
    {
        _shopAnim.Show();
        shuffleItem();
        _rerollCost = 5;
        _rerollText.text = $"Re Roll\r\n<color=#FFE62B>{_rerollCost}$</color>";
        _rerollClickText.text = _rerollText.text;
    }
    public void Reroll()
    {
        if (Goldmanager.Instance.SpentGold(_rerollCost))
        {
            shuffleItem();
            _rerollCost += 2;
            _rerollText.text = $"Re Roll\r\n<color=#FFE62B>{_rerollCost}$</color>";
            _rerollClickText.text = _rerollText.text;
            GameEvent.Raise(GameEventType.ShopRerool);
        }
        
    }
    public void shuffleItem()
    {
        List<HackData> hackDatas = _hackPool.GiveHack(_hackItems.Length);
        for (int i = 0; i < _hackItems.Length; i++)
        {
            _hackItems[i].ItemSpawn(hackDatas[i]);
            _hackItems[i].ChangeState(true);
        }
        List<CheatData> cheatDatas = _cheatPool.GiveCheat(_cheatItems.Length);
        for (int i = 0; i < _cheatItems.Length; i++)
        {
            _cheatItems[i].ItemSpawn(cheatDatas[i]);
            _cheatItems[i].ChangeState(true);
        }
    }
    
    public void BuyItem(ItemData data, ShopItem item)
    {
        if (Goldmanager.Instance.SpentGold(data.Price))
        {
            if (data is HackData hack)
            {
                if (!_inventory.CanGetHack) return;
                _inventory.GetHack(hack);
                item.ChangeState(false);
                _hackPool.ItemRemove(hack);
            }
            else if (data is CheatData cheat)
            {
                if (!_inventory.CanGetCheat) return;
                _inventory.GetCheat(cheat);
                item.ChangeState(false);
            }
            GameEvent.Raise(GameEventType.BuyItem, data);
        }
        
    }

    public void SellHack(HackData data)
    {
        Goldmanager.Instance.GetGold(data.Price / 2);
        _hackPool.ItemAdd(data);
    }
}

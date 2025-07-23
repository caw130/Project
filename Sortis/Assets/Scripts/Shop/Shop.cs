using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Shop : MonoBehaviour
{
    [SerializeField] HackPool _hackPool;
    [SerializeField] CheatPool _cheatPool;
    [SerializeField] ItemInventory _inventory;
    [SerializeField] ShopItem[] _hackItems;
    [SerializeField] ShopItem[] _cheatItems;
    
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
        gameObject.SetActive(false);
        GameEvent.Raise(GameEventType.StartNewRound);
    }
    public void ShopOpen()
    {
        gameObject.SetActive(true);
        shuffleItem();
        _rerollCost = 5;
    }
    public void Reroll()
    {
        if (Goldmanager.Instance.SpentGold(_rerollCost))
        {
            shuffleItem();
            _rerollCost += 2;
        }
        
    }
    public void shuffleItem()
    {
        List<HackData> hackDatas = _hackPool.GiveHack(_hackItems.Length);
        Debug.Log(_hackItems.Length);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ShopOpen();
            //shuffleItem();
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] HackPool _hackPool;
    [SerializeField] CheatPool _cheatPool;
    [SerializeField] ItemInventory _inventory;
    [SerializeField] List<HackData> _hacks;
    [SerializeField] ShopItem[] _shopItem;

    private void Start()
    {
        _hackPool.InitializePool();
        
        Initialize();
    }

    public void Initialize()
    {
        foreach(var shop in _shopItem)
        {
            shop.Initialize(this);
        }
    }

    public void shuffleItem()
    {
        List<HackData> a = _hackPool.GiveHack(_shopItem.Length);
        for(int i = 0; i < _shopItem.Length; i++)
        {
            _shopItem[i].ItemSpawn(a[i]);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
                shuffleItem();
        }  
    }

    
    public void BuyItem(ItemData data)
    {
        if(data is HackData hack)
        {
            _hackPool.ItemRemove(hack);
        }
        else if(data is CheatData cheat)
        {
            
        }
    }
}

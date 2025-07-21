using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] HackPool _hackPool;
    [SerializeField] CheatPool _cheatPool;
    [SerializeField] ItemInventory _inventory;
    [SerializeField] List<HackData> _hacks;

    private void Start()
    {
        _hackPool.InitializePool();
        List<HackData> a = _hackPool.GiveHack(3);
        _hacks = a;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(_hacks.Count > 0)
            {
                _inventory.GetItem(_hacks[0]);
                _hackPool.ItemRemove(_hacks[0]);
                _hacks.RemoveAt(0);
                
            }
        }
    }
}

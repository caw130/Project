using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackInventoryUi : MonoBehaviour
{
    [SerializeField] ItemInventory _inventory;
    [SerializeField] HackItemPrefab _hackPrefab;
    [SerializeField] float _xSize;
    [SerializeField] float _ySize;

    [SerializeField] List<HackItemPrefab> _hacks;

    public void AddHack(HackEffectBase hack)
    {
        HackItemPrefab hackPrefab = Instantiate(_hackPrefab, transform);
        hackPrefab.SpawnHack(hack, this);
        _hacks.Add(hackPrefab);
        Rerange();
    }
    
    void Rerange()
    {
        float posY = _ySize / (_hacks.Count + 1);
        float startPos = -_ySize;
        for(int i = 0; i < _hacks.Count; i++)
        {
            _hacks[i].transform.localPosition = new Vector2(0, - _ySize/2 +(posY * (i+1)));
        }
    }

    public void SellHack(HackItemPrefab hack)
    {
        HackEffectBase item = hack.Hack;
        _inventory.SellHack(item);
        _hacks.Remove(hack);
        Rerange();
    }

    public void ResetInventory()
    {
        foreach(var hack in _hacks)
        {
            Destroy(hack.gameObject);
        }
        _hacks.Clear();
    }
    private void OnDrawGizmosSelected()
    {
        Vector2 line = new Vector2(_xSize, _ySize);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, line);
    }
}

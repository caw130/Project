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
        int line = _hacks.Count / 2 +_hacks.Count %2;
        float posY = _ySize / (line + 1);
        float startPos = -_ySize;
        float posX = _xSize / 4;
        for(int i = 0; i < _hacks.Count; i++)
        {
            if ((i + 1) % 2 == 0)
            {
                _hacks[i].transform.localPosition = new Vector2(-posX, -_ySize / 2 + (posY * (i/2 + 1)));
            }
            else if((i+1 == _hacks.Count))
            {
                _hacks[i].transform.localPosition = new Vector2(0, -_ySize / 2 + (posY * (i / 2 + 1)));
            }
            else
            {
                _hacks[i].transform.localPosition = new Vector2(posX, -_ySize / 2 + (posY * (i / 2 + 1)));
            }
            
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

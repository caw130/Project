using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatInventoryUi : MonoBehaviour
{
    [SerializeField] ItemInventory _inventory;
    [SerializeField] CheatItemPrefab _cheatPrefab;
    [SerializeField] float _xSize;
    [SerializeField] float _ySize;

    [SerializeField] List<CheatItemPrefab> _cheats;

    public void AddCheat(CheatEffectBase cheat)
    {
        CheatItemPrefab cheatPrefab = Instantiate(_cheatPrefab, transform);
        cheatPrefab.SpawnCheat(cheat, this);
        _cheats.Add(cheatPrefab);
        Rerange();
    }

    void Rerange()
    {
        float posX = _xSize / (_cheats.Count + 1);
        float startPos = -_xSize;
        for (int i = 0; i < _cheats.Count; i++)
        {
            _cheats[i].transform.localPosition = new Vector2( -_xSize / 2 + (posX * (i + 1)),0);
        }
    }

    public void RemoveCheat(CheatItemPrefab cheat)
    {
        CheatEffectBase item = cheat.Cheat;
        _inventory.RemoveCheat(item);
        _cheats.Remove(cheat);
        Rerange();
    }
    public void SellCheat(CheatItemPrefab cheat)
    {
        CheatEffectBase item = cheat.Cheat;
        _inventory.SellCheat(item);
        _cheats.Remove(cheat);
        Rerange();
    }
    public void ResetInventory()
    {
        foreach (var cheats in _cheats)
        {
            Destroy(cheats.gameObject);
        }
        _cheats.Clear();
    }
    private void OnDrawGizmosSelected()
    {
        Vector2 line = new Vector2(_xSize, _ySize);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, line);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatItemPrefab : MonoBehaviour
{
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] CheatInventoryUi _inventory;
    [SerializeField] CheatEffectBase _cheat;

    public void SpawnCheat(CheatEffectBase cheat, CheatInventoryUi inventory)
    {
        _cheat = cheat;
        _inventory = inventory;
    }
}

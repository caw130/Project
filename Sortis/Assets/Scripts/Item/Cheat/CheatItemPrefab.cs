using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatItemPrefab : MonoBehaviour, ICanClick, ICanHover
{
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] CheatInventoryUi _inventory;
    [SerializeField] CheatEffectBase _cheat;

    public bool Clickable { get; set; } = true;
    public bool Hoverable { get; set; } = true;
    public CheatEffectBase Cheat => _cheat;
    public void SpawnCheat(CheatEffectBase cheat, CheatInventoryUi inventory)
    {
        _cheat = cheat;
        _renderer.sprite = cheat.Data.Icon;
        _inventory = inventory;
    }
    public void HoverIn()
    {
        GameEvent.Raise(GameEventType.CheatInfo, this);
    }

    public void HoverOut()
    {
        GameEvent.Raise(GameEventType.CheatInfoHide);
    }

    public void OnClicked()
    {
        GameEvent.Raise(GameEventType.CheatUseShow, this);
    }
    
    public void UseCheat()
    {
        _cheat.Use();
        if (_cheat.Charges <= 0)
        {
            _inventory.RemoveCheat(this);
            GameEvent.Raise(GameEventType.CheatUseHide);
        }
    }

    public void SellCheat()
    {
        _inventory.SellCheat(this);
        GameEvent.Raise(GameEventType.CheatUseHide);
    }

}

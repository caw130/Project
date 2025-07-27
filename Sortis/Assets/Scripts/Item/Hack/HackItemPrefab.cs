using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackItemPrefab : MonoBehaviour, ICanClick
{
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] HackInventoryUi _inventory;
    [SerializeField] HackEffectBase _hack;
    public bool Clickable { get; set; } = true;
    public HackEffectBase Hack => _hack;

    public void SpawnHack(HackEffectBase hack, HackInventoryUi inventory)
    {
        _hack = hack;
        _renderer.sprite = hack.Data.Icon;
        _inventory = inventory;
    }
    public void SellItem()
    {
        _inventory.SellHack(this);
    }

    public void OnClicked()
    {
        GameEvent.Raise(GameEventType.HackInfo, this);
    }
}

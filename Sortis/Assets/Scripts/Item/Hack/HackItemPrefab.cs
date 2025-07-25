using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackItemPrefab : MonoBehaviour, ICanClick, ICanHover
{
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] HackInventoryUi _inventory;
    [SerializeField] HackEffectBase _hack;
    public bool Clickable { get; set; } = true;
    public bool Hoverable { get; set; } = true;
    public HackEffectBase Hack => _hack;

    public void SpawnHack(HackEffectBase hack, HackInventoryUi inventory)
    {
        _hack = hack;
        _renderer.sprite = hack.Data.Icon;
        _inventory = inventory;
    }
    public void SellItem()
    {
        _inventory.Sell(this);
    }
    public void HoverIn()
    {
    }

    public void HoverOut()
    {
    }

    public void OnClicked()
    {
        GameEvent.Raise(GameEventType.HackInfo, this);
    }
}

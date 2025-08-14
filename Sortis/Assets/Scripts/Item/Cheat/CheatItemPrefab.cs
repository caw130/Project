using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        transform.localScale = new Vector3(2,2,2);
        transform.DOKill();
        transform.DOShakeScale(1, new Vector3(1,1,1), 10);
        if (_cheat.Charges <= 0)
        {
            transform.DOKill();
            _inventory.RemoveCheat(this);
            GameEvent.Raise(GameEventType.CheatUseHide);
            RemoveCheat();
        }
    }

    public void SellCheat()
    {
        _inventory.SellCheat(this);
        GameEvent.Raise(GameEventType.CheatUseHide);
        RemoveCheat();
    }

    void RemoveCheat()
    {
        transform.transform.DOScale(new Vector3(3, 3, 3), 0.1f).OnComplete(()=> transform.DOScale(Vector3.zero, 0.2f).OnComplete(() => Destroy(this.gameObject)));
    }

}

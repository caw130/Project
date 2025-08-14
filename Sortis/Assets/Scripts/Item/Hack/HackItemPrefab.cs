using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackItemPrefab : MonoBehaviour, ICanClick
{
    [SerializeField] SpriteRenderer _renderer;
    HackInventoryUi _inventory;
    HackEffectBase _hack;

    [Header("Effect System")]
    [SerializeField] Vector3 _rotate;
    [SerializeField] Vector3 _scale;
    [SerializeField] float _time;

    [SerializeField] Ease _rotstartease;
    [SerializeField] Ease _rotendease;
    [SerializeField] Ease _scalestartEase;
    [SerializeField] Ease _scaleendEase;
    
    public bool Clickable { get; set; } = true;
    public HackEffectBase Hack => _hack;

    public void SpawnHack(HackEffectBase hack, HackInventoryUi inventory)
    {
        _hack = hack;
        _renderer.sprite = hack.Data.Icon;
        _inventory = inventory;
        hack.OnUsed += UseEffect;
    }
    public void SellItem()
    {
        Hack.OnUsed -= UseEffect;
        _inventory.SellHack(this);
        transform.DOKill();
        transform.transform.DOScale(new Vector3(2, 2, 2), 0.1f).OnComplete(() => transform.DOScale(Vector3.zero, 0.2f).OnComplete(() => Destroy(this.gameObject)));
    }

    public void OnClicked()
    {
        GameEvent.Raise(GameEventType.HackInfo, this);
    }

    void UseEffect()
    {
        transform.DOKill();
        transform.DORotate(_rotate, _time/2).SetEase(_rotstartease).OnComplete(() => transform.DORotate(Vector3.zero, _time/2)).SetEase(_rotendease);
        transform.DOScale(_scale, _time/2).SetEase(_scalestartEase).OnComplete(()=>transform.DOScale(Vector3.one,_time/2).SetEase(_scaleendEase));
    }
}

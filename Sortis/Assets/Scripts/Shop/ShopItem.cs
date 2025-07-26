using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image _icon;
    [SerializeField] TextMeshProUGUI _goldText;
    Shop _shop;
    ItemData _data;
    bool _blank = true;
    
    public void Initialize(Shop shop)
    {
        _shop = shop;
    }

    public void ItemSpawn(ItemData data)
    {
        transform.DOKill();
        transform.rotation = Quaternion.Euler(0, 0, 45f);
        transform.DORotate(Vector3.zero, 0.5f).SetEase(Ease.OutElastic);
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
        _data = data;
        _icon.sprite = _data.Icon;
        _goldText.text = $"{_data.Price}$";
        _blank = false;
    }
    public void ChangeState(bool state)
    {
        _blank = !state;
        gameObject.SetActive(state);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!_blank)
            _shop.BuyItem(_data,this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector2 pos = new Vector2(transform.position.x - 300, transform.position.y-20);
        _shop.ShowItemInfo(_data, pos);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _shop.HideItemInfo();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerClickHandler
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
}

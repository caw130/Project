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
    
    public void Initialize(Shop shop)
    {
        _shop = shop;
    }

    public void ItemSpawn(ItemData data)
    {
        _data = data;
        _icon.sprite = _data.Icon;
        _goldText.text = $"{_data.Price}$";
    }

    public void ItemSell()
    {
        _shop.BuyItem(_data);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Å¬¸¯");
    }
}

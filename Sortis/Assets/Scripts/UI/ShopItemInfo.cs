using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItemInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _description;
    [SerializeField] ItemData _data;

    public void Show(ItemData item, Vector2 pos)
    {
        _data = item;
        _name.text = _data.Name;
        _description.text = _data.Description;
        gameObject.SetActive(true);
        transform.position = pos;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

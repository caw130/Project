using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HackInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _description;
    [SerializeField] HackItemPrefab _hack;

    public void Show(HackItemPrefab hack,Vector2 dir)
    {
        _hack = hack;
        _name.text = _hack.Hack.Data.Name;
        _description.text = _hack.Hack.Data.Description;
        gameObject.SetActive(true);
        transform.position = Camera.main.WorldToScreenPoint(dir);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Sell()
    {
        _hack.SellItem();
        Hide();
    }
}

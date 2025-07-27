using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheatItemInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _description;
    [SerializeField] CheatItemPrefab _cheat;

    public void Show(CheatItemPrefab cheat, Vector2 dir)
    {
        _cheat = cheat;
        _name.text = _cheat.Cheat.Data.Name;
        _description.text = _cheat.Cheat.Data.Description;
        gameObject.SetActive(true);
        transform.position = Camera.main.WorldToScreenPoint(dir);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

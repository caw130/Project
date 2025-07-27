using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatUseUi : MonoBehaviour
{
    [SerializeField] CheatItemPrefab _cheat;

    public void UseCheat()
    {
        _cheat.UseCheat();
    }

    public void SellCheat()
    {
        _cheat.SellCheat();
    }

    public void Show(CheatItemPrefab cheat, Vector2 dir)
    {
        _cheat = cheat;
        gameObject.SetActive(true);
        transform.position = Camera.main.WorldToScreenPoint(dir);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

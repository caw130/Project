using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackUseUi : MonoBehaviour
{
    [SerializeField] HackItemPrefab _hack;

    public void SellCheat()
    {
        _hack.SellItem();
    }

    public void Show(HackItemPrefab hack, Vector2 dir)
    {
        _hack = hack;
        gameObject.SetActive(true);
        transform.position = Camera.main.WorldToScreenPoint(dir);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

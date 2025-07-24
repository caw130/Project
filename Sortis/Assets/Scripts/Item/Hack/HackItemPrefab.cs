using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackItemPrefab : MonoBehaviour, ICanClick, ICanHover
{
    [SerializeField] SpriteRenderer _renderer;
    public bool Clickable { get; set; } = true;
    public bool Hoverable { get; set; } = true;

    public void SpawnHack(HackData data)
    {
        _renderer.sprite = data.Icon;
    }

    public void HoverIn()
    {
    }

    public void HoverOut()
    {
    }

    public void OnClicked()
    {
    }
}

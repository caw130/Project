using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowCard : MonoBehaviour
{
    [SerializeField] Image _cardImage;

    public void Spawn(CardData data)
    {
        _cardImage.sprite = data.Sprite;

    }
}

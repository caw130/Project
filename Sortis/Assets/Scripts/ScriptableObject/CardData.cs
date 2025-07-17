using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "GameData/Card")]
public class CardData : ScriptableObject
{
    [SerializeField] CardSuit _suit;
    [SerializeField] Sprite _sprite;
    [SerializeField] int _num;
    [SerializeField] CardColor _color;

    public CardColor Color => _color;
    public CardSuit Suit => _suit;
    public Sprite Sprite => _sprite;
    public int Num => _num;
}

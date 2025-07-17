using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardPosition
{
    Hand,
    Deck,
    Zull,
    Back,
}
public enum CardType
{
    none,
    blank,
    digital,
    box,
    golden,
}
public enum CardSuit
{
    spade,
    diamond,
    clover,
    heart,
}

public enum CardColor
{
    red,
    black
}


public class CardAttribute : MonoBehaviour
{
    protected CardType _type;
    protected CardSuit _suit;
    protected CardColor _color;
    protected CardPosition _cardPosition;
    protected int _cardNum;
	
    
	public CardType Type => _type;
    public CardColor Color => _color;
    public CardSuit Suit => _suit;
    public CardPosition State => _cardPosition;
    public int Num => _cardNum;

    public void SetValue(CardType type ,CardSuit suit, int num)
    {
        _type = type;
        _suit = suit;
        _cardNum = num;
    }
}

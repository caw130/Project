using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThrowDeck : MonoBehaviour, ICanClick
{
    [SerializeField] List<CardData> _throwCards;
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] int _maxCard;
    bool _haveCard;
    public bool Clickable { get; set; } = false;

    public int ThrowCard => _throwCards.Count;
    public int MaxCard => _maxCard;

    private void Start()
    {
        SetRender();
    }
    public void CardDiscard(CardData throwCard)
    {
        _throwCards.Add(throwCard);
        SetRender();
    }
    public void OnClicked()
    {
        Debug.Log("It is ThrowDeck");
    }

    public List<CardData> ReturnCard()
    {
        List<CardData> cards = new List<CardData>();
        cards.AddRange(_throwCards);
        _throwCards.Clear();
        SetRender();
        return cards;
    }
    void SetRender()
    {
        _haveCard = _throwCards.Count > 0;
        Clickable = _haveCard;
        _renderer.enabled = _haveCard;
    }
    
    public void Clear()
    {
        _throwCards.Clear();
        SetRender();
    }

    public void RemoveData(int num)
    {
        _throwCards.RemoveAt(num);
    }
}

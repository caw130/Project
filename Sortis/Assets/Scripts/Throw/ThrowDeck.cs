using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThrowDeck : MonoBehaviour, ICanClick
{
    [SerializeField] List<CardData> _throwCards;
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] ThrowCardView _cardView;
    bool _haveCard;
    public bool Clickable { get; set; } = false;

    public int ThrowCard => _throwCards.Count;
    public int MaxCard => UserStat.Instance.MaxThrowCard;

    private void Update()
    {
        SetRender();
    }
    public void CardDiscard(CardData throwCard)
    {
        _throwCards.Add(throwCard);
    }
    public void OnClicked()
    {
        _cardView.Show(_throwCards, Vector2.zero);
    }

    public List<CardData> ReturnCard()
    {
        List<CardData> cards = new List<CardData>();
        cards.AddRange(_throwCards);
        _throwCards.Clear();
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
    }

    public void RemoveData(int num)
    {
        _throwCards.RemoveAt(num);
    }


}

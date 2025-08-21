using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThrowDeck : MonoBehaviour, ICanClick, ICanHover
{
    [SerializeField] List<CardData> _throwCards;
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] ThrowCardView _cardView;
    [SerializeField] Card _cardPrefab;
    Vector3 _originalScale = Vector3.one;
    [SerializeField] float _hoverScale;
    bool _haveCard;
    public bool Clickable { get; set; } = false;

    public int ThrowCard => _throwCards.Count;
    public int MaxCard => UserStat.Instance.MaxThrowCard;

    public bool Hoverable { get; set; } = false;

    private void Update()
    {
        SetRender();
    }
    public void CardDiscard(CardData throwCard)
    {
        _throwCards.Add(throwCard);
        if (_throwCards.Count > MaxCard) GameEvent.Raise(GameEventType.GameOver);
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

    public Card ReturnLastCard()
    {
        CardData data = _throwCards[_throwCards.Count - 1];
        Card card =Instantiate(_cardPrefab, transform.position, transform.rotation);
        card.Setup(data);
        card.CardChanged();
        _throwCards.Remove(data);
        return card;
    }
    void SetRender()
    {
        _haveCard = _throwCards.Count > 0;
        Clickable = _haveCard;
        Hoverable= _haveCard;
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

    public void HoverIn()
    {
        _renderer.transform.DOScale(_originalScale * _hoverScale, 0.2f).SetEase(Ease.OutBack);
    }

    public void HoverOut()
    {
        _renderer.transform.DOScale(_originalScale, 0.2f);
    }
}

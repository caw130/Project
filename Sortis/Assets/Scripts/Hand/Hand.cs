using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Hand : MonoBehaviour, ICardStacker
{
    [SerializeField] float _yuiSize;
    [SerializeField] float _xuiSize;
    [SerializeField] float _cardDepth;
    [SerializeField] List<Card> _drawCard;
    [SerializeField] ThrowDeck _throwDeck;
    /// <summary>
    /// 카드들의 위치를 손에서 재 배열
    /// </summary>
    void ReArrangeHand()
    {
        int count = _drawCard.Count;
        if (count == 0) return;

        float topy = _yuiSize / 2;
        float spacing = _yuiSize / (count + 1);
        for (int i = 0; i < count; i++)
        {
            Card currentCard = _drawCard[i];


            float yPos = topy - (spacing * (i+1));
            float zPos = i * _cardDepth;

            currentCard.transform.localPosition = new Vector3(0, yPos, zPos);

            bool state = (i == count - 1);
            currentCard.SetState(state);
        }
    }

    public void DiscardCard()
    {
        if (_drawCard.Count == 0) return;

        Card lastCard = _drawCard[0];
        GameEvent.Raise(GameEventType.OnCardDiscard, lastCard, this);
    }
    public void AddCard(Card card)
    {
        AddCard(new List<Card> { card });
    }

    public void RemoveCard(Card card)
    {
        if (_drawCard.Remove(card))
        {
            ReArrangeHand();
        }
    }



    public List<Card> SplitStackFrom(Card startCard)
    {
        _drawCard.Remove(startCard);
        ReArrangeHand();
        return new List<Card> { startCard };
    }

    public void AddCard(List<Card> cards)
    {
        foreach(var card in cards)
        {
            card.CardParent(this);
            _drawCard.Add(card);
        }
        while(UserStat.Instance.HandSize < _drawCard.Count)
        {
            DiscardCard();
        }
        ReArrangeHand();
    }

    public void ClearHand()
    {
        foreach (var card in _drawCard)
        {
            card.DestroyCardWithAnimation();
        }
        _drawCard.Clear();
    }

    public void DestroyHand()
    {
        foreach(var card in _drawCard)
        {
            Destroy(card.gameObject);
        }
        _drawCard.Clear();
    }

    /// <summary>
    /// 크기 가늠을 위해 추가
    /// </summary>

    private void OnDrawGizmosSelected()
    {
        Vector2 line = new Vector2(_xuiSize, _yuiSize);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, line);
    }
}

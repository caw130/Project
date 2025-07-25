using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleManager : MonoBehaviour
{
    [SerializeField] Deck _deck;
    [SerializeField] ThrowDeck _throwDeck;
    [SerializeField] CardShuffleAnimator _animator;
    public void ShuffleDeck()
    {
        List<CardData> newCard;
        newCard = _throwDeck.ReturnCard();
        int count = newCard.Count;
        _deck.MakeDeck();
        _deck.TakeList(newCard);
        _deck.Shuffle();
        _animator.AnimateShuffle(count);
        _animator.AnimamteDeckShuffle(_deck.Card);
    }

}

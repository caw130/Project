using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleManager : MonoBehaviour
{
    [SerializeField] Deck _deck;
    [SerializeField] ThrowDeck _throwDeck;
    [SerializeField] CardShuffleAnimator _animator;
    public void MakeAndShuffleDeck()
    {
        List<CardData> newCard;
        int deck = -_deck.Card;
        newCard = _throwDeck.ReturnCard();
        int count = newCard.Count;
        _deck.MakeDeck();
        _deck.TakeList(newCard);
        
        _deck.Shuffle();
        _animator.AnimateShuffle(count);
        deck += _deck.Card;
        _animator.AnimamteDeckShuffle(deck);
    }

    public void ShuffleDeck()
    {
        List<CardData> newCard;
        newCard = _throwDeck.ReturnCard();
        int count = newCard.Count;
        _deck.TakeList(newCard);
        _deck.Shuffle();
        _animator.AnimateShuffle(count);
        _animator.AnimamteDeckShuffle(count);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleManager : MonoBehaviour
{
    [SerializeField] Deck _deck;
    [SerializeField] ThrowDeck _throwDeck;

    public void ShuffleDeck()
    {
        List<CardData> newCard;
        newCard = _throwDeck.ReturnCard();
        _deck.MakeDeck();
        _deck.TakeList(newCard);
        _deck.Shuffle();
        Coroutine ddd = StartCoroutine(dd());
    }

    IEnumerator dd()
    {
        yield return null;
    }
}

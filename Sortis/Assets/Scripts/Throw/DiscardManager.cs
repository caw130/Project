using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardManager : MonoBehaviour
{
    [SerializeField] ThrowDeck _throwDeck;
    public void CardDiscard(GameEventType type, object a, object b)
    {
        if (!(type == GameEventType.OnCardDiscard)) return;
        if (!(a is Card cardToDiscard)) return;
        if (!(b is ICardStacker originalStacker)) return;
        
        CardData carddata = cardToDiscard.Data;

        _throwDeck.CardDiscard(carddata);
        cardToDiscard.transform.position = _throwDeck.transform.position;
        originalStacker.RemoveCard(cardToDiscard);

        cardToDiscard.transform.position = transform.position;
        cardToDiscard.DestroyCardWithAnimation();
        GameManager.Instance.SoundManager.PlayClip(SoundType.CardDisCard);
    }
}

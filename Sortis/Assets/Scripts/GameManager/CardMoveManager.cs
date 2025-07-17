using System.Collections.Generic;
using UnityEngine;

public class CardMoveManager : MonoBehaviour
{
    [SerializeField] ZullManager _zullManager;
    List<Card> _draggedCards;
    ICardStacker _originStacker;
    ICardStacker _newStacker;
    // Start is called before the first frame update
    public void GetAction(GameEventType type, object a, object b)
    {
        if(type == GameEventType.CardDrag)
        {
            if (!(a is Card card)) return;
            if (!(b is ICardStacker owner)) return;
            _originStacker = owner;
            FindDraggedCard(card);
        }
        else if(type == GameEventType.CardDrop)
        {
            if (!(a is Card card)) return;
            if (!(b is Vector3 pos)) return;
            DropCard(card, pos);
        }
    }
    void FindDraggedCard(Card card)
    {
        _draggedCards = _originStacker.SplitStackFrom(card);
        _zullManager.FindPlaceZulls(card);
    }

    void DropCard(Card car, Vector2 pos)
    {
        _newStacker = _zullManager.HandleCardDrop(pos);
        if (_newStacker != null)
        {

            _newStacker.AddCard(_draggedCards);

        }
        else
        {
            _originStacker.AddCard(_draggedCards);
        }
        _draggedCards = null;
        _originStacker = null;
    }
}

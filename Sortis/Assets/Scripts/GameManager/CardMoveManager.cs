using System.Collections.Generic;
using UnityEngine;

public class CardMoveManager : MonoBehaviour
{
    [SerializeField] ZullManager _zullManager;
    [SerializeField]List<Card> _draggedCards;
    ICardStacker _originStacker;
    ICardStacker _newStacker;
    Vector2 _currentpos;
    Vector2 _newpos;
    bool _isDrag = false;

    private void Update()
    {
        if (_isDrag && _draggedCards.Count >1)
        {
            _newpos = _draggedCards[0].transform.position;
            Vector2 pos = _currentpos - _newpos;
            for(int i = 1; i< _draggedCards.Count; i++)
            {
                _draggedCards[i].transform.Translate(-pos);
            }
            _currentpos = _newpos;
        }
    }

    public void GetAction(GameEventType type, object a, object b)
    {
        if(type == GameEventType.CardDrag)
        {
            if (!(a is Card card)) return;
            if (!(b is ICardStacker owner)) return;
            _originStacker = owner;
            FindDraggedCard(card);
            _currentpos = _draggedCards[0].transform.position;
            SetSort(100);
            _isDrag = true;
        }
        else if(type == GameEventType.CardDrop)
        {
            if (!(a is Card card)) return;
            if (!(b is Vector3 pos)) return;
            SetSort(1);
            DropCard(card, pos);
            _isDrag = false;
        }
    }
    void FindDraggedCard(Card card)
    {
        _draggedCards = _originStacker.SplitStackFrom(card);
        _zullManager.FindPlaceZulls(card);
    }
    void SetSort(int amount)
    {
        foreach(var card in _draggedCards)
        {
            card.SetSorting(amount);
        }
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

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour, ICanClick
{
    [SerializeField] Card _cardPrefab;
    [SerializeField] Hand _hands;
    [SerializeField] Deck _deck;
    Card _card;
    public bool Clickable { get; set; } = true;

    private void Awake()
    {
        SetCard();
    }
    public void OnClicked()
    {
        
        CardData data =_deck.Draw();
        if (data == null)
        {
            GameEvent.Raise(GameEventType.RoundEnded);
            return;
        }


        _card.SetState(true);
        _card.Setup(data);
        _card.SetSorting(1);
        _hands.AddCard(_card);
        GameEvent.Raise(GameEventType.Draw, _card);
        
        Debug.Log("GetCard");
        _card = null;
        SetCard();
        GameManager.Instance.SoundManager.PlayClip(SoundType.Draw);

    }
    void SetCard()
    {
        _card = Instantiate(_cardPrefab);
        _card.transform.position = new Vector3(transform.position.x, transform.position.y, -2f);
        _card.SetState(false);
        _card.SetSorting(1);
    }

    public void ReturnCard()
    {
        List<CardData> cards = new List<CardData>();
        foreach(var card in _hands.Cards)
        {
            cards.Add(card.Data);
        }
        _deck.TakeList(cards);
        _hands.ClearHand();
    }
}

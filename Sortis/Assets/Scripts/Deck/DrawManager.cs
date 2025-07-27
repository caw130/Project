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
        GameEvent.Raise(GameEventType.Draw, _card);
        _hands.AddCard(_card);
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
}

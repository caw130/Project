using System.Collections.Generic;
using UnityEngine;

public class Zull : MonoBehaviour, ICardStacker
{
    [Header("수정 가능한 값")]
    [SerializeField] float _placeDistance;
    [SerializeField] float _cardDistance;
    [SerializeField] float _cardDepth;
    [SerializeField] List<Card> _cards = new List<Card>();
    public Vector3 InteractPoint
    {
        get
        {
            if (_cards.Count == 0)
            {
                return transform.position;
            }
            else
            {
                return _cards[_cards.Count - 1].transform.position;
            }
        }
    }

    /// <summary>
    /// 이 줄에 카드를 놓을 수 있는가
    /// </summary>
    /// <param name="selectedCard">플레이어가 들고 있는 카드</param>
    /// <returns></returns>
    public bool CheckCanPlace(Card selectedCard)
    {
        // 이 줄에 놓은 카드가 없으면
        if (_cards.Count == 0)
        {
            return true;
        }

        // 내가 마지막으로 놓은 카드 가져오기
        Card lastCard = _cards[_cards.Count - 1];
        // 만약 내가 놓은 카드가 들고있는 카드와 색이 다르고, 수가 1 차이가 날 경우
        if (lastCard.Color != selectedCard.Color && (lastCard.Num - 1) == selectedCard.Num)
        {
            return true;
        }

        // 아무것도 아닐때
        return false;
    }
    public void AddCard(Card card)
    {
        AddCard(new List<Card> { card });
    }

    public void AddCard(List<Card> cards)
    {
        foreach (var card in cards)
        {
            if (!card.HasBeenOnZull)
            {
                card.HasBeenOnZull = true;
                GameEvent.Raise(GameEventType.FirstTypeCardDrop);
                Goldmanager.Instance.GetGold(1);
                UserStat.Instance.AddTotalUsedCard();
            }
            card.CardParent(this);
            _cards.Add(card);
        }
        RerangeCardPosition();
        CheckZullComplete();
    }

    public void ZullCardsRemove()
    {
        foreach (var card in _cards)
        {
            card.transform.position = transform.position;
            card.DestroyCardWithAnimation();
        }
        _cards.Clear();
    }

    public void ClearZull()
    {
        foreach (var card in _cards)
        {
            Destroy(card.gameObject);
        }
        _cards.Clear();
    }
    public void RerangeCardPosition()
    {
        if (!(_cards.Count > 0)) return;
        for (int i = 0; i < _cards.Count; i++)
        {
            float cardRange = _cardDistance * i;
            float cardDepth = _cardDepth * i;
            Vector3 pos = new Vector3(0, -cardRange, -cardDepth);
            _cards[i].transform.localPosition = pos;
        }
    }
    public void RemoveCard(Card card)
    {
        _cards.Remove(card);
        RerangeCardPosition();
    }

    public List<Card> SplitStackFrom(Card startCard)
    {
        if (!(startCard is Card startingCard))
        {
            
            return new List<Card>();
        }

        int startIndex = _cards.IndexOf(startingCard);

        if (startIndex == -1)
        {
            
            return new List<Card>();
        }

        List<Card> splitGroup = new List<Card>();

        for (int i = startIndex; i < _cards.Count; i++)
        {
            splitGroup.Add(_cards[i]);
        }
        _cards.RemoveRange(startIndex, splitGroup.Count);
        return splitGroup;
    }

    public void SetDistance(float dis)
    {
        _placeDistance = dis;
    }
    public void CheckZullComplete()
    {
        if (_cards.Count < UserStat.Instance.ZullNeedCard) return;
        GameEvent.Raise(GameEventType.ZullComplete, this);
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractPoint, _placeDistance);
    }


}

using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class Deck : MonoBehaviour
{
    [SerializeField] List<CardData> _deck = new List<CardData>();
    [SerializeField] CardDataManager _datas;
    [SerializeField] SpriteRenderer _renderer;
    bool _haveCard;

    public int Card => _deck.Count;
    /// <summary>
    /// 덱 만들기 
    /// </summary>
    public void MakeDeck()
    {
        //_dats에서 데이터 가져오기
        _deck.AddRange(_datas.Data);
    }

    /// <summary>
    /// 카드를 뽑는 스크립트
    /// </summary>
    public CardData Draw()
    {
        if (_deck.Count == 0)
        {
            return null;
        }
        
        CardData data = _deck[0];
        _deck.RemoveAt(0);
        SetRender();
        return data;
    }

    /// <summary>
    /// 덱을 섞는 스크립트
    /// </summary>
    public void Shuffle()
    {
        for(int i = _deck.Count-1; i >= 0; i--)
        {
            int r = Random.Range(0, i+1);

            (_deck[i], _deck[r]) = (_deck[r], _deck[i]);
        }
        SetRender();
    }

    public void TakeList(List<CardData> cards)
    {
        _deck.AddRange(cards);
    }

    void SetRender()
    {
        _haveCard = _deck.Count > 0;
        _renderer.enabled = _haveCard;
    }

    public void ClearDeck()
    {
        _deck.Clear();
        SetRender();
    }
}

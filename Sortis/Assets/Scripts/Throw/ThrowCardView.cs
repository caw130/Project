using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ThrowCardView : MonoBehaviour
{
    [SerializeField] ThrowCard _throwCardPrefab;
    [SerializeField] RectTransform _backGround;
    [SerializeField] GameObject _panel;
    [SerializeField] float posX;
    [SerializeField] float posY;
    [SerializeField] List<ThrowCard> _throwCards = new List<ThrowCard>();

    public void Show(List<CardData> datas, Vector2 pos)
    {
        foreach (var data in datas)
        {
            ThrowCard card = Instantiate(_throwCardPrefab, transform);
            card.Spawn(data);
            _throwCards.Add(card);
        }
        Setsize();
        _panel.gameObject.SetActive(true);
        _backGround.localScale = Vector2.zero; 
        _backGround.DOScale(1, 0.5f);
    }
    public void Hide()
    {
        foreach(var card in _throwCards)
        {
            Destroy(card.gameObject);
        }
        _throwCards.Clear();
        _backGround.DOScale(0, 0.5f).OnComplete(() =>
        {
            _panel.gameObject.SetActive(false);
        });
        

    }
    void Setsize()
    {
        int countY = (_throwCards.Count - 1) / 10;
        int countX = (countY > 0) ? 10 : _throwCards.Count;
        Vector2 rectSize = new Vector2(posX * countX + 40, posY * (countY + 1) + 60);
        _backGround.sizeDelta = rectSize;
    }
    
}

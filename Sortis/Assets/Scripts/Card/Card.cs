using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : CardAttribute, ICanDrag, ICanClick, ICanHover
{
    [Header("흔들림 효과 설정")]
    [Tooltip("흔들림이 지속되는 시간")]
    [SerializeField] float wobbleDuration = 0.5f;

    [Tooltip("흔들리는 강도 (각도)")]
    [SerializeField] float wobbleStrength = 15f;

    [Tooltip("초당 흔들리는 횟수")]
    [SerializeField] int wobbleVibrato = 20;

    [Header("사라지는 효과 설정")]
    [Tooltip("사라지는 데 걸리는 시간")]
    [SerializeField] float destroyDuration = 0.3f;


    [SerializeField] CardAnim _anim;
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] SpriteRenderer _backRenderer;
    [SerializeField] SpriteRenderer _shadowRenderer;
    ICardStacker _owner;
    CardData _data;
    public bool Dragable { get; set; } = true;
    public bool Clickable { get; set; } = true;
    public bool Hoverable { get; set; } = true;
    public bool HasBeenOnZull { get; set; } = false;
    public ICardStacker Owner => _owner;
    public CardData Data => _data;
    /// <summary>
    /// 카드 스프라이트를 전환하는 함수
    /// </summary>
    public void CardChanged()
    {
        _color = _data.Color;
        _suit = _data.Suit;
        _cardNum = _data.Num;
        if (_cardNum < 0 || _cardNum > 13)
            _cardNum = 1;
        _renderer.sprite = _data.Sprite;
    }

    /// <summary>
    /// 카드가 스폰 되었을 때 실행하는 함수
    /// </summary>
    /// <param name="suit">카드의 문양</param>
    /// <param name="num">카드의 수</param>
    public void Setup(CardData data)
    {
        _data = data;
        CardChanged();
    }

    public void SetState(bool state)
    {
        Clickable = state;
        Dragable = state;
        Hoverable = state;
    }
    public void CardParent(ICardStacker owner)
    {
        _owner = owner;
        
        transform.SetParent(_owner.transform);
    }
    public void SetSorting(int amount)
    {
        _renderer.sortingOrder = amount;
        _backRenderer.sortingOrder = amount;
        _shadowRenderer.sortingOrder = amount - 1;
    }
    public void DestroyCardWithAnimation()
    {
        transform.DOShakeRotation(wobbleDuration, new Vector3(0, 0, wobbleStrength), wobbleVibrato)
            .SetEase(Ease.OutQuad)
            // 2. (핵심) 흔들림이 끝나면, 이어서 사라지는 애니메이션을 실행합니다.
            .OnComplete(() =>
            {
                // 사라지는 애니메이션 시퀀스 생성
                Sequence destroySequence = DOTween.Sequence();
                destroySequence.Join(transform.DOScale(0f, destroyDuration).SetEase(Ease.InBack));
                destroySequence.Join(GetComponent<SpriteRenderer>().DOFade(0f, destroyDuration));

                // 3. 사라지는 애니메이션까지 모두 끝나면, 게임 오브젝트를 최종적으로 파괴합니다.
                destroySequence.OnComplete(() =>
                {
                    Destroy(gameObject);
                });
            });
    }
    #region Drag
    public void OnBeginDrag()
    {
        
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        SetSorting(100);
        GameEvent.Raise(GameEventType.CardDrag,this,_owner);
    }
    public void OnDrag(Vector2 pos)
    {
        transform.position = pos;
    }
    public void OnDrop()
    {
        GameEvent.Raise(GameEventType.CardDrop, this, transform.position);
        transform.localScale = Vector3.one;
        SetSorting(1);
    }
    #endregion

    // 클릭
    public void OnClicked()
    {
    }

    #region Hover
    public void HoverIn()
    {
        _anim.Selected();
    }

    public void HoverOut()
    {

        _anim.SelectedOut();
    }
    #endregion
}

using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : CardAttribute, ICanDrag, ICanClick, ICanHover
{
    [Header("��鸲 ȿ�� ����")]
    [Tooltip("��鸲�� ���ӵǴ� �ð�")]
    [SerializeField] float wobbleDuration = 0.5f;

    [Tooltip("��鸮�� ���� (����)")]
    [SerializeField] float wobbleStrength = 15f;

    [Tooltip("�ʴ� ��鸮�� Ƚ��")]
    [SerializeField] int wobbleVibrato = 20;

    [Header("������� ȿ�� ����")]
    [Tooltip("������� �� �ɸ��� �ð�")]
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
    /// ī�� ��������Ʈ�� ��ȯ�ϴ� �Լ�
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
    /// ī�尡 ���� �Ǿ��� �� �����ϴ� �Լ�
    /// </summary>
    /// <param name="suit">ī���� ����</param>
    /// <param name="num">ī���� ��</param>
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
            // 2. (�ٽ�) ��鸲�� ������, �̾ ������� �ִϸ��̼��� �����մϴ�.
            .OnComplete(() =>
            {
                // ������� �ִϸ��̼� ������ ����
                Sequence destroySequence = DOTween.Sequence();
                destroySequence.Join(transform.DOScale(0f, destroyDuration).SetEase(Ease.InBack));
                destroySequence.Join(GetComponent<SpriteRenderer>().DOFade(0f, destroyDuration));

                // 3. ������� �ִϸ��̼Ǳ��� ��� ������, ���� ������Ʈ�� ���������� �ı��մϴ�.
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

    // Ŭ��
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

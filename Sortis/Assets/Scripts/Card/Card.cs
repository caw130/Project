using DG.Tweening;
using UnityEngine;

public class Card : CardAttribute, ICanDrag, ICanClick, ICanHover
{

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
        _shadowRenderer.sortingOrder = amount;
    }
    public void DestroyCardWithAnimation()
    {
        // Ȥ�� �ٸ� �ִϸ��̼��� ���� ���� �� ������, ���� �������� �ݴϴ�.
        transform.DOKill();

        // 1. �������� ����� ���� �ִϸ��̼��� ���ÿ� �����մϴ�.
        Sequence destroySequence = DOTween.Sequence();

        // 2. 0.5�� ���� ���������� �ִϸ��̼ǰ� �۾����� �ִϸ��̼��� ���ÿ� �����մϴ�.
        destroySequence.Join(transform.DOScale(0f, 0.5f).SetEase(Ease.InBack)); // 0��� �۾���

        // 3. (�ٽ�) ���� ��� �ִϸ��̼��� ������, OnComplete ���� �ڵ带 �����մϴ�.
        destroySequence.OnComplete(() =>
        {
            // �� ���� ������Ʈ�� �ı��մϴ�.
            Destroy(gameObject);
        });
    }
    #region Drag
    public void OnBeginDrag()
    {
        SetSorting(100);
        GameEvent.Raise(GameEventType.CardDrag, this, _owner);
    }
    public void OnDrag(Vector2 pos)
    {
        transform.position = pos;
    }
    public void OnDrop()
    {
        GameEvent.Raise(GameEventType.CardDrop, this, transform.position);
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
    private void OnDestroy()
    {
        transform.DOKill();
    }
}

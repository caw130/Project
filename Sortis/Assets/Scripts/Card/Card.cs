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
        _shadowRenderer.sortingOrder = amount;
    }
    public void DestroyCardWithAnimation()
    {
        // 혹시 다른 애니메이션이 실행 중일 수 있으니, 먼저 중지시켜 줍니다.
        transform.DOKill();

        // 1. 시퀀스를 만들어 여러 애니메이션을 동시에 실행합니다.
        Sequence destroySequence = DOTween.Sequence();

        // 2. 0.5초 동안 투명해지는 애니메이션과 작아지는 애니메이션을 동시에 실행합니다.
        destroySequence.Join(transform.DOScale(0f, 0.5f).SetEase(Ease.InBack)); // 0배로 작아짐

        // 3. (핵심) 위의 모든 애니메이션이 끝나면, OnComplete 안의 코드를 실행합니다.
        destroySequence.OnComplete(() =>
        {
            // 이 게임 오브젝트를 파괴합니다.
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
    private void OnDestroy()
    {
        transform.DOKill();
    }
}

using DG.Tweening;
using UnityEngine;

/// <summary>
/// 실제 카드 오브젝트
/// </summary>
public class Card : CardAttribute, ICanDrag, ICanClick, ICanHover
{
    [Header("Animation")]
    [SerializeField] CardAnim _anim;

    [Header("Renderers")]
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] SpriteRenderer _backRenderer;
    [SerializeField] SpriteRenderer _shadowRenderer;

    // 현재 이 카드가 속해있는 부분
    ICardStacker _owner;

    //현재 이 카드의 데이터
    CardData _data;


    public bool Dragable { get; set; } = true;
    public bool Clickable { get; set; } = true;
    public bool Hoverable { get; set; } = true;
    public bool HasBeenOnZull { get; set; } = false;


    public ICardStacker Owner => _owner;
    public CardData Data => _data;

    public void CardChanged()
    {
        _color = _data.Color;
        _suit = _data.Suit;
        _cardNum = _data.Num;
        if (_cardNum < 0 || _cardNum > 13)
            _cardNum = 1;
        _renderer.sprite = _data.Sprite;
    }

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
        transform.DOKill();

        Sequence destroySequence = DOTween.Sequence();
        destroySequence.Join(transform.DOScale(0f, 0.5f).SetEase(Ease.InBack)); 


        destroySequence.OnComplete(() =>
        {

            Destroy(gameObject);
        });
    }
    #region Drag
    public void OnBeginDrag()
    {
        SetSorting(100);
        GameEvent.Raise(GameEventType.CardDrag, this, _owner);
        GameManager.Instance.SoundManager.PlayClip(SoundType.CardClick);
    }
    public void OnDrag(Vector2 pos)
    {
        transform.position = pos;
    }
    public void OnDrop()
    {
        GameEvent.Raise(GameEventType.CardDrop, this, transform.position);
        GameManager.Instance.SoundManager.PlayClip(SoundType.CardPlace);
        SetSorting(1);
    }
    #endregion


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

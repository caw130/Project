using DG.Tweening;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] float _showDuration;
    [SerializeField] float _startOffsetY;
    [SerializeField] RectTransform _rectTransform;
    [SerializeField] Vector2 _originPos;
    [SerializeField] Vector2 _startPos;

    public void Initialize()
    {
        _originPos = _rectTransform.anchoredPosition;
        _startPos = _originPos;
        _startPos.y = _startPos.y - _startOffsetY;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _rectTransform.DOAnchorPos(_originPos, _showDuration).SetEase(Ease.OutBack);
    }
    public void Hide()
    {
        _rectTransform.DOAnchorPos(_startPos, _showDuration).SetEase(Ease.OutBack).
            OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
    }

}

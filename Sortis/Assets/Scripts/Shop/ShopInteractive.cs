using DG.Tweening;
using UnityEngine;

public class ShopInteractive : MonoBehaviour
{
    [SerializeField] Vector3 _hidePos;
    [SerializeField] Vector3 _showPos;
    [SerializeField] float _animDuration;
    [SerializeField] Ease _showEase;
    [SerializeField] Ease _hideEase;
    public void Show()
    {
        gameObject.SetActive(true);
        transform.DOLocalMove(_showPos, _animDuration).SetEase(_showEase);
    }
    public void Hide()
    {
        transform.DOLocalMove(_hidePos, _animDuration).SetEase(_hideEase).
            OnComplete(() =>
            {
            gameObject.SetActive(false);
            });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Show();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Hide();
        }
    }
}

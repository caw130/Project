using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnim : MonoBehaviour
{
    Vector3 _originalScale = new Vector3(1, 1, 1);
    [SerializeField] float _hoverScale;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _maxTiltAngle;
    [SerializeField] float _tiltDex;
    [SerializeField] Ease _moveEase = Ease.OutQuad;
    [SerializeField] Ease _backEase = Ease.Flash;
    Transform _parentTransform;
    Vector3 _lastParentPosition;

    private void Awake()
    {
        _parentTransform = transform.parent;
    }
    private void Update()
    {
        transform.DOMove(_parentTransform.position, _moveSpeed).SetEase(_moveEase);

        Vector3 parentMoveDelta = _parentTransform.position - _lastParentPosition;
        _lastParentPosition = _parentTransform.position;

        float targetTiltZ = -parentMoveDelta.x * _tiltDex;
        targetTiltZ = Mathf.Clamp(targetTiltZ, -_maxTiltAngle, _maxTiltAngle);

        transform.DORotate(new Vector3(0, 0, -targetTiltZ), _moveSpeed);
    }
    public void Settransform(Transform tr)
    {
        _parentTransform = tr;
    }
    public void flip()
    {
        Vector3 targetRotation = transform.localEulerAngles + new Vector3(0, 180, 0);

        Sequence flipSequence = DOTween.Sequence();

        flipSequence.Append(transform.DORotate(targetRotation, 2)
            .SetEase(Ease.InQuad));

    }

    public void Selected()
    {
        transform.DOScale(_originalScale * _hoverScale, 0.2f).SetEase(Ease.OutBack);
    }

    public void SelectedOut()
    {
        transform.DOScale(_originalScale, 0.2f);
    }

    public void OnBeginDrag()
    {
        _lastParentPosition = _parentTransform.position;
    }
    public void OnDrag(Vector2 parentTargetPosition)
    {
        
    }

    public void OnDragEnd()
    {
        transform.DOLocalMove(Vector3.zero, 0.25f).SetEase(_backEase);
        transform.DOLocalRotate(Vector3.zero, 0.25f).SetEase(Ease.OutBack);
    }
    private void OnDestroy()
    {
        transform.DOKill();
    }
}

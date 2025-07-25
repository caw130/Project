using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShuffleAnimator : MonoBehaviour
{
    [Header("�ִϸ��̼� ����")]
    [SerializeField] GameObject _effectCardPrefab;
    [SerializeField] Transform _discardPilePosition; 
    [SerializeField] Transform _deckPosition;
    [SerializeField] Transform _shuffleStart;
    [SerializeField] Transform _cardDiscardPoint;
    [SerializeField] float _moveDuration = 0.5f;
    [SerializeField] float _delayBetweenCards = 0.05f;
    [SerializeField] Ease _ease;

    // �� �Լ��� ȣ���ϸ� �ִϸ��̼��� ���۵˴ϴ�.
    // ���� 'ī�� ������ ����Ʈ'�� ���ڷ� �޽��ϴ�.
    public void AnimateShuffle(int count)
    {
        // ��ü �ִϸ��̼��� ���� �������� �����մϴ�.
        Sequence shuffleSequence = DOTween.Sequence();

        // foreach ������ ����Ͽ� ������ �� ī�� �����Ϳ� ���� �ִϸ��̼��� ����ϴ�.
        for (int i = 0; i < count; i++)
        {
            // 1. (�ٽ�) '�ִϸ��̼� ���� ī��'�� ���� ī�� ���� ��ġ�� �����մϴ�.
            GameObject cardObject = Instantiate(_effectCardPrefab, _discardPilePosition.position, Quaternion.identity, _cardDiscardPoint);
            Vector3 targetRotation = new Vector3(_cardDiscardPoint.rotation.x, _cardDiscardPoint.rotation.y, _cardDiscardPoint.rotation.z);
            Tween cardRotate = cardObject.transform.DORotate(targetRotation, _moveDuration);
            // 4. �� ī���� �̵� �ִϸ��̼�(Tween)�� ����ϴ�.
            Tween cardMoveTween = cardObject.transform.DOMove(_cardDiscardPoint.position, _moveDuration)
                .SetEase(_ease)
                .OnComplete(() =>
                {
                    // 5. �ִϸ��̼��� ������ '�ִϸ��̼� ���� ī��'�� �ı��մϴ�.
                    Destroy(cardObject);
                });

            // 6. Insert�� ����� �� �ִϸ��̼��� �ణ�� �ð� ���� �ΰ� �����ϰ� �մϴ�.
            shuffleSequence.Insert(i * _delayBetweenCards, cardMoveTween);
            shuffleSequence.Join(cardRotate);
        }
    }

    public void AnimamteDeckShuffle(int count)
    {
        for(int i = 0; i<count; i++)
        {
            Sequence shuffleSequence = DOTween.Sequence();
            GameObject cardObject = Instantiate(_effectCardPrefab, _shuffleStart.position, _shuffleStart.rotation);


            Tween cardRotateTween = cardObject.transform.DORotate(Vector3.zero, _moveDuration);
            Tween cardMoveTween = cardObject.transform.DOMove(_deckPosition.position, _moveDuration/2).SetEase(_ease).
                OnComplete(() =>
                {
                    Destroy(cardObject);
                });
            shuffleSequence.Insert(i * _delayBetweenCards/2, cardMoveTween);
            shuffleSequence.Join(cardRotateTween);
        }
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShuffleAnimator : MonoBehaviour
{
    [Header("�ִϸ��̼� ����")]
    [SerializeField] GameObject _effectCardPrefab; // 1�ܰ迡�� ���� '�ִϸ��̼� ���� ī��' ������
    [SerializeField] Transform _discardPilePosition; // ���� ī�� ������ ȭ��� ��ġ
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
            GameObject cardObject = Instantiate(_effectCardPrefab, _discardPilePosition.position, Quaternion.identity);

            Vector3 targetPosition = new Vector3(_discardPilePosition.position.x, 10, cardObject.transform.position.z);

            // 4. �� ī���� �̵� �ִϸ��̼�(Tween)�� ����ϴ�.
            Tween cardMoveTween = cardObject.transform.DOMove(targetPosition, _moveDuration)
                .SetEase(_ease)
                .OnComplete(() =>
                {
                    // 5. �ִϸ��̼��� ������ '�ִϸ��̼� ���� ī��'�� �ı��մϴ�.
                    Destroy(cardObject);
                });

            // 6. Insert�� ����� �� �ִϸ��̼��� �ణ�� �ð� ���� �ΰ� �����ϰ� �մϴ�.
            shuffleSequence.Insert(i * _delayBetweenCards, cardMoveTween);
        }
    }
}

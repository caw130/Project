using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShuffleAnimator : MonoBehaviour
{
    [Header("애니메이션 설정")]
    [SerializeField] GameObject _effectCardPrefab;
    [SerializeField] Transform _discardPilePosition; 
    [SerializeField] Transform _deckPosition;
    [SerializeField] Transform _shuffleStart;
    [SerializeField] Transform _cardDiscardPoint;
    [SerializeField] float _moveDuration = 0.5f;
    [SerializeField] float _delayBetweenCards = 0.05f;
    [SerializeField] Ease _ease;

    // 이 함수를 호출하면 애니메이션이 시작됩니다.
    // 이제 '카드 데이터 리스트'를 인자로 받습니다.
    public void AnimateShuffle(int count)
    {
        // 전체 애니메이션을 담을 시퀀스를 생성합니다.
        Sequence shuffleSequence = DOTween.Sequence();

        // foreach 루프를 사용하여 버려진 각 카드 데이터에 대한 애니메이션을 만듭니다.
        for (int i = 0; i < count; i++)
        {
            // 1. (핵심) '애니메이션 전용 카드'를 버린 카드 더미 위치에 생성합니다.
            GameObject cardObject = Instantiate(_effectCardPrefab, _discardPilePosition.position, Quaternion.identity, _cardDiscardPoint);
            Vector3 targetRotation = new Vector3(_cardDiscardPoint.rotation.x, _cardDiscardPoint.rotation.y, _cardDiscardPoint.rotation.z);
            Tween cardRotate = cardObject.transform.DORotate(targetRotation, _moveDuration);
            // 4. 각 카드의 이동 애니메이션(Tween)을 만듭니다.
            Tween cardMoveTween = cardObject.transform.DOMove(_cardDiscardPoint.position, _moveDuration)
                .SetEase(_ease)
                .OnComplete(() =>
                {
                    // 5. 애니메이션이 끝나면 '애니메이션 전용 카드'를 파괴합니다.
                    Destroy(cardObject);
                });

            // 6. Insert를 사용해 각 애니메이션을 약간의 시간 차를 두고 시작하게 합니다.
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

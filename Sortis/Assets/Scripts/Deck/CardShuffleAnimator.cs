using DG.Tweening;
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

    public void AnimateShuffle(int count)
    {
        Sequence shuffleSequence = DOTween.Sequence();

        for (int i = 0; i < count; i++)
        {
            GameObject cardObject = Instantiate(_effectCardPrefab, _discardPilePosition.position, Quaternion.identity, _cardDiscardPoint);
            Vector3 targetRotation = new Vector3(_cardDiscardPoint.rotation.x, _cardDiscardPoint.rotation.y, _cardDiscardPoint.rotation.z);
            Tween cardRotate = cardObject.transform.DORotate(targetRotation, _moveDuration).
                OnStart(() =>
                {
                    GameManager.Instance.SoundManager.PlayClip(SoundType.Shuffle);
                });
            Tween cardMoveTween = cardObject.transform.DOMove(_cardDiscardPoint.position, _moveDuration)
                .SetEase(_ease)
                .OnComplete(() =>
                {
                    Destroy(cardObject);
                });
            shuffleSequence.Insert(i * _delayBetweenCards, cardMoveTween);
            shuffleSequence.Join(cardRotate);
        }
    }

    public void AnimamteDeckShuffle(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Sequence shuffleSequence = DOTween.Sequence();
            GameObject cardObject = Instantiate(_effectCardPrefab, _shuffleStart.position, _shuffleStart.rotation);


            Tween cardRotateTween = cardObject.transform.DORotate(Vector3.zero, _moveDuration).
                OnStart(() =>
                {
                    GameManager.Instance.SoundManager.PlayClip(SoundType.Shuffle);
                });
            Tween cardMoveTween = cardObject.transform.DOMove(_deckPosition.position, _moveDuration / 2).SetEase(_ease).
                OnComplete(() =>
                {
                    Destroy(cardObject);
                });
            shuffleSequence.Insert(i * _delayBetweenCards / 2, cardMoveTween);
            shuffleSequence.Join(cardRotateTween);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStat : MonoBehaviour
{
    /*
    최대 줄 수
    줄 제거 조건
    손 크기
    치트 크기
    최대 버릴 카드
     */
    public static UserStat Instance { get; set; }
    int _totalGold;
    int _totalUsedCard;
    int _totalCompletedZull;
    int _maxZull = 6;
    int _zullNeedCard = 13;
    int _handSize = 3;
    int _maxCheatSize = 3;
    int _maxThrowCard = 20;

    public int TotalGold => _totalGold;
    public int TotalUsedCard => _totalUsedCard;
    public int TotalCompletedZull => _totalCompletedZull;
    public int MaxZull => _maxZull;
    public int ZullNeedCard => _zullNeedCard;
    public int HandSize => _handSize;
    public int MaxCheatSize => _maxCheatSize;
    public int MaxThrowCard => _maxThrowCard;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
        ResetIndex();
    }

    public void AddGold(int gold)
    {
        _totalGold += gold;
    }

    public void AddTotalUsedCard()
    {
        _totalUsedCard++;
    }
    public void AddTotlaCompleteZull()
    {
        _totalCompletedZull++;
    }

    public void ChangeMaxZull(int num)
    {
        _maxZull += num;
    }
    public void ChangeZullNeedCard(int num)
    {
        _zullNeedCard += num;
    }
    public void ChangHandSize(int num)
    {
        _handSize += num;
    }
    public void ChangeMaxCheatSize(int num)
    {
        _maxCheatSize += num;
    }
    public void ChangeMaxThrowCard(int num)
    {
        _maxThrowCard += num;
    }

    public void ResetIndex()
    {
        _totalCompletedZull = 0;
        _totalGold = 0;
        _totalUsedCard = 0;
        _maxZull = 6;
        _zullNeedCard = 13;
        _handSize = 3;
        _maxCheatSize = 3;
        _maxThrowCard = 20;
    }
}

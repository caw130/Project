using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStat : MonoBehaviour
{
    public static UserStat Instance { get; set; }
    int _totalGold;
    int _totalUsedCard;
    int _totalCompletedZull;

    public int TotalGold => _totalGold;
    public int TotalUsedCard => _totalUsedCard;
    public int TotalCompletedZull => _totalCompletedZull;

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

    public void ResetIndex()
    {
        _totalCompletedZull = 0;
        _totalGold = 0;
        _totalUsedCard = 0;
    }
}

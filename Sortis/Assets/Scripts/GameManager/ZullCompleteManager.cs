using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZullCompleteManager : MonoBehaviour
{
    [SerializeField] int _rewardGold;

    public void HandleZullCompletion(GameEventType type, object a)
    {
        if (type != GameEventType.ZullComplete) return;
        if (!(a is Zull completedzull)) return;
        Goldmanager.Instance.GetGold(_rewardGold);
        UserStat.Instance.AddTotlaCompleteZull();
        completedzull.ZullCardsRemove();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    [SerializeField] int _maxRound;
    [SerializeField] int _round;

    public int Round => _round;
    public int MaxRound => _maxRound;
    public void RoundStart()
    {
        _round++;
        GameEvent.Raise(GameEventType.RoundStarted);
    }

    public void ResetRound()
    {
        _round = 0;
    }
}

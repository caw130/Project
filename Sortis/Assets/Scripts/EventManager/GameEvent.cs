using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameEventType
{
    ZullComplete,
    CardDrag,
    CardDrop,
    FirstTypeCardDrop,
    OnCardDiscard,
    RoundEnded,
    RoundStarted,
    StartNewRound,
    GameOver,
    GameWin,
    UseItem,
    OpenStore,
    SellItem,
    HackInfo,
    CheatInfo,
    CheatInfoHide,
    CheatUseShow,
    CheatUseHide,
    Draw,
    Throw,
    RemoveHand,
    BuyItem,
    ShopRerool,
    RemoveLastThrow,
}

public struct GameActionInfo
{
    GameEventType _type;
    object _a;
    object _b;

    public GameEventType Type => _type;
    public object A => _a;
    public object B => _b;

    public GameActionInfo(GameEventType type, object sender, object data)
    {
        _type = type;
        _a = sender;
        _b = data;
    }
}
public static class GameEvent
{
    public static event Action<GameActionInfo> OnGameAction;
    public static void Raise(GameEventType type, object a = null, object b = null) => OnGameAction?.Invoke(new GameActionInfo(type, a, b));

    public static event Action GameRestart;
    public static void InvokeGameRestart() => GameRestart?.Invoke();

    public static event Action GoMain;
    public static void InvokeGoMain() => GoMain?.Invoke();
}

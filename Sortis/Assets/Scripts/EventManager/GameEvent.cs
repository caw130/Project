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
    HackInfoHide,
    CheatInfo,
    CheatInfoHide,
    CheatUseShow,
    CheatUseHide,
    HackUseShow,
    HackUseHide,
    Draw,
    Throw,
    RemoveHand,
    BuyItem,
    ShopRerool,
    RemoveLastThrow,
    RemoveRandomZull,
    ClearThrowDeck,
    HackRemove,
    HandReturn,
    ThrowCradShuffle,
    GetRandomItem,
    RemoveCard,
    GetThrowCard,
    ShuffleHand,
    ItemSell,
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
    //게임 Action이 실행되는 부분
    public static event Action<GameActionInfo> OnGameAction;
    /// <summary>
    /// OnGameAction을 실행 시키는 함수
    /// </summary>
    /// <param name="type">이벤트 타입</param>
    /// <param name="a">a 오브젝트</param>
    /// <param name="b">b 오브젝트</param>
    public static void Raise(GameEventType type, object a = null, object b = null) =>
        OnGameAction?.Invoke(new GameActionInfo(type, a, b));

    public static event Action GameRestart;
    public static void InvokeGameRestart() => GameRestart?.Invoke();

    public static event Action GoMain;
    public static void InvokeGoMain() => GoMain?.Invoke();
}

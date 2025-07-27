using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public enum GameState
{
    GamePlay,
    Shop,
    GameOver,
    GameClear,
}

public class ActionManager : MonoBehaviour
{
    
    GameState _gameState = GameState.GamePlay;
    [Header("컴포넌트 참조")]
    [SerializeField] CardMoveManager _cardManager;
    [SerializeField] DiscardManager _discardManager;
    [SerializeField] ZullCompleteManager _zullCompleteManager;
    [SerializeField] RoundManager _roundManager;
    [SerializeField] ShuffleManager _shuffle;
    [SerializeField] UiManager _uiManager;
    [SerializeField] DragManager _dragManager;
    [SerializeField] ThrowDeck _throwDeck;
    [SerializeField] Hand _hand;
    [SerializeField] ZullManager _zullManager;
    [SerializeField] Deck _deck;
    [SerializeField] ItemInventory _itemInventory;
    [SerializeField] Shop _shop;
    [SerializeField] HackPool _hackPool;
    [SerializeField] CheatPool _cheatPool;
    [SerializeField] DrawManager _drawManager;


    Queue<GameActionInfo> _eventQueue = new Queue<GameActionInfo>();
    bool _isProcessingQueue = false;
    int _eventDepth = 0;
    [SerializeField] int MAX_EVENT_DEPTH = 10;

    public void Enable()
    {
        GameEvent.OnGameAction += AddActionToQueue;
    }

    void ProcessAction(GameActionInfo info)
    {
        _eventDepth++;

        if (_eventDepth >= MAX_EVENT_DEPTH)
        {
            _eventDepth--;
            return;
        }

        OnAction(info.Type, info.A, info.B);

        _eventDepth--;
    }
    void ProcessQueue()
    {
        _isProcessingQueue = true;

        // 큐에 이벤트가 남아있는 동안 계속 처리합니다.
        while (_eventQueue.Count > 0)
        {
            if (_eventDepth >= MAX_EVENT_DEPTH)
            {
                _eventQueue.Clear();
                break;
            }
            GameActionInfo info = _eventQueue.Dequeue();
            ProcessAction(info);
        }

        _isProcessingQueue = false;
        _eventDepth = 0;

        _uiManager.SetText();
        CheckGameState();
    }
    private void AddActionToQueue(GameActionInfo info)
    {
        _eventQueue.Enqueue(info);

        // 만약 현재 큐를 처리하고 있지 않다면, 즉시 처리를 시작합니다.
        if (!_isProcessingQueue)
        {
            ProcessQueue();
        }
    }

    void OnAction(GameEventType type, object a, object b)
    {
        if (_gameState == GameState.GameClear || _gameState == GameState.GameOver) return;

        switch (type)
        {
            case GameEventType.CardDrag:
                _cardManager.GetAction(type, a, b);
                break;

            case GameEventType.CardDrop:
                _cardManager.GetAction(type, a, b);
                break;

            case GameEventType.FirstTypeCardDrop:
                break;

            case GameEventType.OnCardDiscard:
                _discardManager.CardDiscard(type, a, b);
                break;

            case GameEventType.RemoveLastThrow:
                _throwDeck.RemoveData(_throwDeck.ThrowCard-1);
                break;

            case GameEventType.Draw:
                break;
            case GameEventType.ZullComplete:
                _zullCompleteManager.HandleZullCompletion(type, a);
                
                break;

            case GameEventType.RoundStarted:
                break;

            case GameEventType.HackInfo:
                _uiManager.ShowHackInfo(type,a);
                break;

            case GameEventType.CheatInfo:
                _uiManager.ShowCheatInfo(type, a);
                break;  

            case GameEventType.CheatInfoHide:
                _uiManager.HIdeCheatInfo(type);
                break;

            case GameEventType.CheatUseShow:
                _uiManager.ShowCheatUse(type, a);
                break;

            case GameEventType.CheatUseHide:
                _uiManager.HideCheatUse(type);
                break;

            case GameEventType.RoundEnded:
                HandleRoundEnd();
                break;

            case GameEventType.StartNewRound:
                _roundManager.RoundStart();
                ChangeGameState(GameState.GamePlay);
                _uiManager.SetText();
                break;

            case GameEventType.OpenStore:
                
                break;

            case GameEventType.BuyItem:
                _uiManager.SetText();
                break;
            case GameEventType.ShopRerool:
                _uiManager.SetText();
                break;
            case GameEventType.UseItem:
                break;

            case GameEventType.GameOver:
                
                break;
            case GameEventType.GameWin:
                
                break;
            case GameEventType.RemoveHand:
                _hand.ClearHand();
                break;
        }
        _itemInventory.InvokeHack(type, a, b);
    }

    void CheckGameState()
    {
        if(_roundManager.Round > _roundManager.MaxRound)
        {
            ChangeGameState(GameState.GameClear);
            GameManager.Instance.SoundManager.PlayClip(SoundType.GameClear);
            return;
        }

        if (_throwDeck.ThrowCard > _throwDeck.MaxCard)
        {
            ChangeGameState(GameState.GameOver);
            GameManager.Instance.SoundManager.PlayClip(SoundType.GameOver);
            return;
        }
    }
    void ChangeGameState(GameState state)
    {
        if (_gameState == state) return;
        _gameState = state;

        switch (_gameState)
        {
            case GameState.GamePlay:
                _dragManager.enabled = true;
                GamePause(true);
                break;
            case GameState.Shop:
                GamePause(false);
                break;
            case GameState.GameOver:
                _dragManager.enabled = false;
                _uiManager.GameOverResult();
                break;

            case GameState.GameClear:
                _dragManager.enabled = false;
                _uiManager.GameClearResult();
                break;
        }
        
    }

    void GamePause(bool state)
    {
        _throwDeck.Clickable = state;
        _drawManager.Clickable = state;
        _cardManager.OnPause = !state;
    }
    void HandleRoundEnd()
    {
        _roundManager.AddRound();
        CheckGameState();
        if (_gameState == GameState.GameClear || _gameState == GameState.GameOver) return;
        _shuffle.ShuffleDeck();
        _uiManager.SetText();
        ChangeGameState(GameState.Shop);
        _shop.ShopOpen();
        GameEvent.Raise(GameEventType.OpenStore);
    }

    public void GameStart()
    {
        _uiManager.Initialize();
        _shop.Initialize();
    }
    public void RestartGame()
    {
        _hand.DestroyHand();
        UserStat.Instance.ResetIndex();
        Goldmanager.Instance.ResetGold();
        _roundManager.ResetRound();
        _zullManager.ResetZulls();
        _throwDeck.Clear();
        _uiManager.ResetUi();
        _hackPool.InitializePool();
        _itemInventory.ClearInventory();
        ChangeGameState(GameState.GamePlay);
        _deck.ClearDeck();
        _deck.MakeDeck();
        _deck.Shuffle();
        _uiManager.SetText();
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _goldText;
    [SerializeField] TextMeshProUGUI _RoundText;
    [SerializeField] RoundManager _roundManager;
    [SerializeField] Color _gameoverColor;
    [SerializeField] Color _gameClearColor;
    [SerializeField] Image _resultBackground;
    [SerializeField] ResultPanel _resultPanel;
    [SerializeField] ResultScreenUi _result;
    [SerializeField] ThrowDeck _throwDeck;
    [SerializeField] Deck _deck;
    [SerializeField] TextMeshProUGUI _throwCrads;
    [SerializeField] TextMeshProUGUI _remainDeck;
    [SerializeField] HackInfo _hackInfo;
    [SerializeField] CheatItemInfo _cheatInfo;
    [SerializeField] CheatUseUi _cheatUseUi;

    public void Initialize()
    {
        SetText();
        _resultPanel.Initialize();
    }

    public void SetText()
    {
        int gold = Goldmanager.Instance.Gold;
        _goldText.text = $"{gold}$";
        int Round = _roundManager.Round;
        int MaxRound = _roundManager.MaxRound;
        _RoundText.text = $"{Round}/{MaxRound}";
        _throwCrads.text = $"{_throwDeck.ThrowCard} / {_throwDeck.MaxCard}";
        _remainDeck.text = $"{_deck.Card}";
    }

    public void GameOverResult()
    {
        _resultBackground.gameObject.SetActive(true);
        _resultBackground.color = Color.clear;
        _resultBackground.DOColor(_gameoverColor,0.5f);
        _result.ShowGameOver(_roundManager.Round, _roundManager.MaxRound);
        _resultPanel.Show();

    }

    public void GameClearResult()
    {
        _resultBackground.gameObject.SetActive(true);
        _resultBackground.color = Color.clear;
        _resultBackground.DOColor(_gameClearColor, 0.5f);
        _result.ShowGameClear(_roundManager.Round, _roundManager.MaxRound);
        _resultPanel.Show();
    }

    public void ShowHackInfo(GameEventType type, object a)
    {
        if (type != GameEventType.HackInfo) return;
        if (!(a is HackItemPrefab hack)) return;

        _hackInfo.Show(hack, hack.transform.position);
    }

    public void ShowCheatInfo(GameEventType type, object a)
    {
        if(type != GameEventType.CheatInfo) return;
        if(!(a is CheatItemPrefab cheat)) return;
        _cheatInfo.Show(cheat, cheat.transform.position);
    }

    public void HIdeCheatInfo(GameEventType type)
    {
        if(type != GameEventType.CheatInfoHide) return;
        _cheatInfo.Hide();
    }

    public void ShowCheatUse(GameEventType type, object a)
    {
        if (type != GameEventType.CheatUseShow) return;
        if (!(a is CheatItemPrefab cheat)) return;
        _cheatUseUi.Show(cheat, cheat.transform.position);
    }
    public void HideCheatUse(GameEventType type)
    {
        if(type != GameEventType.CheatUseHide) return;
        _cheatUseUi.Hide();
    }

    public void HideUi()
    {
        _cheatInfo.Hide();
        _cheatUseUi.Hide();
        _hackInfo.Hide();
        _resultPanel.Hide();
    }

    public void ResetUi()
    {
        _resultBackground.DOColor(Color.clear, 0.5f).
            OnComplete(() =>
            {
                _resultBackground.gameObject.SetActive(false);
            });

        HideUi();
        SetText();
    }

}

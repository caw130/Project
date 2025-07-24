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
    //[SerializeField] GameObject _throwCards;

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
        Debug.Log("게임 오버");
        _resultBackground.gameObject.SetActive(true);
        _resultBackground.color = Color.clear;
        _resultBackground.DOColor(_gameoverColor,0.5f);
        _result.ShowGameOver(_roundManager.Round, _roundManager.MaxRound);
        _resultPanel.Show();

    }

    public void GameClearResult()
    {
        Debug.Log("게임 클리어");
        _resultBackground.gameObject.SetActive(true);
        _resultBackground.color = Color.clear;
        _resultBackground.DOColor(_gameClearColor, 0.5f);
        _result.ShowGameClear(_roundManager.Round, _roundManager.MaxRound);
        _resultPanel.Show();
    }
    public void OpenThrowCrads()
    {
        //TODO
    }

    public void ResetUi()
    {
        _resultBackground.DOColor(Color.clear, 0.5f);
        _resultPanel.Hide();
        _resultBackground.gameObject.SetActive(false);
        SetText();
    }
}

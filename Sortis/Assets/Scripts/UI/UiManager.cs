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
    [SerializeField] GameObject _resultPanel;
    [SerializeField] ResultScreenUi _result;
    [SerializeField] ThrowDeck _throwDeck;
    [SerializeField] Deck _deck;
    [SerializeField] TextMeshProUGUI _throwCrads;
    [SerializeField] TextMeshProUGUI _remainDeck;
    //[SerializeField] GameObject _throwCards;

    private void Start()
    {
        SetText();
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
        _resultBackground.color = _gameoverColor;
        _result.ShowGameOver(_roundManager.Round, _roundManager.MaxRound);
        _resultPanel.gameObject.SetActive(true);
        
    }

    public void GameClearResult()
    {
        Debug.Log("게임 클리어");
        _resultBackground.gameObject.SetActive(true);
        _resultBackground.color = _gameClearColor;
        _result.ShowGameClear(_roundManager.Round, _roundManager.MaxRound);
        _resultPanel.gameObject.SetActive(true);
    }
    public void OpenThrowCrads()
    {
        //TODO
    }

    public void ResetUi()
    {
        _resultBackground.gameObject.SetActive(false);
        _resultPanel.gameObject.SetActive(false);
        SetText();
    }
}

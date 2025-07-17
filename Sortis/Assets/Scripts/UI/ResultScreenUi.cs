using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScreenUi : MonoBehaviour
{
    [SerializeField] UserStat _stat;
    [SerializeField] TextMeshProUGUI _title;
    [SerializeField] TextMeshProUGUI _roundText;
    [SerializeField] TextMeshProUGUI _goldText;
    [SerializeField] TextMeshProUGUI _cardText;
    [SerializeField] TextMeshProUGUI _zullText;

    public void ShowGameOver(int currentRound, int maxRound)
    {
        _title.text = "GameOver";
        _roundText.text = $"{currentRound}/{maxRound}";
        _goldText.text = $"{UserStat.Instance.TotalGold}";
        _cardText.text = $"{UserStat.Instance.TotalUsedCard}";
        _zullText.text = $"{UserStat.Instance.TotalCompletedZull}";
    }

    public void ShowGameClear(int currentRound, int maxRound)
    {
        _title.text = "Game Clear";
        _roundText.text = $"{maxRound}/{maxRound}";
        _goldText.text = $"{UserStat.Instance.TotalGold}";
        _cardText.text = $"{UserStat.Instance.TotalUsedCard}";
        _zullText.text = $"{UserStat.Instance.TotalCompletedZull}";
    }

    public void restart()
    {
        GameEvent.InvokeGameRestart();
    }

    public void GoToMainMenu()
    {
        //SceneManager.LoadScene(0);
    }
}

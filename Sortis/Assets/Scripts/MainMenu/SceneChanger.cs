using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] float _changeSpeed;
    public void SceneChange(int num)
    {
        GameManager.Instance.SoundManager.PlayClip(SoundType.SceneChange);
        _image.DOFillAmount(1, _changeSpeed).OnComplete(() =>
        {
            SceneManager.LoadScene(num);
            _image.DOFillAmount(0, _changeSpeed);
            GameManager.Instance.SoundManager.PlayClip(SoundType.SceneChange);
        });
        
    }
    public Tween GetHide()
    {
        return _image.DOFillAmount(1, _changeSpeed);
    }

    public void Show()
    {
        _image.DOFillAmount(0, _changeSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] SounData[] _soundData;
    [SerializeField] AudioSource _effectSound;
    [SerializeField] AudioSource _bgm;
    Dictionary<SoundType, AudioClip> _sounds = new();

    
    public void Initailize()
    {
        MakeSoundArray();
        StartBgm();
    }
    void MakeSoundArray()
    {
        foreach(var sound in _soundData)
        {
            _sounds.Add(sound.Type,sound.Clip);
        }
    }
    public void PlayClip(AudioClip clip)
    {
        _effectSound.PlayOneShot(clip);
    }

    public void PlayClip(SoundType type)
    {
        _effectSound.PlayOneShot(_sounds[type]);
    }
    public void StartBgm()
    {
        if (!_sounds.ContainsKey(SoundType.BGM)) return;
        _bgm.clip = _sounds[SoundType.BGM];
        _bgm.Play();
        _bgm.loop = true;
    }
}

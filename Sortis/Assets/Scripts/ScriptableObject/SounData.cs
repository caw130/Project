using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    CardClick,
    
}

[CreateAssetMenu(menuName = "GameData/SoundData")]
public class SounData : ScriptableObject
{
    [SerializeField] SoundType _type;
    [SerializeField] AudioClip _clip;

    public SoundType Type => _type;
    public AudioClip Clip => _clip;
}

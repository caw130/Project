using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CheatData", menuName = "GameData/Cheat")]
public class CheatData : ItemData
{
    [SerializeField] int _charges;
    [SerializeField] CheatEffectBase _cheatPrefab;

    public int Charges => _charges;
    public CheatEffectBase CheatPrefab => _cheatPrefab;
}

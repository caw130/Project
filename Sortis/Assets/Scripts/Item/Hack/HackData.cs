using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemRarity
{
    Common,
    Rare,
    Epic,
}
public enum HackType
{
    Activity,
    Passive
}

[CreateAssetMenu(fileName = "HackData", menuName = "GameData/Hack")]
public class HackData : ItemData
{
    [SerializeField] int _itemNum;
    [SerializeField] ItemRarity _rarity;
    [SerializeField] HackType _type;
    [SerializeField] List<GameEventType> _trigger;
    [SerializeField] HackEffectBase _hackPrefab;
    [SerializeField] Vector3 _imageSize;

    public int ItemNum => _itemNum;
    public ItemRarity Rarity => _rarity;
    public HackType Type => _type;
    public List<GameEventType> Trigger => _trigger;
    public HackEffectBase HackPrefab => _hackPrefab;
    public Vector3 ImageSize => _imageSize;
}

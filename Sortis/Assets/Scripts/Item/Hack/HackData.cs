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
public class HackData : ScriptableObject
{
    [SerializeField] string _name;
    [TextArea][SerializeField] string _description;
    [SerializeField] Sprite _icon;
    [SerializeField] int _price;
    [SerializeField] ItemRarity _rarity;
    [SerializeField] HackType _type;
    [SerializeField] List<GameEventType> _trigger;
    [SerializeField] HackEffectBase _hackPrefab;

    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;
    public int Price => _price;
    public ItemRarity Rarity => _rarity;
    public HackType Type => _type;
    public List<GameEventType> Trigger => _trigger;
    public HackEffectBase HackPrefab => _hackPrefab;
}

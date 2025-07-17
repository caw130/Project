using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemData : ScriptableObject
{
    [SerializeField] string _name;
    [TextArea][SerializeField] string _description;
    [SerializeField] Sprite _icon;
    [SerializeField] int _price;

    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;
    public int Price => _price;
}

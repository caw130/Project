using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goldmanager : MonoBehaviour
{
    public static Goldmanager Instance { get; set; }
    [SerializeField] int _gold;
    public int Gold => _gold;
    private void Awake()
    {
        if (Instance != null) Destroy(gameObject); 
        Instance = this;
        
    }
    public void GetGold (int gold)
    {
        _gold += gold;
        UserStat.Instance.AddGold(gold);
    }

    public bool SpentGold(int gold)
    {
        if (_gold < gold) return false;
        _gold -= gold;
        return true;
    }

    public void ResetGold()
    {
        _gold = 0;
    }
}

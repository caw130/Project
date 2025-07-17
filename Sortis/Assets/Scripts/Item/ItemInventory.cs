using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemInventory : MonoBehaviour
{
    [SerializeField] int _maxHack;
    [SerializeField] int _maxCheat;
    [SerializeField] List<HackEffectBase> _hacks = new List<HackEffectBase>();
    
    public void GetItem(HackData data)
    {
        HackEffectBase hack = Instantiate(data.HackPrefab);
        hack.Initialize(data);
        _hacks.Add(hack);
    }
    public void InvokeHack(GameEventType type, object a = null, object b = null)
    {
        
        foreach (var hack in _hacks)
        {
            if (hack is HackEventType eventhack)
            {
                // 맞다면, 그 아이템의 이벤트 처리 함수를 호출
                eventhack.OnGameEvent(type,a,b); // 예시 함수
            }
        }
    }
}

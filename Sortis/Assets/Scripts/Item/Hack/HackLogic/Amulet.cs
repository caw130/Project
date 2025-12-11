using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amulet : HackEventType
{
    //이벤트를 받아오는 부분
    public override void OnGameEvent(GameEventType type, object a, object b)
    {
        //아이템 트리거에 해당 타입이 있는지 비교
        if (_data.Trigger.Contains(type))
        {
            //이벤트 실행
            GameEvent.Raise(GameEventType.GetRandomItem);
            //이벤트 실행 모션을 보여주기 위해 오브젝트에 신호를 보내는 부분
            InvokeOnUsed();
        }
    }
}

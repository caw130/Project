using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : HackStatType
{
    public override void Equip()
    {
        Debug.Log("����");
    }

    public override void Unequip()
    {
        Debug.Log("������");
    }
}

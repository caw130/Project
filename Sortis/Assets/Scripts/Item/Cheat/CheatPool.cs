using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatPool : MonoBehaviour
{
    [SerializeField] List<CheatData> _datas;

    public List<CheatData> GiveCheat(int count)
    {
        List<CheatData> shopItems = new List<CheatData>();
        for(int i= 0;i<count; i++)
        {
            int randomindex = Random.Range(0, _datas.Count);
            shopItems.Add(_datas[randomindex]);
        }
        return shopItems;
    }
    public CheatData GiveCheat()
    {
        int randomindex = Random.Range(0, _datas.Count);
        return _datas[randomindex];
    }
}

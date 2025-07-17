using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataManager : MonoBehaviour
{
    [SerializeField] List<CardData> _CardDatas;

    public List<CardData> Data => _CardDatas;
}

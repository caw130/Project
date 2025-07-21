using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HackPool : MonoBehaviour
{
    [SerializeField] List<HackData> _datas;
    [SerializeField] List<HackData> _availableItems = new();

    public void InitializePool()
    {
        _availableItems.Clear();
        _availableItems.AddRange(_datas);
    }
    public List<HackData> GiveHack(int count)
    {
        List<HackData> tempAvailableItems = new List<HackData>(_availableItems);

        List<HackData> shopItems = new List<HackData>();

        for (int i = 0; i < count && tempAvailableItems.Count > 0; i++)
        {
            int randomIndex = Random.Range(0, tempAvailableItems.Count);
            HackData chosenItem = tempAvailableItems[randomIndex];

            shopItems.Add(chosenItem);

            tempAvailableItems.RemoveAt(randomIndex);
        }
        return shopItems;
    }

    public void ItemRemove(HackData purchasedItem)
    {
        if (_availableItems.Contains(purchasedItem))
        {
            _availableItems.Remove(purchasedItem);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZullManager : MonoBehaviour
{
    [SerializeField] List<Zull> _zulls = new List<Zull>();
    [SerializeField] List<Zull> _canPlacezulls = new List<Zull>();
    [SerializeField] float _placeDistance;
    [SerializeField] float _maxXdistance;
    [SerializeField] float _maxYdistance;

    private void Start()
    {
        SetZulls();
    }

    public void SetZulls()
    {
        foreach (var zull in _zulls)
        {
            zull.SetDistance(_placeDistance);
        }
    }
    public void FindPlaceZulls(Card card)
    {
        _canPlacezulls.Clear();
        foreach (var zull in _zulls)
        {
            if (zull.CheckCanPlace(card))
            {
                _canPlacezulls.Add(zull);
            }
        }
    }

    public ICardStacker HandleCardDrop(Vector2 pos)
    {
        ICardStacker bestZull = null;
        float closestDistance = float.MaxValue;
        foreach(var zull in _canPlacezulls)
        {
            float distance = Vector2.Distance(zull.InteractPoint, pos);
            if(distance < _placeDistance)
            {
                if (distance < closestDistance)
                {
                    bestZull = zull;
                    closestDistance = distance;
                }
            }
        }
        _canPlacezulls.Clear();
        return bestZull;
    }

    public void ResetZulls()
    {
        foreach (var zull in _zulls)
        {
            zull.ClearZull();
        }
    }
}

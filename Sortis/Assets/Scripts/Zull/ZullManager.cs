using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ZullManager : MonoBehaviour
{
    [SerializeField] Zull _zullPrefab;
    [SerializeField] List<Zull> _zulls = new List<Zull>();
    [SerializeField] List<Zull> _canPlacezulls = new List<Zull>();
    [SerializeField] int _haveZull;
    [SerializeField] float _placeDistance;
    [SerializeField] float _xdistance;
    [SerializeField] float _ydistance;

    private void Start()
    {
        SetZulls();
    }

    public void SetZulls()
    {
        for(int i = 0; i < _haveZull; i++)
        {
            _zulls.Add(Instantiate(_zullPrefab, transform));
        }
        SetZullPosition();
        foreach (var zull in _zulls)
        {
            zull.SetDistance(_placeDistance);
        }
    }

    public void SetZullPosition()
    {
        float startx = -_xdistance;
        float totalx = _xdistance * 2;
        float xpos = totalx / (_zulls.Count +1);
        for (int i = 0; i < _zulls.Count; i++)
        {
            Vector2 pos;
            pos.y = 0;
            pos.x = startx + xpos*(i+1);
            Debug.Log(pos.x);
            _zulls[i].transform.localPosition = pos;
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

    private void OnDrawGizmosSelected()
    {
        Vector2 line = new Vector2(_xdistance*2, _ydistance*2);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, line);
    }
}

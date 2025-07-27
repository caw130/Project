using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] Material _background;
    [SerializeField] float _index = 0;
    private void Update()
    {
        Vector2 Index = new Vector2(_index, _index);
        _index += _moveSpeed*Time.deltaTime;
        if (_index >= 100) _index -= 100;
        _background.SetTextureOffset("_MainTex", Index);
    }
}

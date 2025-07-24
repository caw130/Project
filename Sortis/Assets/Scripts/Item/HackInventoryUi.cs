using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackInventoryUi : MonoBehaviour
{
    [SerializeField] float _xSize;
    [SerializeField] float _ySize;

    private void OnDrawGizmosSelected()
    {
        Vector2 line = new Vector2(_xSize, _ySize);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, line);
    }
}

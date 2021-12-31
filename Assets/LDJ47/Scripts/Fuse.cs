using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : MonoBehaviour
{

    public TurnOnCircuitTask TurnOnCircuitTaskObj;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("tentando rodar");
            TurnOnCircuitTaskObj.RotateFuse(this.gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConnectorControl : MonoBehaviour
{

    public UnityEvent WrongCable;
    public UnityEvent RightCable;
    
    [SerializeField]
    private GameObject _pair;

    private Vector3 defaultPosition;

    private bool MouseIsOver;
    
    void Awake()
    {
        defaultPosition = this.transform.position;
    }
    
    void Update()
    {
        if (MouseIsOver)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    transform.position=new Vector3(hit.point.x,hit.point.y,defaultPosition.z);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                MouseIsOver = false;
                transform.position=defaultPosition;
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            MouseIsOver = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject == _pair)
        {
            SoundManager.SINGLETON.PlaySuccessClip();
            transform.position=_pair.transform.position;
            RightCable.Invoke();
            this.enabled = false;
        }
        else
        {
            SoundManager.SINGLETON.PlayDefeatClip();
            WrongCable.Invoke();
        }
    }

    public void ResetCable()
    {
        MouseIsOver = false;
        transform.position=defaultPosition;
    }
}

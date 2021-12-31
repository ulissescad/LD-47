using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpinnerControl : MonoBehaviour
{
    public UnityEvent RightPair;

    [SerializeField]
    private GameObject _pair;

    [SerializeField]
    private SpinnerTask _spinnerTask;

    private bool MouseIsOver;
    private bool canClick=false;

    void Awake()
    {
        GetComponent<Animator>().speed = Random.Range(0.5f, 2.5f);
    }


    void OnMouseOver()
    {
        if (Input.GetMouseButton(0)
            && canClick == true)
        {
            SoundManager.SINGLETON.PlaySuccessClip();
            _spinnerTask.CheckForCompletion(this);
            GetComponent<Animator>().SetTrigger("action");
            this.enabled = false;
        }
    }
    
    void OnCollisionExit()
    {
        canClick = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject == _pair)
            {
                canClick = true;
            }
    }
}

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class PassWorButtonController : MonoBehaviour
{
    [SerializeField]
    private PassWordPanelTask _passWordPanelTask;
    
    [SerializeField]
    private float _punchValue;
    
    [SerializeField]
    private int _indexToChange;
    
    private UnityEvent ButtonPressed;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (GetComponent<Animator>())
            {
                GetComponent<Animator>().SetTrigger("action");
            }
            else
            {
                transform.DOPunchPosition(new Vector3(0, 0, _punchValue), 0.1f);
            }
            SoundManager.SINGLETON.PlaySuccessClip();
            _passWordPanelTask._status[_indexToChange] = true;
            _passWordPanelTask.CheckStatus();

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class KeypadButtonController : MonoBehaviour
{
    [SerializeField]
    private float _punchValue;

    [SerializeField]
    private KeypadController _keypadController;

        // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
                _keypadController.CheckButton(this.gameObject);
            }

        }
    }
}

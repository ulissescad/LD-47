using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{

    private Button _closeButton;

    // Start is called before the first frame update
    void Start()
    {
        _closeButton.onClick.AddListener(()=> Application.Quit());
    }
}

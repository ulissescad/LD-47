using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GaujeControll : MonoBehaviour
{
    [SerializeField]
    private Transform _pointer;

    [SerializeField]
    private float _startValue;
    
    [SerializeField]
    private float _timeToPass;

    [SerializeField]
    private float[] _eventValues = new float[0];

    public UnityEvent _endGameEvent;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimePass());
    }

    IEnumerator TimePass()
    {
        var value =((180/10) * _startValue)-90;

        var pass = 180 / 10;

        while (true)
        {
            CheckValues(value);
            
            _pointer.transform.rotation= Quaternion.Euler(0,0,-value);
            value += pass;
            
            yield return new WaitForSeconds(_timeToPass);
        }
    }

    private void CheckValues(float value)
    {
        foreach (var eventValue in _eventValues)
        {
            if (value==eventValue)
            {
                _endGameEvent.Invoke();
                
                StartCoroutine(WaitForComplete());
        
                IEnumerator WaitForComplete()
                {
                    SoundManager.SINGLETON.PlayBoomkAudio();
                    yield return new WaitForSeconds(2);
                    SceneManager.LoadScene("level1");
                }
            }
        }
    }
}

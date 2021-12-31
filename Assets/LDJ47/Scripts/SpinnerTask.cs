using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SpinnerTask : BaseTask
{
    
    [SerializeField]
    private bool [] _spinnersCheck = new bool[0];
    
    [SerializeField]
    private List<SpinnerControl> _spinners = new List<SpinnerControl>();
    
    void Start()
    {
        for (int i = 0; i < _spinnersCheck.Length; i++)
        {
            _spinnersCheck[i] = false;
        }

        StartCoroutine(CheckArray());
    }

    public override void StartTask()
    {
      
    }
    public void CheckForCompletion(SpinnerControl spinner)
    {
        _spinnersCheck[_spinners.IndexOf(spinner)] = true;
    }

    IEnumerator CheckArray()
    {
        
        while (true)
        {
            int amount = 0;
            for (int i = 0; i < _spinnersCheck.Length; i++)
            {
                if (_spinnersCheck[i] == true)
                {
                    amount++;
                }
            }

            if (amount==_spinnersCheck.Length)
            {
                FinishTask();
            }
            
            yield return new WaitForSeconds(0.5f);
        }
    }

    void FinishTask()
    {
        StartCoroutine(Finish());
        
        IEnumerator Finish()
        {
            yield return new WaitForSeconds(2);
            base.TaskCompleted.Invoke();
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

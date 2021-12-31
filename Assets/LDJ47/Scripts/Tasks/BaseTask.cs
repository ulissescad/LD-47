using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseTask : MonoBehaviour
{
    public UnityEvent TaskCompleted;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void StartTask()
    {
        Debug.Log("a task começou");
    }

}

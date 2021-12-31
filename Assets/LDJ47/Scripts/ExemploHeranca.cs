using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExemploHeranca : BaseTask
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void StartTask()
    {
        // Debug.Log("exemplo dentro do Override");
        //
        // StartCoroutine(Teste());
        //
        // IEnumerator Teste()
        // {
        //     yield return new WaitForSeconds(5);
        //     Debug.Log("taskCompleted");
        //     base.TaskCompleted.Invoke();
        // }
    }
}

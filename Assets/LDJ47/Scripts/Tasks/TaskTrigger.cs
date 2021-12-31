using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTrigger : MonoBehaviour
{

    [SerializeField]
    private BaseTask _task;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        var taskManager = GameObject.Find("TaskManager");
        
        taskManager.GetComponent<TaskManager>().PlayTask(_task);
        this.gameObject.SetActive(false);
    }
}

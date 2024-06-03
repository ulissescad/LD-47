using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation.Samples;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{

    public GameManager GameManagerObj;
    public GameObject CameraObj;
    public ClickToMove ClicktoMove;
    
    [SerializeField]
    private Image _taskScreen;
    
    [SerializeField]
    private Transform _taskLocal;

    private BaseTask taskReference;


    public void PlayTask(BaseTask task)
    {
        ClicktoMove.CanMove= false;

        var taskObj = Instantiate(task, _taskLocal);
        
        CameraObj.SetActive(false);
        taskObj.TaskCompleted.AddListener(EndTask);
        taskObj.TaskCompleted.AddListener(GameManagerObj.UnlockHint);
        taskObj.StartTask();
    }

    private void EndTask()
    {
        ClicktoMove.CanMove = true;
        CameraObj.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableCircuitTask : BaseTask
{
    [SerializeField]
    private GameObject[] _cableIn;

    public int cableValue=0;
    
    void Awake()
    {
        foreach (var cable in _cableIn)
        {
            cable.GetComponent<ConnectorControl>().WrongCable.AddListener(ResetCable);
            cable.GetComponent<ConnectorControl>().RightCable.AddListener(IncreaseCableValue);
        }
    }

    public override void StartTask()
    {
        ResetCable();
    }

    void FinishTask()
    {
        StartCoroutine(Finish());
        
        IEnumerator Finish()
        {
            SoundManager.SINGLETON.PlaySuccessClip();
            yield return new WaitForSeconds(2);
            base.TaskCompleted.Invoke();
            Destroy(this.gameObject);
        }
    }

    void ResetCable()
    {
        cableValue = 0;
        
        foreach (var cable in _cableIn)
        {
            cable.GetComponent<ConnectorControl>().ResetCable();
            cable.GetComponent<ConnectorControl>().enabled = true;
        }
    }

    void IncreaseCableValue()
    {
        Debug.Log("dentro do cabo");
        
        cableValue++;
        
        if (cableValue == _cableIn.Length)
        {
            cableValue = 0;
            FinishTask();
        }
    }
}

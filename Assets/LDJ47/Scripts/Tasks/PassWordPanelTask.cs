using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWordPanelTask : BaseTask
{
    [SerializeField]
    public bool [] _status = new bool[0];

    void Start()
    {
        for (int i = 0; i < _status.Length; i++)
        {
            _status[i] = false;
        }
    }

    public void CheckStatus()
    {
        int index = 0;
        for (int i = 0; i < _status.Length; i++)
        {
            if (_status[i] == true)
            {
                SoundManager.SINGLETON.PlaySuccessClip();
                
                index++;
            }
        }

        if (index == _status.Length)
        {
            StartCoroutine(Finish());
        
            IEnumerator Finish()
            {
                yield return new WaitForSeconds(2);
                base.TaskCompleted.Invoke();
                Destroy(this.gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TurnOnCircuitTask : BaseTask
{

    [SerializeField]
    private GameObject[] _fuses;

    private int _index = 0;

    public override void StartTask()
    {
        ResetCables();
    }

    public void RotateFuse(GameObject fuse)
    {

        if (fuse == _fuses[_index])
        {
            fuse.transform.DOLocalRotate(new Vector3(0, 0, 0), 1);
            _index++;
            
            if (_index == _fuses.Length)
            {
                StartCoroutine(Finish());
        
                SoundManager.SINGLETON.PlaySuccessClip();
                
                IEnumerator Finish()
                {
                    yield return new WaitForSeconds(2);
                    base.TaskCompleted.Invoke();
                    Destroy(this.gameObject);
                }
            }
        }
        else
        {
            SoundManager.SINGLETON.PlayDefeatClip();
            ResetCables();
        }

        
    }

    private void ResetCables()
    {

        
        foreach (var fuseItem in _fuses)
        {
            fuseItem.transform.DOLocalRotate(new Vector3(0, Random.Range(0, 360), 0), 1);
        }

        _index = 0;
    }
}

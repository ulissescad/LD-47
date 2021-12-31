using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    private UIController _uiController;

    [SerializeField]
    private GaujeControll _gaujeControll;

    [SerializeField]
    private TaskManager _taskManager;
    
    [SerializeField]
    private GameObject[] _tasksToUnlock = new GameObject[0];
    
    [SerializeField]
    private GameObject[] _hintsToUnlock = new GameObject[0];

    public int indexTask=0;
    
    public int indexHint=0;

    // Start is called before the first frame update
    void Start()
    {
        _gaujeControll._endGameEvent.AddListener(_uiController.EndGame);
        _uiController.UnlockTask.AddListener(UnlockTask);
        _taskManager.GameManagerObj = this;
        _hintsToUnlock[0].SetActive(true);
    }

    public void UnlockTask()
    {
        if (indexTask < _tasksToUnlock.Length)
        {
            _tasksToUnlock[indexTask].SetActive(true);
            indexTask++;
        }
        else
        {
            EndGame();
        }

    }
    
    public void UnlockHint()
    {
        Debug.Log("dentro do hint");
        
        if (indexHint < _hintsToUnlock.Length)
        {
            _hintsToUnlock[indexHint].SetActive(false);
        }

        indexHint++;
        
        if (indexHint == _hintsToUnlock.Length)
        {
            EndGame();
        }
        
        if (indexHint < _hintsToUnlock.Length)
        {
            _hintsToUnlock[indexHint].SetActive(true);
            
        }


    }

    private void EndGame()
    {
        _uiController.EndGame();

        StartCoroutine(WaitForComplete());
        
        IEnumerator WaitForComplete()
        {
            SoundManager.SINGLETON.PlayBoomkAudio();
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        
        
    }


}

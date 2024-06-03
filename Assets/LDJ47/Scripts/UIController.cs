using DG.Tweening;
using JetBrains.Annotations;
using System;
using TMPro;
using Unity.AI.Navigation.Samples;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public UnityEvent UnlockTask;
    [SerializeField]
    private Image _endGameScreen;
    
    [SerializeField]
    private Animator _popupAnimMessage;

    [SerializeField]
    private TMP_Text _popupTextMessage;
    
    [SerializeField]
    private Animator _popupAnimHintMessage;

    [SerializeField]
    private TMP_Text _popupTextHintMessage;

    [SerializeField]
    private Button _hintButton;

    [SerializeField]
    private Button _closeHintButton;

    [SerializeField]
    private Animator _hintButtonpAnim; 
    
    [SerializeField]
    private ClickToMove _clickToMove;

    // Start is called before the first frame update
    void Start()
    {
        _hintButton.onClick.AddListener(ShowMessageHint);
        _closeHintButton.onClick.AddListener(HideMessageHint);
        _endGameScreen.gameObject.SetActive(true);
        _endGameScreen.DOFade(0, 1f);
    }

    private void HideMessageHint()
    {
        _clickToMove.CanMove=true;
        Debug.Log("hintpopup fechado");
    }

    public void ShowMessage(string message)
    {
        _popupTextMessage.text = message;
        _popupAnimMessage.SetTrigger("action");
    }
    
    private void ShowMessageHint()
    {
        Debug.Log("hintpopup aberto");
        _hintButtonpAnim.SetBool("action",false);
        _popupAnimHintMessage.SetTrigger("action");
        _clickToMove.CanMove = false;
        UnlockTask.Invoke();
    }

    public void ShowHint(bool status, [CanBeNull] string message)
    {
        if (message != null)
        {
            _popupTextHintMessage.text = message;
        }
        _hintButtonpAnim.SetBool("action",status);

    }
    
    public async void EndGame()
    { 
        await _endGameScreen.DOFade(1, 2f).AsyncWaitForCompletion();
    }
    
    public void StartGame()
    {
        _endGameScreen.DOFade(0, 1f);
    }
}

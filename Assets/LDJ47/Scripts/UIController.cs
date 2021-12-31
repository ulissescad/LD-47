using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
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
    private Animator _hintButtonpAnim;

    // Start is called before the first frame update
    void Start()
    {
        _hintButton.onClick.AddListener(ShowMessageHint);
        _endGameScreen.gameObject.SetActive(true);
        _endGameScreen.DOFade(0, 1f);
    }

    public void ShowMessage(string message)
    {
        _popupTextMessage.text = message;
        _popupAnimMessage.SetTrigger("action");
    }
    
    private void ShowMessageHint()
    {
        _hintButtonpAnim.SetBool("action",false);
        _popupAnimHintMessage.SetTrigger("action");
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

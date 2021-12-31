using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class KeypadController : MonoBehaviour
{
    [SerializeField]
    private PassWordPanelTask _passWordPanelTask;
    
    [SerializeField]
    List<GameObject> _buttons = new List<GameObject>();

    [SerializeField]
    private TMP_Text _displayText;

    [SerializeField]
    private List<int>  _sequence= new List<int>();
    
    [SerializeField]
    private int _buttonClearIndex;
    
    [SerializeField]
    private int _buttonCheckIndex;

    private List<int> _typedSequence= new List<int>();

    private int indexButton = 0;
    
    public void CheckButton(GameObject button)
    {
        if (_buttons.IndexOf(button) == _buttonClearIndex)
        {
            Clear("CLEAR");
            return;
        }
        
        if (_buttons.IndexOf(button) == _buttonCheckIndex)
        {
            CheckValues();
            return;
        }

        if (indexButton == 8)
        {
            CheckValues();
            return;
        }
        
        _typedSequence.Add(_buttons.IndexOf(button));
        
        _displayText.text += ""+(_buttons.IndexOf(button)); 
        indexButton++;

    }

    async void CheckValues()
    {
        int index = 0;
        foreach (var VARIABLE in _typedSequence)
        {
            if (VARIABLE == _sequence[index])
            {
                index++;
            }
            else
            {
                await Clear("ERROR");

                return;
            }
        }
        
        SoundManager.SINGLETON.PlaySuccessClip();
        _displayText.text = "RELEASED";
        _passWordPanelTask._status[0] = true;
        _passWordPanelTask.CheckStatus();
                
        await _displayText.DOFade(0, 0.25f).AsyncWaitForCompletion();
        await _displayText.DOFade(1, 0.25f).AsyncWaitForCompletion();
        await _displayText.DOFade(0, 0.25f).AsyncWaitForCompletion();
        await _displayText.DOFade(1, 0.25f).AsyncWaitForCompletion();
        
    }

    private async Task Clear(string text)
    {
        indexButton = 0;
        _typedSequence = new List<int>();
        _displayText.text = text;

        await _displayText.DOFade(0, 0.25f).AsyncWaitForCompletion();
        await _displayText.DOFade(1, 0.25f).AsyncWaitForCompletion();
        await _displayText.DOFade(0, 0.25f).AsyncWaitForCompletion();
        await _displayText.DOFade(1, 0.25f).AsyncWaitForCompletion();

        _displayText.text = null;
    }
}

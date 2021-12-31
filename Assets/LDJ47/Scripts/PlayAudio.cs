﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlayAudioFeedback);
    }

    private void PlayAudioFeedback()
    {
        SoundManager.SINGLETON.PlayFeedbackAudio();
    }
    
}

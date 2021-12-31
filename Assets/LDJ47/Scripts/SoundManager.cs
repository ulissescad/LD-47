using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    
    public static SoundManager SINGLETON;
    
    [SerializeField]
    private AudioClip [] _bgMusic = new AudioClip[0];

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip _successClip;

    [SerializeField]
    private AudioClip _defeatClip;

    [SerializeField]
    private AudioClip _feedbackClip;

    [SerializeField]
    private AudioClip _explosionClip;

    void Start()
    {
        SINGLETON = this;
        _audioSource = GetComponent<AudioSource>();
        System.Random rdn =new System.Random();
        _audioSource.clip = _bgMusic[rdn.Next(0,_bgMusic.Length-1)];
        _audioSource.Play();
    }
    
    public void PlayAudioClip(AudioClip audio)
    {
        _audioSource.PlayOneShot(audio);
        
    }
    
    public void PlaySuccessClip()
    {
        _audioSource.PlayOneShot(_successClip);
        
    }
    
    public void PlayDefeatClip()
    {
        _audioSource.PlayOneShot(_defeatClip);
        
    }

    public void PlayFeedbackAudio()
    {
        _audioSource.PlayOneShot(_feedbackClip);
    }
    
        public void PlayBoomkAudio()
        {
            _audioSource.PlayOneShot(_explosionClip);
        }
}

using System;
using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        GameManager.Instance.OnCoinsChanged += PlayCoinAudio;
    }

    void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= PlayCoinAudio;
    }
    void PlayCoinAudio(int obj)
    {
        audioSource.Play();
    }
}

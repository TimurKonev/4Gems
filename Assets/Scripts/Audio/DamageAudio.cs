using UnityEngine;

public class DamageAudio : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();    
    }
    void Start()
    {
        GameManager.Instance.OnLivesChanged += PlayDamageAudio;     
    }

    private void PlayDamageAudio(int Lives)
    {
        audioSource.Play();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLivesChanged -= PlayDamageAudio;
    }
}

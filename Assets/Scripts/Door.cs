using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] Sprite _openMid;
    [SerializeField] Sprite _openTop;
    [SerializeField] SpriteRenderer _rendererMid;
    [SerializeField] SpriteRenderer _rendererTop;

    bool _open;

    public void Open()
    {
        _open = true;
        _rendererMid.sprite = _openMid;
        _rendererTop.sprite = _openTop;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_open == false)
            return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

    }
}

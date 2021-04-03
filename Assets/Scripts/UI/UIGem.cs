using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGem : MonoBehaviour
{
    [SerializeField] Sprite _disabled;
    [SerializeField] Sprite _enabled;

    bool _gemCollected;

    void Awake()
    {
        var _image = GetComponent<Sprite>();
        _image = _disabled;
    }

   
    void Update()
    {
        if (_gemCollected == false)
            return;
        _disabled = _enabled;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    TextMeshProUGUI tmproText;

    void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        GameManager.Instance.OnCoinsChanged += HandleOnCoinsChanged;   
    }

    private void HandleOnCoinsChanged(int _coins)
    {
        tmproText.text = _coins.ToString();
    }

    void Update()
    {
        
    }
}

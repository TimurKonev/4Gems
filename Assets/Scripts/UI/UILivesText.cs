using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    TextMeshProUGUI tmproText;

    void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnLivesChanged += HandleOnLivesChanged;

    }

    private void HandleOnLivesChanged(int livesRemaining)
    {
        tmproText.text = livesRemaining.ToString();
    }
}

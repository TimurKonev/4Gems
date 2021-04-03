using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoinImage : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.Instance.OnCoinsChanged += Pulse;    
    }

    private void Pulse(int _coins)
    {
        animator.SetTrigger("Pulse");
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= Pulse;
    }
}

    

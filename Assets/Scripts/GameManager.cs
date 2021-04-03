using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Lives { get; private set; }

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;

    int _coins;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            RestartGame();
        }
        
    }

    internal void KillPlayer()
    {
        Lives--;

        if(OnLivesChanged != null)
           OnLivesChanged(Lives);

        if (Lives <= 0)
            RestartGame();
        else
            SendPlayerToCheckPoint();
    }

     void SendPlayerToCheckPoint()
    {
        var checkPointManager = FindObjectOfType<CheckPointManager>();

        var checkpoint = checkPointManager.GetLastCheckPointPassed();

        var player = FindObjectOfType<PlayerMovementController>();

        player.transform.position = checkpoint.transform.position;
    }

    internal void AddCoin()
    {
        _coins++;

        if (OnCoinsChanged != null)
            OnCoinsChanged(_coins);
    }

    public  void RestartGame()
    {
        Lives = 3;
        _coins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

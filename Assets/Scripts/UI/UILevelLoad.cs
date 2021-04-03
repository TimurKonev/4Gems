using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelLoad : MonoBehaviour
{
    [SerializeField] int levelIndex;

   

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneBuildIndex: levelIndex);
    }
}

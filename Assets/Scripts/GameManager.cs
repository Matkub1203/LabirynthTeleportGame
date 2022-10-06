using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;
    bool gamePaused = false;

    void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }

        InvokeRepeating("Stopper", 2, 1);
    }

    void Update()
    {
        
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd} s");
        if (timeToEnd <= 0)
        {
            timeToEnd = 100;
        }
    }

    void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }

    void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }
}

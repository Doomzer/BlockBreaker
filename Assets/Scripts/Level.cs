using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]int breakableBlocks;

    SceneLoader sceneLoader;
    GameStatus gameStatus;
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void addBreakableBlock()
    {
        breakableBlocks++;
    }

    public void removeBreakableBlock()
    {
        breakableBlocks--;
        gameStatus.AddToScore();
        if (breakableBlocks == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}


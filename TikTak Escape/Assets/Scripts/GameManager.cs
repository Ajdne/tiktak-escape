using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int level = 1;
    public int numberOfMoves = 10;

    private void Awake()
    {
        Instance = this;
    }

    public void LevelPassed()
    {

    }

    public void LevelFailed()
    {

    }

    public bool HasMoves()
    {
        if(numberOfMoves <= 0)
        {
            return false;
        }
        return true;
    }
}

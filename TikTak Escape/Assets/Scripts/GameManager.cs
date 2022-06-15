using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int level;
    public int numberOfCandies;

    private void Awake()
    {
        Instance = this;
        level ++;
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene("LVL" + (level + 1).ToString());
    }

    public void LevelFailed()
    {

    }

}

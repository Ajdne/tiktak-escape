using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int level;
    public int numberOfCandies;
    public int numberOfBasicCandies;
    public int numberOfBouncyCandies;
    public int numberOfStickyCandies;
    public GameObject BouncyCandy;
    public GameObject StickyCandy;

    private void Awake()
    {
        Instance = this;
        level ++;
        
        //CheckLevel();
        //LevelSetup();
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene("LVL" + (level + 1).ToString());
    }

    public void SpawnCapsule(GameObject capsule)
    {
        float randomX = Random.Range(-4f, 4.5f);
        float randomY = Random.Range(1f, 5);

        float randomRotX = Random.Range(0, 180);
        float randomRotY = Random.Range(0, 180);
        float randomRotZ = Random.Range(0, 180);

        Instantiate(capsule, new Vector3(randomX, randomY, 0), Quaternion.Euler(randomRotX, randomRotY, randomRotZ));
    }

}

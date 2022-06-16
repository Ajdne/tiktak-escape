using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int level;
    public static int numberOfCandies;
    public static int numberOfBasicCandies;
    public GameObject BouncyCandy;

    private void Awake()
    {
        Instance = this;
        level ++;
        
        LevelSetup();
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene("LVL" + (level + 1).ToString());
    }

    // nesto ovde ne valja
    public void LevelSetup() 
    {
        // IYBACITI SWITCH
       switch(level)
       {
        case 1:
            numberOfBasicCandies += 3;
            numberOfCandies = numberOfBasicCandies;
            break;
        case 2: 
            numberOfBasicCandies += 2;
            numberOfCandies = numberOfBasicCandies;
            break;
        case 3:
            numberOfCandies = numberOfBasicCandies + 1;
            Debug.Log(numberOfCandies);
            SpawnCapsule(BouncyCandy);
            break;
        default:
            break;

       }
    }


    public void SpawnCapsule(GameObject capsule)
    {
        float randomX = Random.Range(-4, 4);
        float randomY = Random.Range(0.5f, 5);

        float randomRotX = Random.Range(0, 180);
        float randomRotY = Random.Range(0, 180);
        float randomRotZ = Random.Range(0, 180);

        Instantiate(capsule, new Vector3(randomX, randomY, 0), Quaternion.Euler(randomRotX, randomRotY, randomRotZ));
    }
}

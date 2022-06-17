using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCandyScript : MonoBehaviour
{

    public GameObject Candy;

    void Start() {

        for (int i = 0; i < GameManager.Instance.numberOfBasicCandies; i++)
        {            
            GameManager.Instance.SpawnCapsule(Candy);
        }

        for (int i = 0; i < GameManager.Instance.numberOfBouncyCandies; i++)
        {
            GameManager.Instance.SpawnCapsule(GameManager.Instance.BouncyCandy);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCandyScript : MonoBehaviour
{

    public GameObject Candy;
    public int m_numberOfCandies;

    void Start() {

        for (int i = 0; i < m_numberOfCandies; i++) {

            float randomX = Random.Range(-4, 4);
            float randomY = Random.Range(0.5f, 9);

            float randomRotX = Random.Range(0, 180);
            float randomRotY = Random.Range(0, 180);
            float randomRotZ = Random.Range(0, 180);

            Instantiate(Candy, new Vector3(randomX, randomY, 0), Quaternion.Euler(randomRotX, randomRotY, randomRotZ));
        }
    }
}

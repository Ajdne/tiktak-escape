using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalColliderScript : MonoBehaviour
{
    public int score = 0;

    void OnTriggerEnter(Collider other)
    {
        score +=1;
        print(score);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalColliderScript : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.numberOfCandies --;
        UIManager.Instance.UpdateUI();
    }
}

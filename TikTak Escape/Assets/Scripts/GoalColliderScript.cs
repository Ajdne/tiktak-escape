using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalColliderScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {       
        GameManager.numberOfCandies --;
        UIManager.Instance.UpdateUI();

        Destroy(other.gameObject);
    }
}

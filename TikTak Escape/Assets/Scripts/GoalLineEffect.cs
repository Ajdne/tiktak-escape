using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLineEffect : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;


    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }

    // IEnumerator AnimateLine()
    // {
    //     float segmentDuration = animationDuration / waypoints.Length;

    //     for (int i = 0; i < waypoints.Length - 1; i++)
    //     {
    //         float startTime = Time.time;

    //         Vector3 startPos = waypoints[i].transform.position;
    //         Vector3 endPos = waypoints[i+1].transform.position;

    //         Vector3 pos = startPos;

    //         while (pos != endPos)
    //         {
    //             float t = (Time.time - startTime) / segmentDuration ;
    //             pos = Vector3.Lerp (startPos, endPos, t) ;

    //             // animate all other points except point at index i
    //             for (int j = i + 1; j < waypoints.Length; j++)
    //             line.SetPosition (j, pos) ;

    //             yield return null ;
    //         }
    //     }
    // }
}

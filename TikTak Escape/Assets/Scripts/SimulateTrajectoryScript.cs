using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulateTrajectoryScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    [SerializeField] private int maxTrajectoryPoints;

    void Start() {
        lineRenderer.positionCount = maxTrajectoryPoints;
    }

            //  PROBLEM JE NEGDE U WORLD TO SCREEN
    public void SimulateTrajectory(Vector3 startPoint, Vector3 inititalForce) {
        
        float g = Physics.gravity.magnitude;    // gravity acceleration
        float force = inititalForce.magnitude;
        float angle = Mathf.Atan2(inititalForce.y, inititalForce.x);

        float timeStep = 0.1f;
        float fTime = 0f;

        for (int i = 0; i < maxTrajectoryPoints; i++)
        {
            float dx = force * fTime * Mathf.Cos(angle);
            float dy = force * fTime * Mathf.Sin(angle) - (g * fTime * fTime / 2f);

            Vector3 pos = new Vector3 (startPoint.x + dx, startPoint.y + dy, 0);

            lineRenderer.SetPosition(i, pos);

            fTime += timeStep;
        }

    }
}

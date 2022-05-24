using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTouchScript : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
 
    bool mousePressed;
    public int power;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 force;

    [SerializeField] SimulateTrajectoryScript simTrajectory;

    void Start() {
        simTrajectory = GetComponent<SimulateTrajectoryScript>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {          // on mouse click

            ray = Camera.main.ScreenPointToRay (Input.mousePosition);

            if (Physics.Raycast (ray, out hit)) {       // if the click hits a target

                mousePressed = true;  

                //  PROBLEM JE NEGDE U WORLD TO SCREEN
                // Camera.main.ScreenToWorldPoint(Input.mousePosition);

                startPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);                
            }
        }

            
             
        force = (startPoint - endPoint) * power;

        if (mousePressed) {     // while the mouse is pressed down

            endPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

            simTrajectory.lineRenderer.enabled = true;  // enable line renderer

            simTrajectory.SimulateTrajectory(startPoint, force);

        }

        

        // simTrajectory.SimulateTrajectory(startPoint, force);     // draw line renderer

        if (Input.GetMouseButtonUp(0)) {            // on mouse release

            mousePressed = false;

            hit.rigidbody.AddForce(force);

            simTrajectory.lineRenderer.enabled = false;     // disable line renderer
        }
    }

}

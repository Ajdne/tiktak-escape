using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTouchScript : MonoBehaviour
{
    // 1st ray is for clicking on the capsule
    Ray ray;
    // 2nd ray is for detecting the end of drag
    Ray ray2;
    RaycastHit hit;
    RaycastHit hit2;
 
    bool mousePressed;
    public int power;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 force;

    public LineRenderer lineRend;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {          // on mouse click
            
            ray = Camera.main.ScreenPointToRay (Input.mousePosition);

            if (Physics.Raycast (ray, out hit)) {       // if the click hits a target

                if (hit.rigidbody.gameObject.layer == 6)    // candy layer
                {

                    startPoint = new Vector3(hit.transform.position.x, hit.transform.position.y, 0);

                    lineRend.enabled = true;
                }
            }
        }

        if(lineRend.enabled)
        {
            lineRend.SetPosition(0, hit.transform.position);
        }

        if (Input.GetMouseButton(0))
        {   
            // detect ray on plain
            ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast (ray2, out hit2))   // hit is basically an object hit by this raycast
            {
                endPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * (-1) ));

                lineRend.SetPosition(1, endPoint);                
            }
        }

        // calculate force
        force = (startPoint - endPoint) * power;

        if (Input.GetMouseButtonUp(0)) {    // on mouse release
        
            hit.rigidbody.AddForce(force);

            lineRend.enabled = false;
        }
    }
}

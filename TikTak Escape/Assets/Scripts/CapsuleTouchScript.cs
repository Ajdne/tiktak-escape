using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTouchScript : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
 
    public int power;
    public Vector3 minPower;
    public Vector3 maxPower;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 force;
    Rigidbody hitObject;
    Rigidbody pogodjen;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            ray = Camera.main.ScreenPointToRay (Input.mousePosition);

            if (Physics.Raycast (ray, out hit)) {

            startPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

            }
        }

        if (Input.GetMouseButtonUp(0)) {

            endPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

            print(pogodjen);
            hit.rigidbody.AddForce((startPoint - endPoint) * power);
        }


/*         ray = Camera.main.ScreenPointToRay (Input.mousePosition);

        if (Physics.Raycast (ray, out hit)) {   // if the ray hits something, store data in hit variable
                                                // candy box is in Ignore Raycast Layer
            if (Input.GetMouseButtonDown(0)) {
                print("Click!");
                //LaunchCapsule(hit.rigidbody);

                startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                startPoint.z = 0;

                hitObject = hit.rigidbody;
            }

        }

        if (Input.GetMouseButtonUp(0)) {
                endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                print("Otpust");
                print(Input.mousePosition);

                endPoint.z = 0;

                force = new Vector3(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x),
                                    Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y), 0);

                hitObject.AddForce(force * power);

            } */

    /*
    bool CapsuleTouch() {   // MOZDA NEMA POTREBE ZA OVIME

        if (hit.collider.tag == "Capsule") {
            return (true);
        }
        return (false);
    }
    */
}
}

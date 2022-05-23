using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleLaunchScript : MonoBehaviour
{
    public int power;
    public Vector3 minPower;
    public Vector3 maxPower;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 force;

    public void LaunchCapsule(Rigidbody rb) {
        
        startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // startPoint.z = 0;

        
        if (Input.GetMouseButtonDown(0)) {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // endPoint.z = 0;

            force = new Vector3(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x),
                                Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y), 0);

            rb.AddForce(force * power, ForceMode.Impulse);
        }
    }
}

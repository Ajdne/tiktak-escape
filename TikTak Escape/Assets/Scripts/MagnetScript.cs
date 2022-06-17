using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 6) // candy layer
        {
            SpringJoint joint = this.gameObject.AddComponent<SpringJoint>();

            joint.connectedBody = other.rigidbody;
            joint.spring = 100;

            //joint.breakForce = 10;
            
        }
    }
}

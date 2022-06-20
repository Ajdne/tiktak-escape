using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCapsuleScript : MonoBehaviour
{   
    private bool canStick = true;
    private Rigidbody capsuleRb;
    private void Start() {
        capsuleRb = this.GetComponent<Rigidbody>();
        //StartCoroutine(KeepItStuck());
        //StartCoroutine(CanItStick());
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Sticky" && capsuleRb.isKinematic == false && canStick) // not a candy layer
        {
            //this.transform.SetParent(other.transform, true);

            capsuleRb.isKinematic = true;
            capsuleRb.detectCollisions = false;

            Invoke("UnstuckIt", 4);
            
            //StartCoroutine(KeepItStuck());
            
        }
 
    }

    void UnstuckIt()
    {
        capsuleRb.isKinematic = false;
        capsuleRb.detectCollisions = true;
        canStick = false;
        print("Unstuck");

        //StartCoroutine(CanItStick());
    }

    void CanStick()
    {
        canStick = true;
        print("Can Stick");
    }
    IEnumerator KeepItStuck()
    {
        yield return new WaitForSeconds(3);
        capsuleRb.isKinematic = false;
        canStick = false;
        print("kek");

        
    }

    IEnumerator CanItStick()
    {
        yield return new WaitForSeconds(0.3f);
        canStick = true;
        print("kek zwei");
    }
}

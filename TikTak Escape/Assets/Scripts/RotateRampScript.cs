using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRampScript : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime), Space.World);
    }
}

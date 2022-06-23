using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackRot : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    void Update()
    {
        transform.Rotate(new Vector3(speed * Time.deltaTime, 0, 0), Space.World);
    }
}

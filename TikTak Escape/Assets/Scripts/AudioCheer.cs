using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCheer : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        source.PlayOneShot(clip);
    }
}

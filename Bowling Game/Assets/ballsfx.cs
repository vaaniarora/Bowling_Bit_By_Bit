using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsfx : MonoBehaviour
{
    public float gutterY = -0.03f;
    public float tolerance = 0.01f; 
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.clip = audioClip;
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y - gutterY) <= tolerance)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}

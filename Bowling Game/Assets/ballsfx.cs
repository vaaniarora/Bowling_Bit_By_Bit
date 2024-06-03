using UnityEngine;

public class BallSFX : MonoBehaviour
{
    public float groundY = -0.03f; // Adjust this value to match your ground level
    public AudioClip audioClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    void Update()
    {
        if (transform.position.y <= groundY)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}

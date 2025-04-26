using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cycleMusicScript : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = clips[Random.Range(0, clips.Length)];
            audioSource.Play();
        }
    }
}

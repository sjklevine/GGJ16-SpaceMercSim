using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioTrigger : MonoBehaviour
{
    public AudioClip _clip = null;
    private AudioSource _audioSource = null;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            _audioSource.PlayOneShot(_clip);
        }
    }
}

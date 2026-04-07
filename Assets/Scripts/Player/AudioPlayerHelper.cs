using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerHelper : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnWalk()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
        }
    }
}

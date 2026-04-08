using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomPlayAudioClips : MonoBehaviour
{
    // Fontes de áudio onde os clipes serão tocados
    public List<AudioSource> audioSources;

    private int _index = 0;

    public void PlayRandom()
    {
    
        if (audioSources == null || audioSources.Count == 0) return;

        if (_index >= audioSources.Count) _index = 0;

        var src = audioSources[_index];
        if (src == null)
        {
            _index++;
            return;
        }
        src.Play();

        _index++;
    }
}

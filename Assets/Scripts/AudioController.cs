using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource EffectsSource;

    public static AudioController Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Play(AudioClip clip, float volume = 1f)
    {
        EffectsSource.volume = volume;
        EffectsSource.PlayOneShot(clip);
    }
}

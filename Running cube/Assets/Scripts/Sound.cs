using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public AudioClip clip;

    public string Name;
    [Header("Audio Properties")]
    [Range(0f, 1f)] public float volume;
    [Range(.1f, 3f)] public float pitch;

    public bool loop;
    public AudioMixerGroup audioMixer;

    [HideInInspector]
    public AudioSource source;
}

using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public AudioClip clip;

    [SerializeField] private string Name;
    [Header("Audio Properties")]
    [Range(0f, 1f)] [SerializeField] private float volume;
    [Range(0f, 1f)] [SerializeField] private float pitch;
}

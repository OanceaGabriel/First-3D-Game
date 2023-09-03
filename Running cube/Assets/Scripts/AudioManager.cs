using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.buildIndex > 0 && scene.buildIndex < 7) 
        {
            Play("InGameMusic");
        }
        else if(scene.buildIndex == 7)
        {
            Play("GameComplete");
        }
        else
        {
            Play("MenuMusic");
        }
    }

    public void Awake()
    {
          foreach(Sound s in sounds)
          {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.audioMixer;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
          }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning(name + "Was not found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning(name + "Was not found");
            return;
        }
        s.source.Stop();
    }

}

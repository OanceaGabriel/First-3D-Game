using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds; //Array containing the sounds in the sound list
    private Scene scene;

    //The mixers that controll the overall sound volume for every category
    public AudioMixer menuMusicMixer;
    public AudioMixer gameMusicMixer;
    public AudioMixer soundEffectsMixer;

    private static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "Menu")
        {
            Play("MenuMusic");
        }
        else if(scene.name == "EndingScene")
        {
            Play("GameComplete");
        }
        else
        {
            Play("InGameMusic");
        }
        
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
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

    public void MusicVolume(float m_Volume)
    {
        menuMusicMixer.SetFloat("MenuMusic", m_Volume);        
    }

    public void GameVolume(float g_Volume)
    {
        gameMusicMixer.SetFloat("GameMusic", g_Volume);
    }

    public void SoundEffects(float s_Volume)
    {
        soundEffectsMixer.SetFloat("Effects", s_Volume);
    }

}

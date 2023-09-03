using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings_Menu : MonoBehaviour
{

    public AudioMixer menuMusicMixer;
    public AudioMixer gameMusicMixer;
    public AudioMixer soundEffectsMixer;
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

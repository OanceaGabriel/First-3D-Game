using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Settings_Menu : MonoBehaviour
{

    public AudioMixer menuMusicMixer;
    public AudioMixer gameMusicMixer;
    public AudioMixer soundEffectsMixer;

    //public static float m_SavedVolume;
    //public static float g_SavedVolume;
    //public static float s_SavedVolume;
   public void MusicVolume(float m_Volume)
    {
        menuMusicMixer.SetFloat("MenuMusic", m_Volume);
        //m_SavedVolume = m_Volume;
    }

    public void GameVolume(float g_Volume)
    {
        gameMusicMixer.SetFloat("GameMusic", g_Volume);
        //g_SavedVolume = g_Volume;
    }

    public void SoundEffects(float s_Volume)
    {
        soundEffectsMixer.SetFloat("Effects", s_Volume);
        //s_SavedVolume = s_Volume;
    }

    

    
}

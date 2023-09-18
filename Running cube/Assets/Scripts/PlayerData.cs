using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int fishCollectible;
    public int currentLvl;

    public float m_SavedVolume;
    public float g_SavedVolume;
    public float s_SavedVolume;

    public bool isUsingJoystick;
    public PlayerCharacterSerializable[] characters;

    public PlayerData(Game_Manager game_Manager, AudioManager audioManager)
    {
        fishCollectible = game_Manager.totalFishCollected;
        currentLvl = Game_Manager.currentLvl;

        isUsingJoystick = Game_Manager.isUsingJoystick;

        audioManager.menuMusicMixer.GetFloat("MenuMusic", out m_SavedVolume);
        audioManager.gameMusicMixer.GetFloat("GameMusic", out g_SavedVolume);
        audioManager.soundEffectsMixer.GetFloat("Effects", out s_SavedVolume);

        characters = Game_Manager.characters;
    }

   
}

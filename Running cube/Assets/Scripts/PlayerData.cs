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

    public PlayerData(Game_Manager game_Manager)
    {
        fishCollectible = game_Manager.totalFishCollected;
        currentLvl = Game_Manager.currentLvl;

        
            
    }

    public PlayerData(Settings_Menu settingsMenu)
    {
            settingsMenu.menuMusicMixer.GetFloat("MenuMusic", out m_SavedVolume);
            settingsMenu.gameMusicMixer.GetFloat("GameMusic", out g_SavedVolume);
            settingsMenu.soundEffectsMixer.GetFloat("Effects", out s_SavedVolume);
    }
}

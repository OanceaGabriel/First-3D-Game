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
        currentLvl = game_Manager.currentLvl;

        //m_SavedVolume = settingsMenu.m_SavedVolume;
        //g_SavedVolume = settingsMenu.g_SavedVolume;
        //s_SavedVolume = settingsMenu.s_SavedVolume;
    }
    
}

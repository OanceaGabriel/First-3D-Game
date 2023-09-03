using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int fishCollectible;

    public PlayerData(Game_Manager game_Manager)
    {
        fishCollectible = game_Manager.totalFishCollected;
    }
    
}

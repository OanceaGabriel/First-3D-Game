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

    public PlayerData()
    {
        fishCollectible = Game_Manager.totalFishCollected;
        currentLvl = Game_Manager.currentLvl;

        isUsingJoystick = Game_Manager.isUsingJoystick;

        AudioManager.Instance.menuMusicMixer.GetFloat("MenuMusic", out m_SavedVolume);
        AudioManager.Instance.gameMusicMixer.GetFloat("GameMusic", out g_SavedVolume);
        AudioManager.Instance.soundEffectsMixer.GetFloat("Effects", out s_SavedVolume);

        characters = Game_Manager.characters;
    }

   
}

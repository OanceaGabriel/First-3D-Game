using System;

[Serializable]
public class PlayerCharacterSerializable {
    public int value;
    public bool bought;
    public bool equipped;
    public string characterName;

    public PlayerCharacterSerializable(int value, bool bought, bool equipped, string characterName) {
        this.value = value;
        this.bought = bought;
        this.equipped = equipped;
        this.characterName = characterName;
    }

    public bool Equipped {get; set; }
}

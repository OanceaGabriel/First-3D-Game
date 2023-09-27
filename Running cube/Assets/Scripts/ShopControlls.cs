using System;
using System.Linq;
using UnityEngine;

public class ShopControlls : MonoBehaviour
{

    private int touchCount = 0;
    private float swipeTreshold = 300f;

    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    // Start is called before the first frame update
    public int currentCharacter;
    public int characterIndex;
    private PlayerCharacterSerializable[] gameCharacters;
    public GameObject equipButton;
    public GameObject buyButton;
    public GameObject equippedDisplay;

    void Start()
    {
        characterIndex = transform.childCount;
        gameCharacters = Game_Manager.characters;
        ReorderCharacters();
        UpdateButtons();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(touchCount).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(touchCount).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(touchCount).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(touchCount).position;

            if (startTouchPos.x < endTouchPos.x)
            {
                transform.Translate(-2, 0, 0);
            }
            else if(startTouchPos.x > endTouchPos.x)
            {
                transform.Translate(2, 0, 0);
            }
        }
        int newCurrentCharacter = (int)(transform.position.x / 2);
        if (newCurrentCharacter != currentCharacter) {
            currentCharacter = newCurrentCharacter;
            UpdateButtons();
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x < 0 || transform.position.x > characterIndex * 2 - 2)
        {
            transform.transform.position = Vector3.zero;
        }
    }

    
    public void EquipCharacter() 
    {
        // Getting current caracter GameObject
        GameObject currentCharacterObject = transform.GetChild(currentCharacter).gameObject;
        
        // Getting character that will be equipped and the current equipped character, together with their indexes
        PlayerCharacterSerializable player = gameCharacters.Where(p => p.characterName == currentCharacterObject.name).First();
        PlayerCharacterSerializable currentEquippedCharacter = gameCharacters.Where(p => p.equipped == true).First();
        int playerIndex = Array.FindIndex(gameCharacters, p => p.characterName == player.characterName);
        int currentEquippedCharacterIndex = Array.FindIndex(gameCharacters, p => p.characterName == currentEquippedCharacter.characterName);
        
        // Update equipped boolean values for both and save in array
        Game_Manager.characters[playerIndex].equipped = true;
        Game_Manager.characters[currentEquippedCharacterIndex].equipped = false;
        Game_Manager.characterEquipped = player;

        // Save the updated array in player.fun file
        SaveSystem.SaveGame();
        UpdateButtons();
    }

    public void BuyCharacter() 
    {
        GameObject currentCharacterObject = transform.GetChild(currentCharacter).gameObject;
        PlayerCharacterSerializable player = gameCharacters.Where(p => p.characterName == currentCharacterObject.name).First();
        int playerIndex = Array.FindIndex(gameCharacters, p => p.characterName == player.characterName);
        int nrOfFish = Game_Manager.totalFishCollected;
        if (player.value <= nrOfFish) {
            Game_Manager.characters[playerIndex].bought = true;
            Game_Manager.totalFishCollected -= player.value;
            SaveSystem.SaveGame();
            UpdateButtons();
        } else {
            // Popup or something with "not enough fish"
        }
    }

    private void UpdateButtons() 
    {
        PlayerCharacterSerializable currentPlayerCharacter = gameCharacters[currentCharacter];
        equippedDisplay.SetActive(currentPlayerCharacter.equipped);
        equipButton.SetActive(currentPlayerCharacter.bought && !equippedDisplay.activeSelf);
        buyButton.SetActive(!currentPlayerCharacter.bought);
    }

    private void ReorderCharacters() 
    {
        PlayerCharacter[] playerCharacters = transform.GetComponentsInChildren<PlayerCharacter>().OrderBy(c => c.value).ToArray();
        for(int i = 0; i < playerCharacters.Length; i++) {
            playerCharacters[i].transform.position = new Vector3(-2 * i, 0, 0);
        }
    }
}
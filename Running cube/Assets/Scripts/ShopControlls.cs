using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ShopControlls : MonoBehaviour
{

    private int touchCount = 0;
    private float swipeTreshold = 300f;

    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    // Start is called before the first frame update
    public float currentCharacter;
    public int characterIndex;

    void Start()
    {
        characterIndex = transform.childCount;
        Debug.Log("caractere: " + characterIndex);
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
                transform.Translate(2, 0, 0);
                
            }
            else
            {
                transform.Translate(-2, 0, 0);
                
            }
        }
        if (transform.position.x == characterIndex * 2 + 2)
        {
            transform.Translate(0, 0, 0);
        }
        else if (transform.position.x == -2)
        {
            transform.Translate(characterIndex * 2 - 2, 0, 0);
        }

        currentCharacter = transform.position.x / 2;
        //Debug.Log(currentCharacter);

    }

    public void EquipCharacter() {
        PlayerCharacterSerializable[] gameCharacters = Game_Manager.characters;

        // Getting current caracter GameObject
        GameObject currentCharacterObject = transform.GetChild((int)currentCharacter).gameObject;
        
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
    }

    public void BuyCharacter() {
        PlayerCharacterSerializable[] gameCharacters = Game_Manager.characters;
        GameObject currentCharacterObject = transform.GetChild((int)currentCharacter).gameObject;
        PlayerCharacterSerializable player = gameCharacters.Where(p => p.characterName == currentCharacterObject.name).First();
        int playerIndex = Array.FindIndex(gameCharacters, p => p.characterName == player.characterName);
        Game_Manager.characters[playerIndex].bought = true;
        Game_Manager.totalFishCollected -= player.value;
        SaveSystem.SaveGame();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Shop : MonoBehaviour
{

    // [SerializeField]
    private int totalNrOfFish;

    //[SerializeField]
    private PlayerCharacterSerializable[] characters;
    
    void Start()
    {
        characters = Game_Manager.characters;
        Debug.Log("nr of characters: " + characters.Length);
        Debug.Log("First: " + characters[0].characterName + ", " + characters[0].value);
        // Invoke(nameof(IntializeCharacterArray), 1);
        
    }

    private void IntializeCharacterArray() {
        
    }
}

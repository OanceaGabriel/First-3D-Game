using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update

    private int totalNrOfFish;
    private ShopOption[] shopOptions;
    
    void Start()
    {
        totalNrOfFish = FindAnyObjectByType<Game_Manager>().totalFishCollected;
        shopOptions = Array.ConvertAll(
            GameObject.FindGameObjectsWithTag("ShopCharacter"), 
            new Converter<GameObject, ShopOption>(GameObjectToShopOption)
        );
        Debug.Log("options: ");
        foreach (ShopOption shopOption in shopOptions) {
            Debug.Log("Option value: " + shopOption.OptionValue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static ShopOption GameObjectToShopOption(GameObject gameObject) {
        Debug.Log("Game object name: " + gameObject.name);
        return GameObject.Find(gameObject.name).GetComponent<ShopOption>(); 
    }
}

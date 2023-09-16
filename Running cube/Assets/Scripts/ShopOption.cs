using UnityEngine;

public class ShopOption : MonoBehaviour {
    
    [SerializeField]
    private int optionValue;
    private bool bought;

    public int OptionValue { get; set; }

    public bool Bought { get; set; }

    public ShopOption(int optionValue, bool bought) {
        this.optionValue = optionValue;
        this.bought = bought;
    }
}
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown mapDropdown;
    [SerializeField] private TMP_InputField Seed;
    public int IsMultiplayerOn = 1;
    private MapGenerator generator;

    public void Start()
    {
        generator = GetComponent<MapGenerator>();
    }

    public void GetDropdownValue() 
    {
        int PickedEntery = mapDropdown.value;

        Debug.Log(PickedEntery);
        if (PickedEntery == 0)
        {
            generator.randomTypeRandom();
        }
        else if (PickedEntery == 1) 
        {
            generator.randomTypeSeeded();
        }
        else if (PickedEntery == 2)
        {
            generator.randomTypeMapOfTheDay();
        }
    }

    public void GetSeed() 
    {
        string SeedString = Seed.text;
        int SeedChoice = int.Parse(SeedString);
        generator.SetSeed(SeedChoice);
    }

    public void Toggle(bool toggleValue)
    {
        if (toggleValue)
        {
            Debug.Log("Multiplayer On");
            IsMultiplayerOn = 0;
        }
        else 
        {
            Debug.Log("Multiplayer Off");
            IsMultiplayerOn = 1;
        }
    }

}

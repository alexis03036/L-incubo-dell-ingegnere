using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UMA;
using UMA.CharacterSystem;
using UnityEngine.UI;
using System.IO;
using JetBrains.Annotations;
using Unity.VisualScripting;
using static UMA.UMAData;


public class CharacterCreator : MonoBehaviour
{
    public DynamicCharacterAvatar avatar;
    public Slider heightSlider;
    public Slider bellySlider;

    private Dictionary<string, DnaSetter> dna;

    public List<string> hairModelsMale = new List<string>();
    private int currentHairMale;

    public List<string> hairModelsFemale = new List<string>();
    private int currentHairFemale;


    public List<string> shirtModelsMale = new List<string>();
    private int currentShirtMale;

    public List<string> shirtModelsFemale = new List<string>();
    private int currentShirtFemale;


    public List<string> pantsModelsMale = new List<string>();
    private int currentPantsMale;

    public List<string> pantsModelsFemale = new List<string>();
    private int currentPantsFemale;


    public List<string> shoesModelsMale = new List<string>();
    private int currentShoesMale;

    public List<string> shoesModelsFemale = new List<string>();
    private int currentShoesFemale;



    public string myRecipe;
    void OnEnable()
    {
        avatar.CharacterUpdated.AddListener(Updated);
        heightSlider.onValueChanged.AddListener(HeightChange);
        bellySlider.onValueChanged.AddListener(BellyChange);
    }
    void OnDisable()
    {
        avatar.CharacterUpdated.RemoveListener(Updated);
        heightSlider.onValueChanged.RemoveListener(HeightChange);
        bellySlider.onValueChanged.RemoveListener(BellyChange);
    }
    public void SwitchGender(bool male)
    {
        if (male && avatar.activeRace.name != "HumanMale")
            avatar.ChangeRace("HumanMale");

        if (!male && avatar.activeRace.name != "HumanFemale")
            avatar.ChangeRace("HumanFemale");
    }

    void Updated(UMAData data)
    {
        dna = avatar.GetDNA();
        heightSlider.value = dna["height"].Get();
        bellySlider.value = dna["belly"].Get();
    }

    public void HeightChange(float val)
    {
        dna["height"].Set(val);
        avatar.BuildCharacter();
    }

    public void BellyChange(float val)
    {
        dna["belly"].Set(val);
        avatar.BuildCharacter();
    }

    public void ChangeSkinColor(Color col)
    {
        avatar.SetColor("Skin", col);
        avatar.UpdateColors(true);

        Debug.Log(avatar.GetColor("Skin").color);
    }

    public void ChangeHairColor(Color col)
    {
        avatar.SetColor("Hair", col);
        avatar.UpdateColors(true);

        Debug.Log(avatar.GetColor("Hair").color);

    }

    public void ChangeHair(bool plus)
    {
        if (avatar.activeRace.name == "HumanMale")
        {
            if (plus)
                currentHairMale++;
            else
                currentHairMale--;

            currentHairMale = Mathf.Clamp(currentHairMale, 0, hairModelsMale.Count - 1);

            if ((hairModelsMale[currentHairMale]) == "None")
                avatar.ClearSlot("Hair");
            else
                avatar.SetSlot("Hair", hairModelsMale[currentHairMale]);
        }

        if (avatar.activeRace.name == "HumanFemale")
        {
            if (plus)
                currentHairFemale++;
            else
                currentHairFemale--;

            currentHairFemale = Mathf.Clamp(currentHairFemale, 0, hairModelsFemale.Count - 1);

            if ((hairModelsFemale[currentHairFemale]) == "None")
                avatar.ClearSlot("Hair");
            else
                avatar.SetSlot("Hair", hairModelsFemale[currentHairFemale]);

        }
        avatar.BuildCharacter();

        Debug.Log(avatar.GetWardrobeItemName("Hair"));
    }


    public void ChangeShirt(bool plus)
    {
        if (avatar.activeRace.name == "HumanMale")
        {
            if (plus)
                currentShirtMale++;
            else
                currentShirtMale--;

            currentShirtMale = Mathf.Clamp(currentShirtMale, 0, shirtModelsMale.Count - 1);

            if ((shirtModelsMale[currentShirtMale]) == "None")
                avatar.ClearSlot("Chest");
            else
                avatar.SetSlot("Chest", shirtModelsMale[currentShirtMale]);
        }

        if (avatar.activeRace.name == "HumanFemale")
        {
            if (plus)
                currentShirtFemale++;
            else
                currentShirtFemale--;

            currentShirtFemale = Mathf.Clamp(currentShirtFemale, 0, shirtModelsFemale.Count - 1);

            if ((shirtModelsFemale[currentShirtFemale]) == "None")
                avatar.ClearSlot("Chest");
            else
                avatar.SetSlot("Chest", shirtModelsFemale[currentShirtFemale]);

        }
        avatar.BuildCharacter();

        Debug.Log(avatar.GetWardrobeItemName("Chest"));
    }


    public void ChangePants(bool plus)
    {
        if (avatar.activeRace.name == "HumanMale")
        {
            if (plus)
                currentPantsMale++;
            else
                currentPantsMale--;

            currentPantsMale = Mathf.Clamp(currentPantsMale, 0, pantsModelsMale.Count - 1);

            if ((pantsModelsMale[currentPantsMale]) == "None")
                avatar.ClearSlot("Legs");
            else
                avatar.SetSlot("Legs", pantsModelsMale[currentPantsMale]);
        }

        if (avatar.activeRace.name == "HumanFemale")
        {
            if (plus)
                currentPantsFemale++;
            else
                currentPantsFemale--;

            currentPantsFemale = Mathf.Clamp(currentPantsFemale, 0, pantsModelsFemale.Count - 1);

            if ((pantsModelsFemale[currentPantsFemale]) == "None")
                avatar.ClearSlot("Legs");
            else
                avatar.SetSlot("Legs", pantsModelsFemale[currentPantsFemale]);

        }
        avatar.BuildCharacter();

        Debug.Log(avatar.GetWardrobeItemName("Legs"));
    }

    public void ChangeShoes(bool plus)
    {
        if (avatar.activeRace.name == "HumanMale")
        {
            if (plus)
                currentShoesMale++;
            else
                currentShoesMale--;

            currentShoesMale = Mathf.Clamp(currentShoesMale, 0, shoesModelsMale.Count - 1);

            if ((shoesModelsMale[currentShoesMale]) == "None")
                avatar.ClearSlot("Feet");
            else
                avatar.SetSlot("Feet", shoesModelsMale[currentShoesMale]);
        }

        if (avatar.activeRace.name == "HumanFemale")
        {
            if (plus)
                currentShoesFemale++;
            else
                currentShoesFemale--;

            currentShoesFemale = Mathf.Clamp(currentShoesFemale, 0, shoesModelsFemale.Count - 1);

            if ((shoesModelsFemale[currentShoesFemale]) == "None")
                avatar.ClearSlot("Feet");
            else
                avatar.SetSlot("Feet", shoesModelsFemale[currentShoesFemale]);

        }
        avatar.BuildCharacter();

        Debug.Log(avatar.GetWardrobeItemName("Feet"));

          void saveRecipe()
          {
              myRecipe = avatar.GetCurrentRecipe();
              File.WriteAllText(Application.persistentDataPath + "/avatar.txt", myRecipe);
          }



       /*   public void loadRecipe()
            {
                myRecipe = File.WriteAllText(Application.persistentDataPath + "/avatar.txt", myRecipe);
                avatar.ClearSlots();
                avatar.LoadFromRecipeString(myRecipe);
            }
*/


    }
}
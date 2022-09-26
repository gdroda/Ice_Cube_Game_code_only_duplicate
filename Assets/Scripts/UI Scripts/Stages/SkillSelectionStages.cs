using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectionStages : MonoBehaviour
{
    [SerializeField] private AbilityLibrary abilityLib;
    [SerializeField] private GameObject abilityPanel;
    [SerializeField] private Button skillBtn1;
    [SerializeField] private Button skillBtn2;
    [SerializeField] private Button stageBtn;
    [HideInInspector] Ability abilityOne, abilityTwo;

    enum ButtonSelected {one,two};
    ButtonSelected button;

    private void Start()
    {
        //Add listeners to the 2 buttons for skill assigning.
        skillBtn1.onClick.AddListener(ActivateButtonOne);
        skillBtn2.onClick.AddListener(ActivateButtonTwo);
        stageBtn.onClick.AddListener(UpdateIcon);
        foreach (Ability ability in abilityLib.abilityLib)
        {
            if (ability.inSlotOne) abilityOne = ability;
            if (ability.inSlotTwo) abilityTwo = ability;
        }
        UpdateIcon();
    }
    
    //Open/Close panel
    public void AbilityPanelToggle()
    {
        if (abilityPanel.activeSelf.Equals(true)) abilityPanel.SetActive(false);
        else if (abilityPanel.activeSelf.Equals(false)) abilityPanel.SetActive(true);
    }

    //Listeners for the 2 skill buttons
    void ActivateButtonOne() {button = ButtonSelected.one;}
    void ActivateButtonTwo() {button = ButtonSelected.two;}

    //Get ability from the pop up skill buttons and assign them
    public void GetAbility(Ability abi)
    {
        if (button.Equals(ButtonSelected.one))
        {
            abilityOne.inSlotOne = false;
            abi.inSlotOne = true;
            abilityOne = abi;
        }
        else if (button.Equals(ButtonSelected.two))
        {
            abilityTwo.inSlotTwo = false;
            abi.inSlotTwo = true;
            abilityTwo = abi;
        }
        UpdateIcon();
    }

    //Update button icons
    public void UpdateIcon()
    {
        if (abilityOne != null) 
        {
            if (abilityOne.unlocked)
            {
                skillBtn1.image.sprite = abilityOne.icon;
            }
            else skillBtn1.image.sprite = abilityOne.lockedIcon;

        }
        if (abilityTwo != null)
        {
            if (abilityTwo.unlocked)
            {
                skillBtn2.image.sprite = abilityTwo.icon;
            }
            else skillBtn2.image.sprite = abilityTwo.lockedIcon;

        }
    }
}

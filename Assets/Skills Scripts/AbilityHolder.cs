using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] private AbilityLibrary abilityLib;
    [SerializeField] private Button btnL, btnR;
    [SerializeField] private Image btnLCD, btnRCD;
    private Ability[] abilities = new Ability[2];
    float cooldownTimeOne, cooldownTimeTwo;
    float activeTimeOne, activeTimeTwo;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    AbilityState stateOne = AbilityState.ready;
    AbilityState stateTwo = AbilityState.ready;

    public void AbilityOne()
    {
        if (stateOne.Equals(AbilityState.ready))
        {
            if (abilities[0].unlocked)
            {
                abilities[0].Activate(gameObject);
                stateOne = AbilityState.active;
                activeTimeOne = abilities[0].duration;
            }
        }
    }

    public void AbilityTwo()
    {
        if (stateTwo.Equals(AbilityState.ready))
        {
            if (abilities[1].unlocked)
            {
                abilities[1].Activate(gameObject);
                stateTwo = AbilityState.active;
                activeTimeTwo = abilities[1].duration;
            }
        }
    }

    private void Start()
    {
        foreach (Ability ability in abilityLib.abilityLib)
        {
            if (ability.inSlotOne) abilities[0] = ability;
            else if (ability.inSlotTwo) abilities[1] = ability;
        }
        UpdateButtons();
    }

    void Update()
    {
        switch(stateOne)
        {
            case AbilityState.active:
                if (activeTimeOne > 0)
                {
                    activeTimeOne -= Time.deltaTime;
                }else
                {
                    abilities[0].BeginCooldown(gameObject);
                    stateOne = AbilityState.cooldown;
                    cooldownTimeOne = abilities[0].cooldown;
                    btnLCD.fillAmount = 1;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTimeOne > 0)
                {
                    btnL.gameObject.SetActive(false);
                    cooldownTimeOne -= Time.deltaTime;
                    btnLCD.fillAmount -= 1 / (float)abilities[0].cooldown * Time.deltaTime;
                }
                else
                {
                    stateOne = AbilityState.ready;
                    btnL.gameObject.SetActive(true);
                }
                break;
        }

        switch (stateTwo)
        {
            case AbilityState.active:
                if (activeTimeTwo > 0)
                {
                    activeTimeTwo -= Time.deltaTime;
                }
                else
                {
                    abilities[1].BeginCooldown(gameObject);
                    stateTwo = AbilityState.cooldown;
                    cooldownTimeTwo = abilities[1].cooldown;
                    btnRCD.fillAmount = 1;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTimeTwo > 0)
                {
                    btnR.gameObject.SetActive(false);
                    cooldownTimeTwo -= Time.deltaTime;
                    btnRCD.fillAmount -= 1 / (float)abilities[1].cooldown * Time.deltaTime;
                }
                else
                {
                    stateTwo = AbilityState.ready;
                    btnR.gameObject.SetActive(true);
                }
                break;
        }
    }

    private void UpdateButtons()
    {
        if (abilities[0].unlocked) btnL.image.sprite = abilities[0].icon;
        else btnL.image.sprite = abilities[0].lockedIcon;

        if (abilities[1].unlocked) btnR.image.sprite = abilities[1].icon;
        else btnR.image.sprite = abilities[1].lockedIcon;

        btnLCD.sprite = abilities[0].icon;
        btnRCD.sprite = abilities[1].icon;
    }
}

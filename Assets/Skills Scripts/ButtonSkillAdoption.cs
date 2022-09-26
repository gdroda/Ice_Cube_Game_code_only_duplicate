using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSkillAdoption : MonoBehaviour
{
    public Ability ability;
    Image img;

    private void Start()
    {
        img = GetComponent<Image>();
        AbilityReLock();
        UpdateAbility();
    }

    public void UpdateAbility()
    {
        if (ability != null)
        {
            if (ability.unlocked) img.sprite = ability.icon;
            else img.sprite = ability.lockedIcon;
        }
    }

    private void AbilityReLock()
    {
        if (ability.currentUpgrade > 0) ability.unlocked = true;
        else if (ability.currentUpgrade == 0) ability.unlocked = false;
    }
}

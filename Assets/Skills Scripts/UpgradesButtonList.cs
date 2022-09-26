using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesButtonList : MonoBehaviour
{
    [SerializeField] private ButtonSkillAdoption[] btnSkills;
    [SerializeField] private Button upgradesBtn;

    private void Start()
    {
        upgradesBtn.onClick.AddListener(UpdateButtons);
    }

    public void UpdateButtons()
    {
        foreach (ButtonSkillAdoption btn in btnSkills)
        {
            btn.UpdateAbility();
        }
    }
}

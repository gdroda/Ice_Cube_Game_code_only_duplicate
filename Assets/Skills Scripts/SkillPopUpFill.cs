using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class SkillPopUpFill : MonoBehaviour
{
    public UnityEvent onSkillUpgrade;
    [SerializeField] private AtTouchMessage msg;
    [SerializeField] private UpgradesButtonList uBL;
    public PlayerStats playerStats;
    public Image icon;
    public new TextMeshProUGUI name;
    public TextMeshProUGUI description;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI leveltext;
    public Button upgradeBtn;

    private Ability ability;
    private int cost;

    public void GetAbility(Ability abi)
    {
        ability = abi;
        PopUpUpdate();
    }

    private void OnEnable()
    {
        if (onSkillUpgrade == null) onSkillUpgrade = new UnityEvent();
    }

    public void SkillUpgrade()
    {
        if (ability.currentUpgrade < ability.maxUpgrade)
        {
            if (playerStats.coins > cost)
            {
                if (ability.currentUpgrade == 0)
                {
                    ability.unlocked = true;
                    uBL.UpdateButtons();
                }
                msg.TextPop("+1");
                ability.currentUpgrade += 1;
                playerStats.coins -= cost;
                playerStats.Save();
                PopUpUpdate();
                onSkillUpgrade.Invoke();
            }
            else msg.TextPop("Not enough coins!");
        }
        else msg.TextPop("Already maxed!");
    }

    private void PopUpUpdate()
    {
        if (ability != null)
        {
            icon.sprite = ability.icon;
            name.text = ability.skillName;

            var descr = ability.description;
            descr = descr.Replace("&duration", ability.duration.ToString());
            descr = descr.Replace("&cooldown", ability.cooldown.ToString());
            description.text = descr;

            cost = ability.cost * ability.costMultiplier * ability.currentUpgrade;
            leveltext.text = $"{ability.currentUpgrade}/{ability.maxUpgrade}";
            if (ability.currentUpgrade.Equals(ability.maxUpgrade))
            {
                upgradeCost.text = "MAX";
            }
            else if (ability.currentUpgrade.Equals(0))
            {
                upgradeCost.text = "UNLOCK";
            }else upgradeCost.text = cost.ToString();
        }
    }

    public void PopUpToggle()
    {
        if (gameObject.activeSelf.Equals(true))
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
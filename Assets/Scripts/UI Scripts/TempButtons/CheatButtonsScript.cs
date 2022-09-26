using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CheatButtonsScript : MonoBehaviour
{
    [SerializeField] private Button btnCoins, btnGems, btnReset;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private AbilityLibrary abilityLib;
    [SerializeField] private SkinsLibrary skinsLib;
    [SerializeField] private ColorsLibrary colorsLib;

    private void Start()
    {
        btnCoins.onClick.AddListener(Coins);
        btnGems.onClick.AddListener(Gems);
        btnReset.onClick.AddListener(Reset);
    }

    private void Coins()
    {
        playerStats.GetCoin(1000);
        playerStats.Save();
    }

    private void Gems()
    {
        playerStats.GetGems(1000);
        playerStats.Save();
    }

    private void Reset()
    {
        string path = Application.persistentDataPath + "/save.ice";
        if (File.Exists(path))
        {
            File.Delete(path);
            playerStats.coins = 0;
            playerStats.gems = 0;
            foreach (Skins skin in skinsLib.skinsLib)
            {
                skin.unlocked = false;
                skin.isActive = false;
            }
            skinsLib.skinsLib[0].unlocked = true;
            skinsLib.skinsLib[0].isActive = true;
            foreach (Colors color in colorsLib.colorsLib)
            {
                color.unlocked = false;
                color.isActive = false;
            }
            colorsLib.colorsLib[0].unlocked = true;
            colorsLib.colorsLib[0].isActive = true;
            foreach (Ability ability in abilityLib.abilityLib)
            {
                ability.unlocked = false;
                ability.inSlotOne = false;
                ability.inSlotTwo = false;
                ability.currentUpgrade = 0;
            }
            abilityLib.abilityLib[0].currentUpgrade = 1;
            abilityLib.abilityLib[0].unlocked = true;
            abilityLib.abilityLib[0].inSlotOne = true;
            abilityLib.abilityLib[1].inSlotTwo = true;
        }
        playerStats.Save();
    }
}

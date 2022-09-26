using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataToSave
{
    public int coins;
    public int gems;
    public int dashLevel;
    public int coolAidLevel;
    public int meltProtectLevel;
    public int meltSpeedPassiveLevel;
    public int coinMagnetLevel;

    public DataToSave(PlayerStats playerStats)
    {
        coins = playerStats.coins;
        gems = playerStats.gems;
        dashLevel = playerStats.abilityLevels[0].currentUpgrade;
        coolAidLevel = playerStats.abilityLevels[1].currentUpgrade;
        meltProtectLevel = playerStats.abilityLevels[2].currentUpgrade;
        coinMagnetLevel = playerStats.abilityLevels[3].currentUpgrade;
        meltSpeedPassiveLevel = playerStats.abilityLevels[4].currentUpgrade;
    }
}

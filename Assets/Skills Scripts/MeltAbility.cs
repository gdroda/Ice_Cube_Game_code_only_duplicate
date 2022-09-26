using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MeltAbility : Ability
{
    float tempMeltSpeed;
    PlayerSize size;

    public override void Activate(GameObject parent)
    {
        size = parent.GetComponent<PlayerSize>();
        tempMeltSpeed = size.MeltSpeedChange(0f);
    }

    public override void BeginCooldown(GameObject parent)
    {
        size.MeltSpeedChange(tempMeltSpeed);
    }
    private void Awake()
    {
        DataToSave data = SaveSystem.LoadPlayer();
        currentUpgrade = data.meltProtectLevel;
    }
}

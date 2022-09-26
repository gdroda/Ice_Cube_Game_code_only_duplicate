using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MeltSpeedPassiveAbility : Ability
{

    public override void Activate(GameObject parent)
    {
        PlayerSize size = parent.GetComponent<PlayerSize>();
        float meltSpeed = size.meltSpeed;
        size.MeltSpeedChange(meltSpeed - ((float)currentUpgrade/400f));
    }

    private void Awake()
    {
        DataToSave data = SaveSystem.LoadPlayer();
        currentUpgrade = data.meltSpeedPassiveLevel;
    }
}

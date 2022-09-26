using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SizeRestoreAbility : Ability
{
    public override void Activate(GameObject parent)
    {
        parent.transform.localScale = Vector3.one;
    }
    private void Awake()
    {
        DataToSave data = SaveSystem.LoadPlayer();
        currentUpgrade = data.coolAidLevel;
    }
}

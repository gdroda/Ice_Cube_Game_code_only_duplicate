using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MagnetAbility : Ability
{
    [Space(15)]
    public float radius;
    CoinMagnetBase coinMagBase;
    float tempRad;

    public override void Activate(GameObject parent)
    {
        coinMagBase = parent.GetComponent<CoinMagnetBase>();
        tempRad = coinMagBase.radius;
        coinMagBase.radius = radius;
    }

    public override void BeginCooldown(GameObject parent)
    {
        coinMagBase.radius = tempRad;
    }

    private void Awake()
    {
        DataToSave data = SaveSystem.LoadPlayer();
        currentUpgrade = data.coinMagnetLevel;
    }
}

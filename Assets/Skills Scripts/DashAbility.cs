using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DashAbility : Ability
{
    [Space(15)]
    public float dashVelocityMod;
    float tempVelz;
    Rigidbody rb;

    public override void Activate(GameObject parent)
    {
        rb = parent.GetComponent<Rigidbody>();
        /*
        movement.playerSpeed = movement.playerSpeed * (dashVelocity + ((float)currentUpgrade/4));
        */
        tempVelz = rb.velocity.z;
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, tempVelz + dashVelocityMod * currentUpgrade);
    }

    public override void BeginCooldown(GameObject parent)
    {
        //movement.speedBoostMod = 0f;
        if (rb.velocity.z > tempVelz) rb.velocity = rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, tempVelz);
    }

    private void Awake()
    {
        DataToSave data = SaveSystem.LoadPlayer();
        currentUpgrade = data.dashLevel;
    }
}

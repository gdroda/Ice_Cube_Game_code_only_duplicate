using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public string skillName;
    public float cooldown;
    public float duration;
    [TextArea] public string description;
    public int currentUpgrade;
    public int maxUpgrade;
    public Sprite icon;
    public Sprite lockedIcon;
    public int cost;
    public int costMultiplier;
    public bool unlocked;
    public bool inSlotOne, inSlotTwo;

    public virtual void Activate(GameObject parent) { }
    public virtual void BeginCooldown(GameObject parent) { }
}

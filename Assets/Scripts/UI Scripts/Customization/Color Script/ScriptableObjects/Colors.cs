using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Colors : ScriptableObject
{
    public Material mat;
    public bool isActive;
    public bool unlocked;
    public int cost;
    public enum Currency
    {
        coins,
        gems
    }
    public Currency currency;
    public Sprite icon;
    public Sprite lockedIcon;
}

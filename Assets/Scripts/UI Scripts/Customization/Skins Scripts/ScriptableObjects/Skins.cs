using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Skins : ScriptableObject
{
    public Mesh mesh;
    public Mesh colliderMesh;
    public int cost;
    public enum Currency
    {
        coins,
        gems
    }
    public Currency currency;
    public bool unlocked;
    public int previewScale;
    public bool isActive;
    public Sprite icon;
    public Sprite lockedIcon;
}

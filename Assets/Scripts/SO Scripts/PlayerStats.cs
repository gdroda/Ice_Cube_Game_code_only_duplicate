using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public Ability[] abilityLevels = new Ability[8];

    #region Movement Attributes
    [Header("Movement Attributes")]
    public float playerSpeed;
    [Range(0,5)] public int speedUpgrade;
    public float turnSpeed;
    public float playerMaxSpeed;
    public float acceleration;
    public float rotAmount;
    public float gravityConst;
    #endregion

    #region Melting Attributes
    [Header("Melting Attributes")]
    [HideInInspector] public float currentSizeRef;
    #endregion

    #region IceBall hitting event
    public delegate void Notify(); // make delegate
    public event Notify BallHit; // make event based on delegate
    protected virtual void OnBallHit() { BallHit?.Invoke(); } //Event invoke from protected virtual for some reason...let it be
    public void BallHitted() { OnBallHit(); } //function for the unityevent in iceball to call and for it to call event
    #endregion

    [HideInInspector] public int coins;
    [HideInInspector] public int gems;
    public void GetCoin(int amount)
    {
        coins += amount;
    }

    public void GetGems(int amount)
    {
        gems += amount;
    }

    #region Save/Load
    public void Save()
    {
        SaveSystem.SavePlayer(this);
    }

    public void Load()
    {
        DataToSave data = SaveSystem.LoadPlayer();
        coins = data.coins;
        gems = data.gems;
        Debug.Log("Loaded Game!");
    }
    #endregion
}

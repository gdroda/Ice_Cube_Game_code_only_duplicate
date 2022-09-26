using System;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    [SerializeField]
    private PlayerStats playerStats;
    
    public float meltSpeed;
    public float minSize;
    public float frostAmount;

    Vector3 minSizeVector;
    Vector3 meltSpeedVector;
    Vector3 amount;

    private void OnEnable()
    {
        playerStats.BallHit += IncreaseSize; //Subscribing to event
    }

    private void OnDisable()
    {
        playerStats.BallHit -= IncreaseSize; //Unsubscribing cause ERROOOOORS, when reloading stage on runtime.
    }

    private void Awake() 
    {
        amount = new Vector3(frostAmount, frostAmount, frostAmount);
        meltSpeedVector = new Vector3(meltSpeed, meltSpeed, meltSpeed);
        minSizeVector = new Vector3(minSize, minSize, minSize);
    }

    private void Update()
    {
        // Constant Size Decrease.
        if (transform.localScale.x > minSize) transform.localScale -= meltSpeedVector * Time.deltaTime;
        else if (transform.localScale.x < minSize) transform.localScale = minSizeVector;
        playerStats.currentSizeRef = transform.localScale.x;
    }

    public void IncreaseSize()
    {
        if (transform.localScale.x + amount.x > 1)
            transform.localScale = Vector3.one;
        else
            transform.localScale += amount;
    }

    public float MeltSpeedChange(float amt)
    {
        var prevMSpeed = meltSpeedVector.x;
        meltSpeedVector = new Vector3(amt, amt, amt);
        return prevMSpeed;
    }

}

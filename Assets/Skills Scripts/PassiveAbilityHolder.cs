using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAbilityHolder : MonoBehaviour
{
    public Ability[] passives;

    private void Start()
    {
        foreach (Ability ability in passives)
        {
            ability.Activate(gameObject);
        }
    }
}

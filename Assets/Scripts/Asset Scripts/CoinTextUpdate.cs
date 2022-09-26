using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI gemsText;
    [SerializeField] private PlayerStats playerStats;

    void Update()
    {
        coinText.text = playerStats.coins.ToString();
        gemsText.text = playerStats.gems.ToString();
    }
}

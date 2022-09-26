using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string gems100 = "com.postworkgrind.meltingpoint.100gems";
    private string gems500 = "com.postworkgrind.meltingpoint.500gems";
    private string noAds = "com.postworkgrind.meltingpoint.removeads";
    [SerializeField] PlayerStats playerStats;

    public void OnPurchaseComplete(Product product)
    {
        string id = product.definition.id;
        if (id == gems100)
        {
            playerStats.GetGems(100);
            Debug.Log("Purchased 100 gems!");
        }
        else if (id == gems500)
        {
            playerStats.GetGems(500);
            Debug.Log("Purchased 500 gems!");
        }
        else if (id == noAds)
        {
            Debug.Log("Removed Ads!");
        }
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase failed cause " + reason);
    }
}

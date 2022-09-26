using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButtonHolder : MonoBehaviour
{
    public Skins skin;
    Image img;

    private void Start()
    {
        img = GetComponent<Image>();
        UpdateSkinIcon();
    }

    public void UpdateSkinIcon()
    {
        if (skin != null)
        {
            if (skin.unlocked) img.sprite = skin.icon;
            else img.sprite = skin.lockedIcon;
            if (skin.isActive) img.color = Color.green;
            else img.color = Color.white;
        }
    }
}

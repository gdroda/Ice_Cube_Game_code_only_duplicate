using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorHolder : MonoBehaviour
{
    public Colors color;
    Image img;

    private void Start()
    {
        img = GetComponent<Image>();
        UpdateSkinIcon();
    }

    public void UpdateSkinIcon()
    {
        if (color != null)
        {
            img.sprite = color.unlocked ? color.icon : color.lockedIcon;
            img.color = color.isActive ? Color.green : Color.white;
        }
    }
}

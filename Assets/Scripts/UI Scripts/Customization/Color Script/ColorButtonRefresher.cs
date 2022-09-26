using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButtonRefresher : MonoBehaviour
{
    [SerializeField] private ColorHolder[] colorBtns;
    public void UpdateButtons()
    {
        foreach (ColorHolder btn in colorBtns)
        {
            btn.UpdateSkinIcon();
        }
    }
}

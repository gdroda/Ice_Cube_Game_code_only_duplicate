using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinButtonRefresher : MonoBehaviour
{
    [SerializeField] private SkinButtonHolder[] skinBtn;
    public void UpdateButtons()
    {
        foreach (SkinButtonHolder btn in skinBtn)
        {
            btn.UpdateSkinIcon();
        }
    }
}

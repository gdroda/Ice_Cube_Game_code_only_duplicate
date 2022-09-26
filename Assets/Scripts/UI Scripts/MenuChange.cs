using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChange : MonoBehaviour
{
    public GameObject intromenu;
    public GameObject mainmenu;
    public GameObject stagesmenu;
    public GameObject settingsmenu;
    public GameObject upgrades;
    public GameObject customize;
    public GameObject shop;

    public void MenuToStageMenu()
    {

        if (mainmenu.activeSelf.Equals(true))
        {
            mainmenu.SetActive(false);
            stagesmenu.SetActive(true);
        }
        else if (stagesmenu.activeSelf.Equals(true))
        {
            mainmenu.SetActive(true);
            stagesmenu.SetActive(false);
        }
    }

    public void MenuToUpgradesMenu()
    {

        if (mainmenu.activeSelf.Equals(true))
        {
            mainmenu.SetActive(false);
            upgrades.SetActive(true);
        }
        else if (upgrades.activeSelf.Equals(true))
        {
            mainmenu.SetActive(true);
            upgrades.SetActive(false);
        }
    }

    public void MenuToSettingsMenu()
    {

        if (mainmenu.activeSelf.Equals(true))
        {
            mainmenu.SetActive(false);
            settingsmenu.SetActive(true);
        }
        else if (settingsmenu.activeSelf.Equals(true))
        {
            mainmenu.SetActive(true);
            settingsmenu.SetActive(false);
        }
    }

    public void MenuToIntroMenu()
    {

        if (mainmenu.activeSelf.Equals(true))
        {
            mainmenu.SetActive(false);
            intromenu.SetActive(true);
        }
        else if (intromenu.activeSelf.Equals(true))
        {
            mainmenu.SetActive(true);
            intromenu.SetActive(false);
        }
    }

    public void MenuToCustomizeMenu()
    {

        if (mainmenu.activeSelf.Equals(true))
        {
            mainmenu.SetActive(false);
            customize.SetActive(true);
        }
        else if (customize.activeSelf.Equals(true))
        {
            mainmenu.SetActive(true);
            customize.SetActive(false);
        }
    }

    public void MenuToShopMenu()
    {

        if (mainmenu.activeSelf.Equals(true))
        {
            mainmenu.SetActive(false);
            shop.SetActive(true);
        }
        else if (shop.activeSelf.Equals(true))
        {
            mainmenu.SetActive(true);
            shop.SetActive(false);
        }
    }
}

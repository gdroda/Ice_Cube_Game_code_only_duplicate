using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModelSwitch : MonoBehaviour
{
    [SerializeField] private SkinsLibrary skinsLib;
    [SerializeField] private ColorsLibrary colorsLib;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private CustomizeSwitch switcher;
    [SerializeField] private AtTouchMessage msg;
    [SerializeField] private SkinButtonRefresher sBR;
    [SerializeField] private ColorButtonRefresher cBR;
    Transform[] models;
    Transform currentModel;
    private Skins currentSkin;
    private Colors currentColor;
    private Skins chosenSkin;
    private Colors chosenColor;

    [SerializeField] private Button buyButton;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Image currencyImage;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private GameObject areYouSureWindow;

    [SerializeField] private Button customizeBtn;

    private void Start()
    {
        customizeBtn.onClick.AddListener(onCustomizeClick);
    }

    private void OnEnable()
    {
        InitialModel();
    }

    private void InitialModel()
    {
        if (models == null)
        {
            var childrenList = new List<Transform>(); //the models are childer in this gameObject.
            foreach (Transform child in transform)
            {
                childrenList.Add(child);
            }
            models = childrenList.ToArray();
        }

        foreach (Skins skin in skinsLib.skinsLib)
        {
            if (skin.isActive) currentSkin = skin;
        }

        foreach (Colors color in colorsLib.colorsLib)
        {
            if (color.isActive) currentColor = color;
        }

        chosenSkin = currentSkin;
        chosenColor = currentColor;
        ChangeModel(currentSkin);
        UpdateStatus();
    }

    public void MainButton()
    {
        switch (switcher.selectedCosmetic)
        {
            case CustomizeSwitch.SelectedCosmetic.skins:
                if (chosenSkin.unlocked)
                {
                    SetActiveSkin();
                }
                else
                {
                    if (chosenSkin.currency.Equals(Skins.Currency.coins))
                    {
                        if (playerStats.coins > chosenSkin.cost)
                        {
                            ToggleBuyWindow();
                        }
                        else msg.TextPop("Not enough coins!");
                    }
                    else if (chosenSkin.currency.Equals(Skins.Currency.gems))
                    {
                        if (playerStats.gems > chosenSkin.cost)
                        {
                            ToggleBuyWindow();
                        }
                        else msg.TextPop("Not enough gems!");
                    }
                }
                break;
            case CustomizeSwitch.SelectedCosmetic.colors:
                if (chosenColor.unlocked)
                {
                    SetActiveColor();
                }
                else
                {
                    if (chosenColor.currency.Equals(Colors.Currency.coins))
                    {
                        if (playerStats.coins > chosenSkin.cost)
                        {
                            ToggleBuyWindow();
                        }
                        else msg.TextPop("Not enough coins!");
                    }
                    else if (chosenColor.currency.Equals(Colors.Currency.gems))
                    {
                        if (playerStats.gems > chosenSkin.cost)
                        {
                            ToggleBuyWindow();
                        }
                        else msg.TextPop("Not enough gems!");
                    }
                }
                break;
        }
        
    }

    private void ToggleBuyWindow()
    {
        if (areYouSureWindow.activeSelf.Equals(true)) areYouSureWindow.SetActive(false);
        else areYouSureWindow.SetActive(true);
    }

    public void BuyButton()
    {
        switch (switcher.selectedCosmetic)
        {
            case CustomizeSwitch.SelectedCosmetic.skins:
                if (chosenSkin.currency.Equals(Skins.Currency.coins))
                {
                    playerStats.coins -= chosenSkin.cost;

                }
                else if (chosenSkin.currency.Equals(Skins.Currency.gems))
                {
                    playerStats.gems -= chosenSkin.cost;
                }
                chosenSkin.unlocked = true;
                playerStats.Save();
                SetActiveSkin();
                sBR.UpdateButtons();
                ToggleBuyWindow();
                break;
            case CustomizeSwitch.SelectedCosmetic.colors:
                if (chosenColor.currency.Equals(Colors.Currency.coins))
                {
                    playerStats.coins -= chosenColor.cost;

                }
                else if (chosenColor.currency.Equals(Colors.Currency.gems))
                {
                    playerStats.gems -= chosenColor.cost;
                }
                chosenColor.unlocked = true;
                playerStats.Save();
                SetActiveColor();
                cBR.UpdateButtons();
                ToggleBuyWindow();
                break;
        }
    }

    public void ChangeModel(Skins skin)
    {
        if (currentModel != null) currentModel.gameObject.SetActive(false);
        currentModel = SkinToModel(skin);
        currentModel.GetComponent<MeshRenderer>().material = chosenColor.mat;
        currentModel.gameObject.SetActive(true);
        chosenSkin = skin;

        UpdateStatus();
    }

    public void ChangeColor(Colors color)
    {
        chosenColor = color;
        currentModel.GetComponent<MeshRenderer>().material = color.mat;

        UpdateStatus();
    }

    private void SetActiveSkin()
    {
        currentSkin.isActive = false;
        chosenSkin.isActive = true;
        currentSkin = chosenSkin;
        UpdateStatus();
        sBR.UpdateButtons();
    }

    private void SetActiveColor()
    {
        currentColor.isActive = false;
        chosenColor.isActive = true;
        currentColor = chosenColor;
        UpdateStatus(); // change?
        cBR.UpdateButtons();
    }

    private void UpdateStatus()
    {
        switch (switcher.selectedCosmetic)
        {
            case CustomizeSwitch.SelectedCosmetic.skins:
                if (chosenSkin.unlocked)
                {
                    costText.gameObject.SetActive(false);
                    currencyImage.gameObject.SetActive(false);
                    buttonText.text = "Enable";
                }
                else
                {
                    costText.gameObject.SetActive(true);
                    costText.text = chosenSkin.cost.ToString();
                    currencyImage.gameObject.SetActive(true);
                    //if (skin.currency.Equals(Skins.Currency.coins)) currencyImage.sprite = skin.icon; USE COIN ICON HERE
                    //else currencyImage.sprite = skin.lockedIcon; USE GEM ICON HERE
                    buttonText.text = "Purchase";
                }
                break;
            case CustomizeSwitch.SelectedCosmetic.colors:
                if (chosenColor.unlocked)
                {
                    costText.gameObject.SetActive(false);
                    currencyImage.gameObject.SetActive(false);
                    buttonText.text = "Enable";
                }
                else
                {
                    costText.gameObject.SetActive(true);
                    costText.text = chosenColor.cost.ToString();
                    currencyImage.gameObject.SetActive(true);
                    //if (skin.currency.Equals(Skins.Currency.coins)) currencyImage.sprite = skin.icon; USE COIN ICON HERE
                    //else currencyImage.sprite = skin.lockedIcon; USE GEM ICON HERE
                    buttonText.text = "Purchase";
                }
                break;
        }
    }

    private void onCustomizeClick()
    {
        ChangeModel(currentSkin);
        ChangeColor(currentColor);
        UpdateStatus();
        switcher.SwitchToSkins();
        sBR.UpdateButtons();
    }

    private Transform SkinToModel(Skins skin) //using index based model for models here.
    {
        switch (skin.name)
        {
            case "Cube":
                return models[0];
            case "Sphere":
                return models[1];
            case "Capsule":
                return models[2];
            default:
                return models[0];
        }
    }
}

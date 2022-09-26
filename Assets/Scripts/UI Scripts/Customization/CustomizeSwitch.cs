using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeSwitch : MonoBehaviour
{
    public enum SelectedCosmetic
    {
        skins,
        colors
    }
    public SelectedCosmetic selectedCosmetic = SelectedCosmetic.skins;


    [SerializeField] private GameObject[] panels;
    [SerializeField] private Button[] buttons;

    GameObject oldPanel;

    // Start is called before the first frame update
    void Start()
    {
        selectedCosmetic = SelectedCosmetic.skins;
        buttons[0].onClick.AddListener(SwitchToSkins);
        buttons[1].onClick.AddListener(SwitchToColors);
        oldPanel = panels[0];
    }

    public void SwitchToSkins()
    {
        var temp = GetCurrentPanel(panels[0]);
        temp.SetActive(false);
        panels[0].SetActive(true);
        selectedCosmetic = SelectedCosmetic.skins;
    }

    public void SwitchToColors()
    {
        var temp = GetCurrentPanel(panels[1]);
        temp.SetActive(false);
        panels[1].SetActive(true);
        selectedCosmetic = SelectedCosmetic.colors;
    }

    private GameObject GetCurrentPanel(GameObject activePanel)
    {
        var temp = oldPanel;
        oldPanel = activePanel;
        return temp;
    }
}

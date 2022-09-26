using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeltSlider : MonoBehaviour
{
    [SerializeField] private Slider meltSlider;
    [SerializeField] private PlayerSize playerSize;


    // Update is called once per frame
    void Update()
    {
        meltSlider.value = playerSize.transform.localScale.x;
    }
}

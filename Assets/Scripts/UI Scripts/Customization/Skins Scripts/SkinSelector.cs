using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    [SerializeField] private SkinsLibrary skinsLib;
    [SerializeField] private ColorsLibrary colorsLib;
    [SerializeField] private MeshCollider col;
    [SerializeField] private MeshRenderer meshRend;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Skins skin in skinsLib.skinsLib)
        {
            if(skin.isActive)
            {
                GetComponent<MeshFilter>().mesh = skin.mesh;
                col.sharedMesh = skin.colliderMesh;
            }
        }
        
        foreach (Colors color in colorsLib.colorsLib)
        {
            if (color.isActive)
            {
                GetComponent<MeshRenderer>().material = color.mat;
            }
        }
    }
}

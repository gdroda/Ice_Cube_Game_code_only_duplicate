using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinReceiver : MonoBehaviour
{
    [SerializeField] private Skins skin;
    // Start is called before the first frame update
    void Start()
    {
        var meshF = GetComponent<MeshFilter>();
        meshF.mesh = skin.mesh;
        transform.localScale = new Vector3 (skin.previewScale, skin.previewScale, skin.previewScale);
    }
}

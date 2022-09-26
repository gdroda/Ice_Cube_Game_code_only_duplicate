using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCubeRotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(10f * Time.deltaTime, 0f, 10f * Time.deltaTime));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnetBase : MonoBehaviour
{
    public Collider[] hitColliders;
   [HideInInspector] public float radius;

    // Update is called once per frame
    void Update()
    {
        hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Coin"))
            {
                float speed = 30f * Time.deltaTime;
                hitCollider.transform.parent.transform.position = Vector3.MoveTowards(hitCollider.transform.parent.transform.position, transform.position, speed);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

using System;
using UnityEngine;
using UnityEngine.Events;

public class IceBall : MonoBehaviour
{
    public UnityEvent _hitIceBall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _hitIceBall.Invoke();
        }
        Destroy(this.transform.parent.gameObject);
    }
}

using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AlarmSystemTrigger : MonoBehaviour
{
    public event Action TriggerEntered;
    public event Action TriggerExited;

    private int _targetsInside;

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        int firstCrook = 1;

        if (other.TryGetComponent<Crook>(out _))
        {
            _targetsInside++;

            if (_targetsInside == firstCrook)
                TriggerEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Crook>(out _))
        {
            _targetsInside--;

            if (_targetsInside <= 0)
                TriggerExited?.Invoke();
        }
    }
}

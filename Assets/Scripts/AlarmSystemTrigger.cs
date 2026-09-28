using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AlarmSystemTrigger : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;

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
                _alarmSystem.TurnOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Crook>(out _))
        {
            _targetsInside--;

            if (_targetsInside <= 0)
                _alarmSystem.TurnOff();
        }
    }
}

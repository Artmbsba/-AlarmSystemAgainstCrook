using UnityEngine;

public class HouseWithAlarmSystem : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;
    [SerializeField] private AlarmSystemTrigger _alarmSystemTrigger;

    private void OnEnable()
    {
        _alarmSystemTrigger.TriggerEntered += OnTriggerEntered;
        _alarmSystemTrigger.TriggerExited += OnTriggerExited;
    }

    private void OnDisable()
    {
        _alarmSystemTrigger.TriggerEntered -= OnTriggerEntered;
        _alarmSystemTrigger.TriggerExited -= OnTriggerExited;
    }

    private void OnTriggerEntered()
    {
        _alarmSystem.TurnOn();
    }

    private void OnTriggerExited()
    {
        _alarmSystem.TurnOff();
    }
}

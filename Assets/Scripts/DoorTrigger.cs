using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;

    private bool _hasOpener;

    private void Update()
    {
        if (_hasOpener && _door.IsOpen == false && Input.GetKeyDown(KeyCode.E))
            _door.Open();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Crook>(out _))
            _hasOpener = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Crook>(out _))
        {
            _hasOpener = false;
            _door.Close();
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(CrookAnimation))]
[RequireComponent(typeof(Rigidbody))]
public class Crook : MonoBehaviour
{
    private InputReader _inputReader;
    private Mover _mover;
    private CrookAnimation _crookAnimation;

    private IInteractable _currentInteractable;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _crookAnimation = GetComponent<CrookAnimation>();
    }

    private void OnEnable()
    {
        _inputReader.Interacted += OnInteract;
    }

    private void Update()
    {
        _mover.Rotate();
        _mover.Move();
        _crookAnimation.SetSpeed(_mover.CurrentSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interacteble))
            _currentInteractable = interacteble;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interacteble) && interacteble == _currentInteractable)
            _currentInteractable = null;
    }

    private void OnDisable()
    {
        _inputReader.Interacted -= OnInteract;
    }

    private void OnInteract()
    {
        if (_currentInteractable == null)
            return;

        _currentInteractable.Interact();
    }
}

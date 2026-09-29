using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(CrookAnimation))]
[RequireComponent(typeof(FootstepsAudio))]
public class Crook : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private FootstepsAudio _audioSteps;
    private InputReader _inputReader;
    private Mover _mover;
    private CrookAnimation _crookAnimation;

    private void Awake()
    {
        _audioSteps = GetComponent<FootstepsAudio>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _crookAnimation = GetComponent<CrookAnimation>();
    }

    private void OnEnable()
    {
        _inputReader.Interacted += OnInteract;
    }

    private void FixedUpdate()
    {
        float distance = _mover.Move();

        _audioSteps.CreateAudioSteps(distance);
        _crookAnimation.SetSpeed(_mover.CurrentSpeed);
    }

    private void Update()
    {
        _mover.Rotate();
    }

    private void OnDisable()
    {
        _inputReader.Interacted -= OnInteract;
    }

    private void OnInteract()
    {
        float maxDistance = 3f;

        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            if (hit.collider.TryGetComponent(out IInteractable interactable))
                interactable.Interact();
    }
}

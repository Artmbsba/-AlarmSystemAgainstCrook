using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 100f;
    [SerializeField] private float _moveSpeed = 2f;

    private Rigidbody _rigidbody;
    private InputReader _inputReader;
    private Vector2 _moveInput;

    public float CurrentSpeed { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = false;
        _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.MoveInputChanged += OnMoveInputChanged;
    }

    private void OnDisable()
    {
        _inputReader.MoveInputChanged -= OnMoveInputChanged;
    }

    public void Rotate()
    {
        float rotation = _moveInput.x;

        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime * Vector3.up);
    }

    public float Move()
    {
        float direction = _moveInput.y;

        Vector3 forward = transform.forward;
        forward.y = 0f;

        Vector3 targetVelocity = forward * (direction * _moveSpeed);

        _rigidbody.linearVelocity = new Vector3(targetVelocity.x, _rigidbody.linearVelocity.y, targetVelocity.z);

        CurrentSpeed = Mathf.Abs(direction) * _moveSpeed;

        return direction * _moveSpeed * Time.fixedDeltaTime;
    }

    private void OnMoveInputChanged(Vector2 input)
    {
        _moveInput = input;
    }
}
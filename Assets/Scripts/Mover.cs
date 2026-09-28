using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class Mover : MonoBehaviour
{
    [SerializeField] private AudioSource _stepsAudioSource;
    [SerializeField] private float _rotateSpeed = 100f;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _stepDistance = 1f;
    [SerializeField] private float _coveredDestance;

    private InputReader _inputReader;
    private Vector2 _moveInput;

    public float CurrentSpeed { get; private set; }

    private void Awake()
    {
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

    public void Move()
    {
        float direction = _moveInput.y;

        float distance = direction * _moveSpeed * Time.deltaTime;

        transform.Translate(distance * Vector3.forward);

        CurrentSpeed = Mathf.Abs(direction) * _moveSpeed;

        CreateAudioSteps(distance);
    }

    private void OnMoveInputChanged(Vector2 input)
    {
        _moveInput = input;
    }

    private void CreateAudioSteps(float distance)
    {
        _coveredDestance += Mathf.Abs(distance);

        if (_coveredDestance >= _stepDistance)
        {
            _coveredDestance -= _stepDistance;
            _stepsAudioSource.Play();
        }
    }
}
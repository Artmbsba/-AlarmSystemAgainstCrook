using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private AudioSource _stepsAudioSource;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepDistance = 1f;
    [SerializeField] private float _coveredDestance;

    public float CurrentSpeed { get; private set; }

    public void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);

        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime * Vector3.up);
    }

    public void Move()
    {
        float direction = Input.GetAxis(Vertical);

        float distance = direction * _moveSpeed * Time.deltaTime;

        transform.Translate(distance * Vector3.forward);

        CurrentSpeed = Mathf.Abs(direction) * _moveSpeed;

        CreateAudioSteps(distance);
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
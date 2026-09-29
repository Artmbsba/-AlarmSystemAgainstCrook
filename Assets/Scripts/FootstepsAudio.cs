using UnityEngine;

public class FootstepsAudio : MonoBehaviour
{
    [SerializeField] private float _coveredDestance;
    [SerializeField] private float _stepDistance = 1f;
    [SerializeField] private AudioSource _stepsAudioSource;

    public void CreateAudioSteps(float distance)
    {
        _coveredDestance += Mathf.Abs(distance);

        if (_coveredDestance >= _stepDistance)
        {
            _coveredDestance -= _stepDistance;
            _stepsAudioSource.Play();
        }
    }
}

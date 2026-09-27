using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeSpeed = 0.25f;

    private float _targetVolume;
    private bool _isActive;

    private void Awake()
    {
        _audioSource.volume = 0f;
        _audioSource.loop = true;
    }

    private void Update()
    {
        if (Mathf.Approximately(_audioSource.volume, _targetVolume))
        {
            if (_targetVolume == 0f && _isActive == false)
                _audioSource.Stop();

            return;
        }

        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _fadeSpeed * Time.deltaTime);
    }

    public void TrunOn()
    {
        if (_isActive == false)
        {
            _targetVolume = 5f;
            _audioSource.Play();

            _isActive = true;
        }
    }

    public void TrunOff()
    {
        if (_isActive)
        {
            _isActive = false;
            _targetVolume = 0f;
        }
    }
}

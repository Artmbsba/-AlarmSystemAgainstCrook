using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeSpeed = 0.25f;

    private float _targetVolume;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource.volume = 0f;
        _audioSource.loop = true;
    }

    public void TurnOn()
    {
        if (_audioSource.isPlaying == false)
        {

            _audioSource.Play();
        }

        _targetVolume = 1f;
        StartFade();
    }

    public void TurnOff()
    {
        _targetVolume = 0f;

        StartFade();
    }

    private void StartFade()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(FadeTo());
    }

    private IEnumerator FadeTo()
    {
        while (Mathf.Approximately(_audioSource.volume, _targetVolume) == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _fadeSpeed * Time.deltaTime);

            yield return null;
        }

        _audioSource.volume = _targetVolume;

        if (_targetVolume == 0f)
            _audioSource.Stop();
    }
}

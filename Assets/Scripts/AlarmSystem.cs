using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeSpeed = 0.25f;

    private Coroutine _coroutine;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private void Awake()
    {
        _audioSource.volume = 0f;
        _audioSource.loop = true;
    }

    public void TurnOn()
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        StartFade(_maxVolume);
    }

    public void TurnOff()
    {
        StartFade(_minVolume);
    }

    private void StartFade(float target)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(FadeTo(target));
    }

    private IEnumerator FadeTo(float target)
    {
        while (Mathf.Approximately(_audioSource.volume, target) == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _fadeSpeed * Time.deltaTime);

            yield return null;
        }

        _audioSource.volume = target;

        if (target == 0f)
            _audioSource.Stop();
    }
}

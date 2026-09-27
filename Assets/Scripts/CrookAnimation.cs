using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CrookAnimation : MonoBehaviour
{
    private readonly int SpeedHash = Animator.StringToHash("Speed");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(SpeedHash, speed);
    }
}

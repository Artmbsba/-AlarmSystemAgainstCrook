using UnityEngine;

public class Door : MonoBehaviour
{
    private readonly int IsOpenHash = Animator.StringToHash("IsOpen");

    [SerializeField] private Animator _animator;

    public bool IsOpen { get; private set; }

    public void Open()
    {
        IsOpen = true;
        _animator.SetBool(IsOpenHash, IsOpen);
    }

    public void Close()
    {
        IsOpen = false;
        _animator.SetBool(IsOpenHash, IsOpen);
    }
}
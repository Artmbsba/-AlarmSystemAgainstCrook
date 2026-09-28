using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour, IInteractable
{
    private readonly int IsOpenHash = Animator.StringToHash("IsOpen");

    private Animator _animator;

    public bool IsOpen { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (IsOpen)
            Close();
        else
            Open();
    }

    private void Open()
    {
        IsOpen = true;
        _animator.SetBool(IsOpenHash, IsOpen);
    }

    private void Close()
    {
        IsOpen = false;
        _animator.SetBool(IsOpenHash, IsOpen);
    }
}
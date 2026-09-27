using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(CrookAnimation))]
[RequireComponent(typeof(Rigidbody))]
public class Crook : MonoBehaviour
{
    private Mover _mover;
    private CrookAnimation _crookAnimation;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _crookAnimation = GetComponent<CrookAnimation>();
    }

    private void Update()
    {
        _mover.Rotate();
        _mover.Move();
        _crookAnimation.SetSpeed(_mover.CurrentSpeed);
    }
}

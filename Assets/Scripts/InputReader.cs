using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public event Action<Vector2> MoveInputChanged;
    public event Action Interacted;

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis(Horizontal),Input.GetAxis(Vertical));

        MoveInputChanged?.Invoke(input);

        if (Input.GetKeyDown(KeyCode.E))
            Interacted?.Invoke();
    }
}

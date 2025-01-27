using UnityEngine;

public interface IMovementInput {
    public Vector2 move { get; }
    public Vector2 look { get; }

    public void Disable();
    public void Enable();
}

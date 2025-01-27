using UnityEngine;

public class UIMovementInput : MonoBehaviour,IMovementInput {
    [SerializeField] Joystick _move, _look;
    
    public Vector2 move { get; private set; }
    public Vector2 look { get; private set; }

    void Update() {
        move = _move.Direction;
        look = _look.Direction;
    }

    public void Disable() {
        _move.gameObject.SetActive(false);
        _look.gameObject.SetActive(false);
    }

    public void Enable() {
        _move.gameObject.SetActive(true);
        _look.gameObject.SetActive(true);
    }
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : TakeableItem {
    [SerializeField] Rigidbody _rb;

    void OnValidate() {
        if (_rb) TryGetComponent(out _rb);
    }

    public override void Take() => _rb.useGravity = false;
    public override void Drop() => _rb.useGravity = true;
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    [SerializeField] LayerMask _itemsLayer;

    [SerializeField] Transform _holder;
    TakeableItem _heldObject;

    Coroutine _objectHolding;

    void Update() {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) 
            TryTake();
    }
    void TryTake() {
        Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        
        if (!Physics.Raycast(ray, out var hit, 3f, _itemsLayer)) return;
        if (!hit.transform.TryGetComponent(out TakeableItem item)) return;

        if (!_heldObject) {
            _heldObject = item;
            item.Take();
            _objectHolding = StartCoroutine(HoldObject());
        } else if (_heldObject == item) {
            StopCoroutine(_objectHolding);
            item.Drop();
            _heldObject = null;
        } else {
            _heldObject.Drop();
            item.Take();
            _heldObject = item;
        }
    }

    IEnumerator HoldObject() {
        while (true) {
            _heldObject.transform.position = Vector3.Lerp(_heldObject.transform.position, _holder.position, 0.2f);

            yield return null;
        }
    }
}


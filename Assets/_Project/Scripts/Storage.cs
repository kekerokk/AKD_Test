using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Storage : MonoBehaviour {
    [SerializeField] List<GameObject> _requiredItems;
    [SerializeField] List<GameObject> _storage;
    
    public event Action OnLoadComplete = delegate { };

    void OnTriggerEnter(Collider other) {
        _storage.Add(other.gameObject);

        CheckLoadStatus();
    }

    void CheckLoadStatus() {
        if(_storage.Count < _requiredItems.Count) return;
        
        if (_requiredItems.TrueForAll(x => _storage.Contains(x))) 
            OnLoadComplete.Invoke();
    }

    void OnTriggerExit(Collider other) {
        _storage.Remove(other.gameObject);
    }
}

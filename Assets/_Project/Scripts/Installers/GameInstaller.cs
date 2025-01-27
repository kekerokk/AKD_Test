using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public class GameInstaller : MonoInstaller {
    // Cant serialize interface with SerializeReference, idk why
    [SerializeReference] public IMovementInput movementInput;
    [SerializeField] UIMovementInput _movementInput;
    [SerializeField] Storage _storage;
    
    public override void InstallBindings() {
        BindInput();
        BindStorage();
    }
    
    void BindInput() => Container.Bind<IMovementInput>()
        .FromInstance(_movementInput)
        .AsSingle();
    
    void BindStorage() => Container.Bind<Storage>()
        .FromInstance(_storage)
        .AsSingle();
}

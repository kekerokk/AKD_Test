using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameHandler : MonoBehaviour {
    [SerializeField] GameUI _gameUI;
    [SerializeField] string _currentSceneName;
    
    [Inject]
    void Init(Storage storage, IMovementInput input) {
        storage.OnLoadComplete += RestartGame;
        storage.OnLoadComplete += input.Disable;
    }

    void RestartGame() {
        _gameUI.ShowCongrats();
        Invoke(nameof(ReloadLevel), 3f);
    }

    [ContextMenu(nameof(ReloadLevel))]
    void ReloadLevel() => SceneManager.LoadScene(_currentSceneName);
}

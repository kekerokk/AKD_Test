using UnityEngine;

public class GameUI : MonoBehaviour {
    [SerializeField] RectTransform _congratsPreview;

    void Awake() {
        _congratsPreview.gameObject.SetActive(false);
    }

    public void ShowCongrats() {
        _congratsPreview.gameObject.SetActive(true);
    }
}

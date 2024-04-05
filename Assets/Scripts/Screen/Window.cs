using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasdGroup;
    [SerializeField] private Button _buttonAction;

    protected CanvasGroup WindowGroup => _canvasdGroup;
    protected Button ButtonAction => _buttonAction;

    private void OnEnable() => _buttonAction.onClick.AddListener(OnClickButton);
    private void OnDisable() => _buttonAction.onClick.RemoveListener(OnClickButton);

    protected abstract void OnClickButton();

    public abstract void Open();

    public abstract void Close();
}

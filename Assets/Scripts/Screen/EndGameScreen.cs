using System;

public class EndGameScreen : Window
{
    public event Action RestartButtonClicked;

    public override void Open()
    {
        WindowGroup.alpha = 1;
        ButtonAction.interactable = true;
    }

    public override void Close()
    {
        WindowGroup.alpha = 0;
        ButtonAction.interactable = false;
    }

    protected override void OnClickButton() => RestartButtonClicked?.Invoke();
}

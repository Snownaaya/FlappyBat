using System;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

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

    protected override void OnClickButton() => PlayButtonClicked?.Invoke();
}

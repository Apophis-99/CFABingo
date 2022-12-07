using System.Collections.Generic;

namespace CFABingo.Utilities.Settings;

public struct JsonSettings
{
    public bool MainPanelShowButton;
    public bool MainPanelBallDoIdleAnimation;
    public int MainPanelIdleAnimationDelay;

    public List<int> MainWindowFullscreenBorderThickness;

    public bool CheckCloseWindowIfMidGame;

    public string CurrentTheme;
}

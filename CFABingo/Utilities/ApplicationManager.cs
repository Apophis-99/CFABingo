using CFABingo.Windows;

namespace CFABingo.Utilities;

public class ApplicationManager
{
    public readonly SettingsWindow SettingsWindow;
    public readonly DebugWindow DebugWindow;
    public readonly Settings.Settings CurrentSettings;

    public readonly Game CurrentGame;

    public ApplicationManager()
    {
        DebugWindow = new DebugWindow();
        
        CurrentSettings = new Settings.Settings();

        CurrentGame = new Game();
        
        SettingsWindow = new SettingsWindow();
    }
    
}

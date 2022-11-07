using CFABingo.Windows;

namespace CFABingo.Utilities;

public class ApplicationManager
{
    public Settings.Settings CurrentSettings;
    public SettingsWindow SettingsWindow;
    //public readonly DebugWindow DebugWindow;

    public readonly Game CurrentGame;

    public ApplicationManager()
    {
        //DebugWindow = new DebugWindow();
        
        CurrentSettings = new Settings.Settings();

        CurrentGame = new Game();
        
        SettingsWindow = new SettingsWindow();
    }
    
}

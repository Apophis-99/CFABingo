using System.Collections.Generic;

namespace CFABingo.Utilities.Settings;

public class Settings
{
    private readonly Dictionary<string, Theme> _themes; // All the themes available to the application - interchangeable in settings menu
    public Theme CurrentTheme; // The Current Theme being used

    public bool MainPanelShowButton; // Show or hide button on main panel

    public Settings()
    {
        _themes = new Dictionary<string, Theme>();
        foreach (var fileName in Files.GetFilesInDir("./Assets/Settings/Themes/"))
        {
            _themes.Add(fileName, new Theme().LoadTheme(fileName));
        }

        CurrentTheme = _themes["DefaultTheme"];
        LoadDefaultSettings();
    }

    private void LoadDefaultSettings()
    {
        CurrentTheme.Apply();

        MainPanelShowButton = false;
        
        Apply();
    }

    public void SwitchTheme(string id)
    {
        CurrentTheme = _themes[id];
        Apply();
    }
    
    public void Change(string id, dynamic val)
    {
        if (id.Contains("Colour"))
            CurrentTheme.GetType().GetField(id)?.SetValue(CurrentTheme, val);
        else
            GetType().GetField(id)?.SetValue(this, val);
    }

    public void Apply()
    {
        CurrentTheme.Apply();

        MainWindow.MainPanel.ShowButton = MainPanelShowButton;
    }
}

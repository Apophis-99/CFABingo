using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;

namespace CFABingo.Utilities.Settings;

public class Settings
{
    private readonly Dictionary<string, Theme> _themes; // All the themes available to the application - interchangeable in settings window
    public Theme CurrentTheme; // The Current Theme being used

    public bool MainPanelShowButton; // Show or hide button on main panel
    public bool MainPanelBallDoIdleAnimation = true; // Do the idle animation? - main panel sorts itself out no need to manage in settings
    public int MainPanelIdleAnimationDelay = 300; // The delay between each frame of animation - main panel sorts itself out no need to manage in settings
    
    public int MainWindowFullscreenBorderThicknessLeft; // Adjusts the border from the edge when in fullscreen mode (left)
    public int MainWindowFullscreenBorderThicknessTop; // Adjusts the border from the edge when in fullscreen mode (top)
    public int MainWindowFullscreenBorderThicknessRight; // Adjusts the border from the edge when in fullscreen mode (right)
    public int MainWindowFullscreenBorderThicknessBottom; // Adjusts the border from the edge when in fullscreen mode (bottom)

    public bool CheckCloseWindowIfMidGame; // Should the application check that you want to close the app when you are mid game
    
    public Settings()
    {
        _themes = new Dictionary<string, Theme>();
        foreach (var fileName in Files.GetFilesInDir("./Assets/Settings/Themes/"))
        {
            _themes.Add(fileName, new Theme().LoadTheme(fileName));
        }

        CurrentTheme = _themes["DefaultTheme"];
        LoadSettings();
    }

    private void LoadSettings()
    {
        var contents = Files.ReadSettingsFile();
        var json = JsonConvert.DeserializeObject<JsonSettings>(contents);

        MainPanelShowButton = json.MainPanelShowButton;
        MainPanelBallDoIdleAnimation = json.MainPanelBallDoIdleAnimation;
        MainPanelIdleAnimationDelay = json.MainPanelIdleAnimationDelay;

        var thickness = json.MainWindowFullscreenBorderThickness;
        MainWindowFullscreenBorderThicknessLeft = Convert.ToInt32(thickness[0]);
        MainWindowFullscreenBorderThicknessTop = Convert.ToInt32(thickness[1]);
        MainWindowFullscreenBorderThicknessRight = Convert.ToInt32(thickness[2]);
        MainWindowFullscreenBorderThicknessBottom = Convert.ToInt32(thickness[3]);

        CheckCloseWindowIfMidGame = json.CheckCloseWindowIfMidGame;
        
        SwitchTheme(json.CurrentTheme);

        Apply();
    }

    public void SaveSettings()
    {
        var newSettings = new JsonSettings
        {
        MainPanelShowButton = MainPanelShowButton,
        MainPanelBallDoIdleAnimation = MainPanelBallDoIdleAnimation,
        MainPanelIdleAnimationDelay = MainPanelIdleAnimationDelay,

        MainWindowFullscreenBorderThickness = new List<int> { MainWindowFullscreenBorderThicknessLeft, MainWindowFullscreenBorderThicknessTop, 
            MainWindowFullscreenBorderThicknessRight, MainWindowFullscreenBorderThicknessBottom },

        CurrentTheme = CurrentTheme.Identifier
        };
        var contents = JsonConvert.SerializeObject(newSettings);
        Files.WriteSettingsFile(contents);
    }

    public void SwitchTheme(string id)
    {
        CurrentTheme = _themes[id];
    }

    public bool ThemeDataAltered()
    {
        return _themes.Any(theme => theme.Value.HasChanged);
    }
    
    public void Change(string id, dynamic val)
    {
        if (id.Contains("Colour"))
        {
            /*if (!Equals(((SolidColorBrush) CurrentTheme.GetType().GetField(id)?.GetValue(CurrentTheme)!).Color, ((SolidColorBrush) val).Color) &&!CurrentTheme.HasChanged)
                CurrentTheme.HasChanged = true;*/
            CurrentTheme.GetType().GetField(id)?.SetValue(CurrentTheme, val);
        }
        else
            GetType().GetField(id)?.SetValue(this, val);
    }

    public void Apply()
    {
        CurrentTheme.Apply();

        MainWindow.MainPanel.ShowButton = MainPanelShowButton;
        ApplyBorderThickness(!MainWindow.IsFullscreen);
    }

    public void ApplyBorderThickness(bool zero = false)
    {
        if (!zero)
            Application.Current.Resources["MainWindowBorderThickness"] = new Thickness(MainWindowFullscreenBorderThicknessLeft, MainWindowFullscreenBorderThicknessTop, 
                MainWindowFullscreenBorderThicknessRight, MainWindowFullscreenBorderThicknessBottom);
        else
            Application.Current.Resources["MainWindowBorderThickness"] = new Thickness(0);
    }
}

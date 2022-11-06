using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Newtonsoft.Json;

namespace CFABingo.Utilities.Settings;

public class Theme
{
    public SolidColorBrush MainPanelBackgroundColour;
    public SolidColorBrush MainPanelButtonColour;
    public SolidColorBrush MainPanelButtonBorderColour;
    public SolidColorBrush MainPanelBallColour;
    public SolidColorBrush MainPanelBallTextColour;
    
    public SolidColorBrush RecentPanelBackgroundColour;
    public SolidColorBrush RecentPanelBallColour;
    public SolidColorBrush RecentPanelBallTextColour;

    public SolidColorBrush GameStatePanelBackgroundColour;
    public SolidColorBrush GameStatePanelUncalledBallColour;
    public SolidColorBrush GameStatePanelCalledBallColour;
    public SolidColorBrush GameStatePanelBallTextColour;

    public SolidColorBrush PanelHeaderColour;
    public SolidColorBrush PanelHeaderTextColour;

    public Theme()
    {
        var res = Application.Current.Resources;
        
        MainPanelBackgroundColour = (SolidColorBrush) res[nameof(MainPanelBackgroundColour)];
        MainPanelButtonColour = (SolidColorBrush) res[nameof(MainPanelButtonColour)];
        MainPanelButtonBorderColour = (SolidColorBrush) res[nameof(MainPanelButtonBorderColour)];
        MainPanelBallColour = (SolidColorBrush) res[nameof(MainPanelBallColour)];
        MainPanelBallTextColour = (SolidColorBrush) res[nameof(MainPanelBallTextColour)];
        
        RecentPanelBackgroundColour = (SolidColorBrush) res[nameof(RecentPanelBackgroundColour)];
        RecentPanelBallColour = (SolidColorBrush) res[nameof(RecentPanelBallColour)];
        RecentPanelBallTextColour = (SolidColorBrush) res[nameof(RecentPanelBallTextColour)];
        
        GameStatePanelBackgroundColour = (SolidColorBrush) res[nameof(GameStatePanelBackgroundColour)];
        GameStatePanelUncalledBallColour = (SolidColorBrush) res[nameof(GameStatePanelUncalledBallColour)];
        GameStatePanelCalledBallColour = (SolidColorBrush) res[nameof(GameStatePanelCalledBallColour)];
        GameStatePanelBallTextColour = (SolidColorBrush) res[nameof(GameStatePanelBallTextColour)];
        
        PanelHeaderColour = (SolidColorBrush) res[nameof(PanelHeaderColour)];
        PanelHeaderTextColour = (SolidColorBrush) res[nameof(PanelHeaderTextColour)];
        
        LoadTheme("DefaultTheme");
    }

    public Theme LoadTheme(string identifier)
    {
        JsonTheme json;
        try
        {
            var contents = File.ReadAllText("Assets/Settings/Themes/" + identifier + ".json");
            json = JsonConvert.DeserializeObject<JsonTheme>(contents);
        }
        catch (Exception)
        {
            //MainWindow.Manager.DebugWindow.Add(new DebugMessage($"Failed to translate {identifier}.json into a theme", DebugMessageLevel.Danger));
            return MainWindow.Manager.CurrentSettings.CurrentTheme;
        }

        MainPanelBackgroundColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.MainPanelBackgroundColour)!;
        MainPanelButtonColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.MainPanelButtonColour)!;
        MainPanelButtonBorderColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.MainPanelButtonBorderColour)!;
        MainPanelBallColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.MainPanelBallColour)!;
        MainPanelBallTextColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.MainPanelBallTextColour)!;
        
        RecentPanelBackgroundColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.RecentPanelBackgroundColour)!;
        RecentPanelBallColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.RecentPanelBallColour)!;
        RecentPanelBallTextColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.RecentPanelBallTextColour)!;

        GameStatePanelBackgroundColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.GameStatePanelBackgroundColour)!;
        GameStatePanelUncalledBallColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.GameStatePanelUncalledBallColour)!;
        GameStatePanelCalledBallColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.GameStatePanelCalledBallColour)!;
        GameStatePanelBallTextColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.GameStatePanelBallTextColour)!;

        PanelHeaderColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.PanelHeaderColour)!;
        PanelHeaderTextColour = (SolidColorBrush) new BrushConverter().ConvertFrom(json.PanelHeaderTextColour)!;

        return this;
    }
    
    public void Apply()
    {
        var theme = Application.Current.Resources;

        theme[nameof(MainPanelBackgroundColour)] = MainPanelBackgroundColour;
        theme[nameof(MainPanelButtonColour)] = MainPanelButtonColour;
        theme[nameof(MainPanelButtonBorderColour)] = MainPanelButtonBorderColour;
        theme[nameof(MainPanelBallColour)] = MainPanelBallColour;
        theme[nameof(MainPanelBallTextColour)] = MainPanelBallTextColour;
        
        theme[nameof(RecentPanelBackgroundColour)] = RecentPanelBackgroundColour;
        theme[nameof(RecentPanelBallColour)] = RecentPanelBallColour;
        theme[nameof(RecentPanelBallTextColour)] = RecentPanelBallTextColour;

        theme[nameof(GameStatePanelBackgroundColour)] = GameStatePanelBackgroundColour;
        theme[nameof(GameStatePanelUncalledBallColour)] = GameStatePanelUncalledBallColour;
        theme[nameof(GameStatePanelCalledBallColour)] = GameStatePanelCalledBallColour;
        theme[nameof(GameStatePanelBallTextColour)] = GameStatePanelBallTextColour;
        
        theme[nameof(PanelHeaderColour)] = PanelHeaderColour;
        theme[nameof(PanelHeaderTextColour)] = PanelHeaderTextColour;

        Application.Current.Resources = theme;
    }
}

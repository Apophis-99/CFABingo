using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CFABingo.Controls;
using CFABingo.Utilities;
using CFABingo.Utilities.Settings;

namespace CFABingo.Windows;

public partial class SettingsWindow
{
    public bool KeepHidden;

    private readonly List<SettingsOption> _options;
    
    public SettingsWindow()
    {
        InitializeComponent();
        KeepHidden = true;

        _options = new List<SettingsOption>();
        AddOptions();
    }

    #region Options

    private void AddOptions()
    {
        AddThemeOptions();
        AddPanelOptions();
    }

    private void AddThemeOptions()
    {
        foreach (var fileName in Files.GetFilesInDir("./Assets/Settings/Themes/").Where(fileName => fileName != "DefaultTheme"))
        {
            ThemesDropDown.Items.Add(fileName);
        }
        
        #region Main Panel

        ThemesTab.Children.Add(AddRegionHeader("Main Panel"));
        
        // Main Panel Background
        _options.Add(new SettingsOption
        {
            Title = "Panel Background",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelBackgroundColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelBackgroundColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());

        // Main Panel Button
        _options.Add(new SettingsOption
        {
            Title = "Panel Button",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelButtonColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelButtonColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Main Panel Button Border
        _options.Add(new SettingsOption
        {
            Title = "Panel Button Border",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelButtonBorderColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelButtonBorderColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Main Panel Ball
        _options.Add(new SettingsOption
        {
            Title = "Panel Ball",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelBallColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelBallColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Main Panel Ball Text
        _options.Add(new SettingsOption
        {
            Title = "Panel Ball Text",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelBallTextColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelBallTextColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        #endregion

        #region Recent Panel

        ThemesTab.Children.Add(AddRegionHeader("Recent Panel"));
        
        // Recent Panel Background
        _options.Add(new SettingsOption
        {
            Title = "Panel Background",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.RecentPanelBackgroundColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.RecentPanelBackgroundColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Recent Panel Ball
        _options.Add(new SettingsOption
        {
            Title = "Panel Ball",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.RecentPanelBallColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.RecentPanelBallColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Recent Panel Ball Text
        _options.Add(new SettingsOption
        {
            Title = "Panel Ball Text",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.RecentPanelBallTextColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.RecentPanelBallTextColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());

        #endregion

        #region Game State Panel

        ThemesTab.Children.Add(AddRegionHeader("Game State Panel"));
        
        // Game State Panel Background
        _options.Add(new SettingsOption
        {
            Title = "Panel Background",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelBackgroundColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelBackgroundColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());

        // Game State Panel Uncalled Ball
        _options.Add(new SettingsOption
        {
            Title = "Panel Uncalled Ball",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelUncalledBallColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelUncalledBallColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Game State Panel Called Ball
        _options.Add(new SettingsOption
        {
            Title = "Panel Called Ball",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelCalledBallColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelCalledBallColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Game State Panel Ball Text
        _options.Add(new SettingsOption
        {
            Title = "Panel Ball Text",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelBallTextColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelBallTextColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        #endregion

        #region Panel Header

        ThemesTab.Children.Add(AddRegionHeader("Panel Header"));
        
        // Panel Header
        _options.Add(new SettingsOption
        {
            Title = "Panel Header",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.PanelHeaderColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.PanelHeaderColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());

        // Panel Header
        _options.Add(new SettingsOption
        {
            Title = "Panel Header Text",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.PanelHeaderTextColour),
            DisplayValue = ((SolidColorBrush) Application.Current.Resources[nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.PanelHeaderTextColour)]).Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        #endregion
    }

    private void AddPanelOptions()
    {
        #region Main Panel

        PanelsTab.Children.Add(AddRegionHeader("Main Panel"));
        
        _options.Add(new SettingsOption
        {
            Title = "Show Button",
            Type = SettingsOptionType.Boolean,
            Bond = nameof(MainWindow.Manager.CurrentSettings.MainPanelShowButton),
            DisplayValue = MainWindow.MainPanel.ShowButton
        });
        PanelsTab.Children.Add(_options.Last());

        #endregion
    }

    private static Border AddRegionHeader(string title)
    {
        var border = new Border
        {
            Style = (Style) Application.Current.Resources["SettingsRegionHeader"]
        };
        var text = new TextBlock
        {
            Text = title
        };
        border.Child = text;

        return border;
    }

    #endregion

    #region Events

    private void Window_Closing(object? sender, CancelEventArgs e)
    {
        if (!KeepHidden) return;
        
        e.Cancel = true;
        Hide();
    }

    private void Apply_Clicked(object sender, RoutedEventArgs e)
    {
        foreach (var option in _options)
        {
            MainWindow.Manager.CurrentSettings.Change(option.Bond, option.Get());
        }
        MainWindow.Manager.CurrentSettings.Apply();
    }

    private void Cancel_Clicked(object sender, RoutedEventArgs e)
    {
        foreach (var option in _options)
        {
            option.Reset();
        }
        Hide();
    }
    
    private void ThemesDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //MainWindow.Manager.SwitchTheme(ThemesDropDown.Text);
    }

    #endregion
}

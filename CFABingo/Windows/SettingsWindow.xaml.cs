using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        
        ThemesDropDown.Items.Clear();
        ThemesDropDown.Items.Add("DefaultTheme");
        foreach (var fileName in Files.GetFilesInDir("./Assets/Settings/Themes/").Where(fileName => fileName != "DefaultTheme"))
        {
            ThemesDropDown.Items.Add(fileName);
        }
        
        ThemesDropDown.SelectedIndex = 0;
    }

    #region Options

    private void AddOptions()
    {
        GeneralTab.Children.Clear();
        ThemesTab.Children.Clear();
        PanelsTab.Children.Clear();

        AddGeneralOptions();
        AddThemeOptions();
        AddPanelOptions();
    }

    private void AddGeneralOptions()
    {
        GeneralTab.Children.Add(AddRegionHeader("Window Fullscreen Border"));

        /*_options.Add(new SettingsOption
        {
            Title = "Window Fullscreen Border",
            Warning = "Delicate Settings - Don't mess with this unless you understand what it does!",
            Type = SettingsOptionType.Integer,
            Bond = nameof(MainWindow.Manager.CurrentSettings.MainWindowFullscreenBorderThickness),
            DisplayValue = MainWindow.Manager.CurrentSettings.MainWindowFullscreenBorderThickness
        });
        GeneralTab.Children.Add(_options.Last());*/
        _options.Add(new SettingsOption
        {
            Title = "Window Fullscreen Border Left",
            Warning = "Delicate Settings - Don't mess with this unless you understand what it does!",
            Type = SettingsOptionType.Integer,
            Bond = nameof(MainWindow.Manager.CurrentSettings.MainWindowFullscreenBorderThicknessLeft),
            DisplayValue = MainWindow.Manager.CurrentSettings.MainWindowFullscreenBorderThicknessLeft
        });
        GeneralTab.Children.Add(_options.Last());
        _options.Add(new SettingsOption
        {
            Title = "Window Fullscreen Border Top",
            Warning = "Delicate Settings - Don't mess with this unless you understand what it does!",
            Type = SettingsOptionType.Integer,
            Bond = nameof(MainWindow.Manager.CurrentSettings.MainWindowFullscreenBorderThicknessTop),
            DisplayValue = MainWindow.Manager.CurrentSettings.MainWindowFullscreenBorderThicknessTop
        });
        GeneralTab.Children.Add(_options.Last());
        _options.Add(new SettingsOption
        {
            Title = "Window Fullscreen Border Right",
            Warning = "Delicate Settings - Don't mess with this unless you understand what it does!",
            Type = SettingsOptionType.Integer,
            Bond = nameof(MainWindow.Manager.CurrentSettings.MainWindowFullscreenBorderThicknessRight),
            DisplayValue = MainWindow.Manager.CurrentSettings.MainWindowFullscreenBorderThicknessRight
        });
        GeneralTab.Children.Add(_options.Last());
        _options.Add(new SettingsOption
        {
            Title = "Window Fullscreen Border Bottom",
            Warning = "Delicate Settings - Don't mess with this unless you understand what it does!",
            Type = SettingsOptionType.Integer,
            Bond = nameof(MainWindow.Manager.CurrentSettings.MainWindowFullscreenBorderThicknessBottom),
            DisplayValue = MainWindow.Manager.CurrentSettings.MainWindowFullscreenBorderThicknessBottom
        });
        GeneralTab.Children.Add(_options.Last());

        GeneralTab.Children.Add(AddRegionHeader("Closing Dialogs"));
        
        _options.Add(new SettingsOption
        {
            Title = "Confirm Close When Mid Game",
            Type = SettingsOptionType.Boolean,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CheckCloseWindowIfMidGame),
            DisplayValue = MainWindow.Manager.CurrentSettings.CheckCloseWindowIfMidGame
        });
        GeneralTab.Children.Add(_options.Last());
    }
    
    private void AddThemeOptions()
    {
        #region Main Panel

        ThemesTab.Children.Add(AddRegionHeader("Main Panel"));

        // Main Panel Background
        _options.Add(new SettingsOption
        {
            Title = "Panel Background",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelBackgroundColour),
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelBackgroundColour.Color
        });
        ThemesTab.Children.Add(_options.Last());

        // Main Panel Button
        _options.Add(new SettingsOption
        {
            Title = "Panel Button",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelButtonColour),
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelButtonColour.Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Main Panel Button Border
        _options.Add(new SettingsOption
        {
            Title = "Panel Button Border",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelButtonBorderColour),
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelButtonBorderColour.Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Main Panel Ball
        _options.Add(new SettingsOption
        {
            Title = "Panel Ball",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelBallColour),
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelBallColour.Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Main Panel Ball Text
        _options.Add(new SettingsOption
        {
            Title = "Panel Ball Text",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelBallTextColour),
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.MainPanelBallTextColour.Color
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
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.RecentPanelBackgroundColour.Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Recent Panel Ball
        _options.Add(new SettingsOption
        {
            Title = "Panel Ball",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.RecentPanelBallColour),
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.RecentPanelBallColour.Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Recent Panel Ball Text
        _options.Add(new SettingsOption
        {
            Title = "Panel Ball Text",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.RecentPanelBallTextColour),
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.RecentPanelBallTextColour.Color
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
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelBackgroundColour.Color
        });
        ThemesTab.Children.Add(_options.Last());

        // Game State Panel Uncalled Ball
        _options.Add(new SettingsOption
        {
            Title = "Panel Uncalled Ball",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelUncalledBallColour),
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelUncalledBallColour.Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Game State Panel Called Ball
        _options.Add(new SettingsOption
        {
            Title = "Panel Called Ball",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelCalledBallColour),
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelCalledBallColour.Color
        });
        ThemesTab.Children.Add(_options.Last());
        
        // Game State Panel Ball Text
        _options.Add(new SettingsOption
        {
            Title = "Panel Ball Text",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelBallTextColour),
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.GameStatePanelBallTextColour.Color
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
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.PanelHeaderColour.Color
        });
        ThemesTab.Children.Add(_options.Last());

        // Panel Header
        _options.Add(new SettingsOption
        {
            Title = "Panel Header Text",
            Type = SettingsOptionType.Colour,
            Bond = nameof(MainWindow.Manager.CurrentSettings.CurrentTheme.PanelHeaderTextColour),
            DisplayValue = MainWindow.Manager.CurrentSettings.CurrentTheme.PanelHeaderTextColour.Color
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
        
        _options.Add(new SettingsOption
        {
            Title = "Do Idle Animation",
            Type = SettingsOptionType.Boolean,
            Bond = nameof(MainWindow.Manager.CurrentSettings.MainPanelBallDoIdleAnimation),
            DisplayValue = MainWindow.Manager.CurrentSettings.MainPanelBallDoIdleAnimation
        });
        PanelsTab.Children.Add(_options.Last());
        
        _options.Add(new SettingsOption
        {
            Title = "Idle Animation Frame Delay",
            Type = SettingsOptionType.Integer,
            Bond = nameof(MainWindow.Manager.CurrentSettings.MainPanelIdleAnimationDelay),
            DisplayValue = MainWindow.Manager.CurrentSettings.MainPanelIdleAnimationDelay
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
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (MainWindow.Manager == null) return;

        MainWindow.Manager.CurrentSettings.SwitchTheme(ThemesDropDown.SelectedItem.ToString());
        AddOptions();
    }
    
    private void Window_OnVisibilityChange(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (Visibility != Visibility.Hidden)
            AddOptions();
        
        ThemesDropDown.SelectedIndex = ThemesDropDown.Items.IndexOf(MainWindow.Manager.CurrentSettings.CurrentTheme.Identifier);
    }

    #endregion
}

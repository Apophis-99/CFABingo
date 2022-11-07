using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CFABingo.Panels;
using CFABingo.Utilities;

namespace CFABingo;

public partial class MainWindow
{
    #region Commands

    private static readonly RoutedCommand OpenSettingsCommand = new();
    private static readonly RoutedCommand OpenDebugCommand = new();
    private static readonly RoutedCommand ToggleFullscreenCommand = new();
    private static readonly RoutedCommand GetNextNumberCommand = new();

    private static readonly RoutedCommand NewGameCommand = new();

    private void InitCommands()
    {
        // Setup key commands
        OpenSettingsCommand.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Alt));
        OpenDebugCommand.InputGestures.Add(new KeyGesture(Key.D, ModifierKeys.Control | ModifierKeys.Alt));
        ToggleFullscreenCommand.InputGestures.Add(new KeyGesture(Key.F5));
        GetNextNumberCommand.InputGestures.Add(new KeyGesture(Key.Enter));
        GetNextNumberCommand.InputGestures.Add(new KeyGesture(Key.Space));
        NewGameCommand.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control));

        // Bind key commands
        CommandBindings.Add(new CommandBinding(OpenSettingsCommand, OpenSettings));
        CommandBindings.Add(new CommandBinding(OpenDebugCommand, OpenDebug));
        CommandBindings.Add(new CommandBinding(ToggleFullscreenCommand, ToggleFullscreen));
        CommandBindings.Add(new CommandBinding(GetNextNumberCommand, GetNextNumber));
        CommandBindings.Add(new CommandBinding(NewGameCommand, Manager.CurrentGame.Reset));
    }
    
    #endregion

    #region Panels

    public static readonly MainPanel MainPanel = new();
    public static readonly RecentPanel RecentPanel = new();
    public static readonly GameStatePanel GameStatePanel = new() { Orientation = Orientation.Vertical };

    #endregion
    
    // Window States
    private WindowState _oldWindowState;
    private bool _isFullscreen;

    // Manager
    public static readonly ApplicationManager Manager = new();
    
    public MainWindow()
    {
        InitializeComponent();

        _oldWindowState = WindowState;
        _isFullscreen = false;

        // Add panels
        Grid.SetColumn(MainPanel, 0);
        Grid.SetRow(MainPanel, 0);
        Layout.Children.Add(MainPanel);
        
        Grid.SetColumn(RecentPanel, 0);
        Grid.SetRow(RecentPanel, 2);
        Layout.Children.Add(RecentPanel);
        
        Grid.SetColumn(GameStatePanel, 2);
        Grid.SetRow(GameStatePanel, 0);
        Grid.SetRowSpan(GameStatePanel, 3);
        Layout.Children.Add(GameStatePanel);

        InitCommands();
    }

    #region CommandFunctions

    private static void OpenSettings(object sender, ExecutedRoutedEventArgs e)
    {
        Manager.SettingsWindow.Show();
    }

    private static void OpenDebug(object sender, ExecutedRoutedEventArgs e)
    {
        //Manager.DebugWindow.Show();
    }
        
    private void ToggleFullscreen(object sender, ExecutedRoutedEventArgs e)
    {
        if (!_isFullscreen)
        {
            _oldWindowState = WindowState;
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            BorderThickness = new Thickness(8);

            _isFullscreen = true;
        }
        else
        {
            WindowState = _oldWindowState;
            WindowStyle = WindowStyle.SingleBorderWindow;
            ResizeMode = ResizeMode.CanResize;
            BorderThickness = new Thickness(0);

            _isFullscreen = false;
        }
    }

    private static void GetNextNumber(object sender, ExecutedRoutedEventArgs e)
    {
        Manager.CurrentGame.GetNext();
    }

    #endregion

    #region WindowEvents

    private void Window_UnLoaded(object sender, RoutedEventArgs e)
    {
        Manager.SettingsWindow.KeepHidden = false;
        Manager.SettingsWindow.Close();
        //Manager.DebugWindow.Close();
        
        Manager.CurrentSettings.SaveSettings();
    }

    #endregion
    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CFABingo.Controls;
using CFABingo.Panels;
using CFABingo.Utilities;

namespace CFABingo;

public sealed partial class MainWindow
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
    public static readonly RecentPanel RecentPanel = new() { Orientation = Orientation.Horizontal };
    public static readonly GameStatePanel GameStatePanel = new() { Orientation = Orientation.Vertical };
    
    // Grid splitters
    public static readonly GridSplitter HorizontalSplitter = new()
    {
        HorizontalAlignment = HorizontalAlignment.Stretch,
        VerticalAlignment = VerticalAlignment.Stretch,
        ResizeDirection = GridResizeDirection.Rows
    };

    public static readonly GridSplitter VerticalSplitter = new()
    {
        HorizontalAlignment = HorizontalAlignment.Stretch,
        VerticalAlignment = VerticalAlignment.Stretch,
        ResizeDirection = GridResizeDirection.Columns
    };

    #endregion

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
        
        // Add Grid Splitters
        Grid.SetColumn(HorizontalSplitter, 0);
        Grid.SetRow(HorizontalSplitter, 1);
        Layout.Children.Add(HorizontalSplitter);
        
        Grid.SetColumn(VerticalSplitter, 1);
        Grid.SetRow(VerticalSplitter, 0);
        Grid.SetRowSpan(VerticalSplitter, 3);
        Layout.Children.Add(VerticalSplitter);
        
        // Init dialog box
        _dialogBox = new DialogBox
        {
            Visibility = Visibility.Collapsed
        };
        
        // Register commands
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
    
    
    // Window States
    private WindowState _oldWindowState;
    private bool _isFullscreen;
    
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
    
    private void Window_Closing(object? sender, CancelEventArgs e)
    {
        if (_finishedDialogs)
        {
            if (_shouldClose)
                return;
            _finishedDialogs = false;
            _finishedMidGameCloseCheck = false;
            _finishedSaveAlteredThemeCheck = false;
            e.Cancel = true;
            return;
        }

        e.Cancel = true;

        if (_dialogBox.Visibility == Visibility.Visible) return;

        if (Manager.CurrentSettings.CheckCloseWindowIfMidGame && Manager.CurrentGame.CurrentNumber != 0 && !_finishedMidGameCloseCheck)
        {
            _finishedMidGameCloseCheck = true;
            InvokeDialogBox("You are mid game! Are you sure you want to close the application?",
                new List<string> { "Yes", "No" }, (_, _) =>
                {
                    switch (_dialogBox.SelectedOption)
                    {
                        case "Yes":
                            _shouldClose = true;
                            break;
                        case "No":
                            _shouldClose = false;
                            _finishedDialogs = true;
                            break;
                    }
                    _dialogBox.Visibility = Visibility.Collapsed;
                    Close();
                });
        }
        else if (Manager.CurrentSettings.ThemeDataAltered() && !_finishedSaveAlteredThemeCheck)
        {
            _finishedSaveAlteredThemeCheck = true;
            InvokeDialogBox("You have altered theme data. Would you like to save your changes?",
                new List<string> { "Save", "Discard", "Cancel" }, (_, _) =>
                {
                    switch (_dialogBox.SelectedOption)
                    {
                        case "Save":
                            _shouldClose = true;
                            break;
                        case "Discard":
                            _shouldClose = true;
                            break;
                        case "Cancel":
                            _shouldClose = false;
                            _finishedDialogs = true;
                            break;
                    }
                    _dialogBox.Visibility = Visibility.Collapsed;
                    _finishedDialogs = true;
                    Close();
                });
        }
        else
        {
            e.Cancel = false;
        }
    }

    #region Window Closing Checks

    // Dialog
    private DialogBox _dialogBox;
    private bool _shouldClose;
    private bool _finishedDialogs;
    
    private bool _finishedMidGameCloseCheck;
    private bool _finishedSaveAlteredThemeCheck;
    
    private void InvokeDialogBox(string msg, List<string> buttons, EventHandler handler)
    {
        _dialogBox = new DialogBox
        {
            Message = msg,
            ButtonOptions = buttons,
            Visibility = Visibility.Visible
        };
        _dialogBox.OptionChosen += handler;
        
        RemoveLogicalChild(_dialogBox);
        
        Grid.SetColumn(_dialogBox, 0);
        Grid.SetColumnSpan(_dialogBox, 3);
        Grid.SetRow(_dialogBox, 0);
        Grid.SetRowSpan(_dialogBox, 3);
        Layout.Children.Add(_dialogBox);
    }
    
    #endregion
    
    #endregion
}

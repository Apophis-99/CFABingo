using System.Windows;
using System.Windows.Input;
using CFABingo.Utilities;
using CFABingo.Utilities.Debug;

namespace CFABingo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static readonly RoutedCommand OpenSettingsCommand = new();
        private static readonly RoutedCommand OpenDebugCommand = new();
        private static readonly RoutedCommand ToggleFullscreenCommand = new();
        private static readonly RoutedCommand OpenMenuCommand = new();
        private static readonly RoutedCommand GetNextNumberCommand = new();

        public static Game CurrentGame;
        public static Settings Settings;
        public static SettingsWindow SettingsWindow;
        public static DebugWindow DebugWindow;

        private WindowState _oldWindowState;
        private bool _isFullscreen;
        
        public MainWindow()
        {
            InitializeComponent();

            _oldWindowState = WindowState;
            _isFullscreen = false;
            CurrentGame = new Game();

            Settings = new Settings();
            SettingsWindow = new SettingsWindow();
            DebugWindow = new DebugWindow();
            
            // Setup key commands
            OpenSettingsCommand.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Alt));
            OpenDebugCommand.InputGestures.Add(new KeyGesture(Key.D, ModifierKeys.Control | ModifierKeys.Alt));
            ToggleFullscreenCommand.InputGestures.Add(new KeyGesture(Key.F5));
            OpenMenuCommand.InputGestures.Add(new KeyGesture(Key.Escape));
            GetNextNumberCommand.InputGestures.Add(new KeyGesture(Key.Enter));

            // Bind key commands
            CommandBindings.Add(new CommandBinding(OpenSettingsCommand, OpenSettings));
            CommandBindings.Add(new CommandBinding(OpenDebugCommand, OpenDebug));
            CommandBindings.Add(new CommandBinding(ToggleFullscreenCommand, ToggleFullscreen));
            CommandBindings.Add(new CommandBinding(OpenMenuCommand, Menu.ToggleMenuVisible));
            CommandBindings.Add(new CommandBinding(GetNextNumberCommand, GetNextNumber));
        }

        private static void OpenSettings(object sender, ExecutedRoutedEventArgs e)
        {
            SettingsWindow.Show();
        }

        private static void OpenDebug(object sender, ExecutedRoutedEventArgs e)
        {
            DebugWindow.Show();
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

        private void GetNextNumber(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentGame.GetNext();
            MainPanel.DisplayNumber = CurrentGame.CurrentNumber;
        }
    }
}

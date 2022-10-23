using System.Windows;
using System.Windows.Input;

namespace CFABingo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static readonly RoutedCommand OpenSettingsCommand = new();
        private static readonly RoutedCommand ToggleFullscreenCommand = new();

        private WindowState _oldWindowState;
        private bool _isFullscreen;
        
        public MainWindow()
        {
            InitializeComponent();

            _oldWindowState = this.WindowState;
            _isFullscreen = false;
            
            // Setup key commands
            OpenSettingsCommand.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Alt));
            ToggleFullscreenCommand.InputGestures.Add(new KeyGesture(Key.F5));

            CommandBindings.Add(new CommandBinding(OpenSettingsCommand, OpenSettings));
            CommandBindings.Add(new CommandBinding(ToggleFullscreenCommand, ToggleFullscreen));
        }

        private static void OpenSettings(object sender, ExecutedRoutedEventArgs e)
        {
            var settingsWindow = new SettingsWindow();
            settingsWindow.Show();
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
    }
}

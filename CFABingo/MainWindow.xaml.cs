using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CFABingo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static readonly RoutedCommand OpenSettingsCommand = new RoutedCommand();
        
        public MainWindow()
        {
            InitializeComponent();
            
            // Setup key commands
            OpenSettingsCommand.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Alt));

            CommandBindings.Add(new CommandBinding(OpenSettingsCommand, OpenSettings));
        }

        private void OpenSettings(object sender, ExecutedRoutedEventArgs e)
        {
            var settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }
    }
}

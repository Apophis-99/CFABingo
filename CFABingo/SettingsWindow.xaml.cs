using System.Windows;
using System.Windows.Media;
using CFABingo.Utilities;

namespace CFABingo;

public partial class SettingsWindow
{
    
    public SettingsWindow()
    {
        InitializeComponent();
    }

    private void InitialiseSettings()
    {
        
    }

    private void Apply_Clicked(object sender, RoutedEventArgs e)
    {
        // Theme
        MainWindow.Settings.PrimaryColour = new SolidColorBrush(PrimaryColour.Get());
        MainWindow.Settings.SecondaryColour = new SolidColorBrush(SecondaryColour.Get());
        MainWindow.Settings.TertiaryColour = new SolidColorBrush(TertiaryColour.Get());
        
        // Panels
        MainWindow.Settings.MainPanelShowButton = MainPanelVisible.Get();
        
        MainWindow.Settings.UpdateSettings();
    }
}

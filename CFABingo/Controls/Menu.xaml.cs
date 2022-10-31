using System.Windows;
using System.Windows.Input;

namespace CFABingo.Controls;

public partial class Menu
{
    public Menu()
    {
        InitializeComponent();
    }
    
    public void ToggleMenuVisible(object sender, ExecutedRoutedEventArgs e)
    {
        MainMenu.Visibility = MainMenu.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
    }
    
}

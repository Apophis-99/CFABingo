using System.Windows;

namespace CFABingo.Utilities.Debug;

public partial class DebugWindow : Window
{
    public DebugWindow()
    {
        InitializeComponent();
    }

    public void Add(DebugMessage msg)
    {
        Panel.Children.Add(msg.Output());
    }
}

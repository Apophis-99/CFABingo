using System.Collections.Generic;
using System.Windows;
using CFABingo.Utilities;

namespace CFABingo.Windows;

public partial class DebugWindow
{
    private readonly List<DebugMessage> _messages;
    
    public DebugWindow()
    {
        InitializeComponent();

        _messages = new List<DebugMessage>();
    }

    public void Add(DebugMessage msg)
    {
        _messages.Add(msg);

        if (IsLoaded)
            Panel.Children.Add(msg.Output());
    }


    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (var message in _messages)
        {
            Panel.Children.Add(message.Output());
        }
    }

    private void Window_UnLoaded(object sender, RoutedEventArgs e)
    {
        Panel.Children.Clear();
    }
}

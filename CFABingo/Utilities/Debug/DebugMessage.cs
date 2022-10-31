using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CFABingo.Utilities.Debug;

public enum DebugMessageLevel
{
    Normal,
    Warning,
    Danger
}

public struct DebugMessage
{
    private string _message;
    private DateTime _dateTime;
    private DebugMessageLevel _level;
    
    public string Message => _message;
    public DateTime DateTime => _dateTime;
    public DebugMessageLevel DebugLevel => _level;

    public DebugMessage(string message, DebugMessageLevel level = DebugMessageLevel.Normal)
    {
        _message = message;
        _dateTime = DateTime.Now;
        _level = level;
    }

    public Grid Output()
    {
        // Setup grid with columns
        var grid = new Grid();

        var col1 = new ColumnDefinition
        {
            Width = GridLength.Auto
        };
        var col2 = new ColumnDefinition
        {
            
        };
        var col3 = new ColumnDefinition
        {
            Width = GridLength.Auto
        };

        grid.ColumnDefinitions.Add(col1);
        grid.ColumnDefinitions.Add(col2);
        grid.ColumnDefinitions.Add(col3);

        // Add text blocks
        var messageTxt = new TextBlock
        {
            Text = Message
        };
        var dateTxt = new TextBlock
        {
            Text = DateTime.ToLongDateString()
        };
        
        Grid.SetColumn(messageTxt, 0);
        Grid.SetColumn(dateTxt, 2);

        grid.Children.Add(messageTxt);
        grid.Children.Add(dateTxt);
        
        // Style grid
        grid.Background = new SolidColorBrush(DebugLevel switch
        {
            DebugMessageLevel.Warning => Colors.Yellow,
            DebugMessageLevel.Danger => Colors.Red,
            _ => Colors.White
        });

        return grid;
    }
}

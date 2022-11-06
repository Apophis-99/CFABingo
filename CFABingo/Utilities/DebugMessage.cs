using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CFABingo.Utilities;

public enum DebugMessageLevel
{
    Normal,
    Warning,
    Danger
}

public readonly struct DebugMessage
{
    private readonly string _message;
    private readonly DateTime _dateTime;
    private readonly DebugMessageLevel _level;

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
        var col2 = new ColumnDefinition();
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
            Text = _message
        };
        var dateTxt = new TextBlock
        {
            Text = _dateTime.ToLongDateString()
        };
        
        Grid.SetColumn(messageTxt, 0);
        Grid.SetColumn(dateTxt, 2);

        grid.Children.Add(messageTxt);
        grid.Children.Add(dateTxt);
        
        // Style grid
        grid.Background = new SolidColorBrush(_level switch
        {
            DebugMessageLevel.Warning => Colors.Yellow,
            DebugMessageLevel.Danger => Colors.Red,
            _ => Colors.White
        });

        return grid;
    }
}

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace CFABingo.Panels;

public partial class GameStatePanel
{
    private readonly List<Grid> _balls;

    private Orientation _orientation = Orientation.Vertical;

    public Orientation Orientation
    {
        get => _orientation;
        set { _orientation = value; SwitchOrientation(); }
    }
    
    public GameStatePanel()
    {
        InitializeComponent();

        _balls = new List<Grid>();
        
        //SwitchOrientation();
        
        PopulatePanel();
    }

    private void SwitchOrientation()
    {
        DisplayGrid = new Grid();

        for (var i = 0; i < 6; i++)
        {
            if (Orientation == Orientation.Vertical)
            {
                var col = new ColumnDefinition();
                DisplayGrid.ColumnDefinitions.Add(col);
            }
            else
            {
                var row = new RowDefinition();
                DisplayGrid.RowDefinitions.Add(row);
            }
        }
        for (var i = 0; i < 15; i++)
        {
            if (Orientation == Orientation.Vertical)
            {
                var row = new RowDefinition();
                DisplayGrid.RowDefinitions.Add(row);
            }
            else
            {
                var col = new ColumnDefinition();
                DisplayGrid.ColumnDefinitions.Add(col);
            }
        }

        Header.Orientation = Orientation;
    }

    private void PopulatePanel()
    {
        DisplayGrid.Children.Clear();
        var count = 0;
        for (var r = 0; r < (Orientation == Orientation.Horizontal ? 6 : 15); r++)
        {
            for (var c = 0; c < (Orientation == Orientation.Horizontal ? 15 : 6); c++)
            {
                var ball = new Grid();
                var ellipse = new Ellipse();
                var text = new TextBlock
                {
                    Text = (count + 1).ToString()
                };
                ball.Children.Add(ellipse);
                ball.Children.Add(text);
                
                DisplayGrid.Children.Add(ball);
                Grid.SetRow(ball, r);
                Grid.SetColumn(ball, c);
                _balls.Add(ball);
                
                count++;
            }
        }
    }

    public void UpdateBall(int num)
    {
        ((Ellipse)_balls[num - 1].Children[0]).Style = (Style) Application.Current.Resources["GameStatePanelBallEllipseCalled"];;
    }

    public void Reset()
    {
        foreach (var ball in _balls)
        {
            ((Ellipse)ball.Children[0]).Style = (Style) Application.Current.Resources["GameStatePanelBallEllipseUncalled"];
        }
    }

    private void Panel_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        foreach (var ball in _balls)
        {
            var margin = ball.Margin.Top;
            
            ((Ellipse)ball.Children[0]).Width = (ball.ActualHeight < ball.ActualWidth) ? ball.ActualHeight - margin : ball.ActualWidth - margin;
            ((Ellipse)ball.Children[0]).Height = (ball.ActualHeight < ball.ActualWidth) ? ball.ActualHeight - margin : ball.ActualWidth - margin;

            ((TextBlock)ball.Children[1]).FontSize = ball.ActualHeight / 2 - 2;
        }
    }
}

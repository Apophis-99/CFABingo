using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace CFABingo.Panels;

public partial class RecentPanel
{
    private Orientation _orientation = Orientation.Horizontal;
    private bool _collapsed;
    private Vector2 _expandedSize;

    public Orientation Orientation
    {
        get => _orientation;
        set { _orientation = value; SwitchOrientation(); }
    }

    public bool Collapsed
    {
        get => _collapsed;
        set { _collapsed = value; if (_collapsed) CollapsePanel(); else ExpandPanel(); }
    }

    public RecentPanel()
    {
        InitializeComponent();
    }

    public void Add(int num)
    {
        var ball = new Grid();

        var ellipse = new Ellipse();
        var textBlock = new TextBlock
        {
            Text = num.ToString()
        };

        ball.Children.Add(ellipse);
        ball.Children.Add(textBlock);

        Panel.Children.Insert(0, ball);
    }

    private void SwitchOrientation()
    {
        if (Orientation == Orientation.Horizontal)
        {
            ScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            ScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }
        else
        {
            ScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            ScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        Panel.Orientation = Orientation;
    }

    public void Reset()
    {
        Panel.Children.Clear();
    }
    
    private void UpdatePanelSize()
    {
        if (Orientation == Orientation.Horizontal)
        {
            ((Grid)LogicalTreeHelper.GetParent(this)).RowDefinitions[2].Height = new GridLength(_expandedSize.Y);
            Height = ((Grid)LogicalTreeHelper.GetParent(this)).Height;
        }
        else
        {
            ((Grid)LogicalTreeHelper.GetParent(this)).ColumnDefinitions[2].Width = new GridLength(_expandedSize.X);
            Width = ((Grid)LogicalTreeHelper.GetParent(this)).Width;
        }
    }

    private void CollapsePanel()
    {
        _expandedSize = new Vector2((float) ActualWidth, (float) ActualHeight);
        if (Orientation == Orientation.Horizontal)
        {
            ScrollViewer.Visibility = Visibility.Collapsed;
            Height = Header.ActualHeight;
            ((Grid)LogicalTreeHelper.GetParent(this)).RowDefinitions[2].Height = new GridLength(Height);
            MainWindow.HorizontalSplitter.IsEnabled = false;
        }
        else
        {
            ScrollViewer.Visibility = Visibility.Collapsed;
            Width = Header.ActualHeight;
            ((Grid)LogicalTreeHelper.GetParent(this)).ColumnDefinitions[2].Width = new GridLength(Width);
            MainWindow.VerticalSplitter.IsEnabled = false;
        }
    }
    
    private void ExpandPanel()
    {
        if (Orientation == Orientation.Horizontal)
        {
            //ScrollViewer.Height = _expandedSize.Y;
            ScrollViewer.Visibility = Visibility.Visible;
            MainWindow.HorizontalSplitter.IsEnabled = true;
            //Height = _expandedWidth.Y;
        }
        else
        {
            ScrollViewer.Visibility = Visibility.Visible;
            MainWindow.VerticalSplitter.IsEnabled = true;
            //Width = _expandedWidth.X;
        }
        UpdatePanelSize();
    }

}

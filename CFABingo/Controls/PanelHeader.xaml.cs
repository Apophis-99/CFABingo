using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CFABingo.Controls;

public partial class PanelHeader
{
    private bool _collapsed;
    
    private string _title = "<PanelTitle>";
    private Orientation _orientation = Orientation.Vertical;

    public string Title
    {
        get => _title;
        set 
        { 
            _title = value;
            TitleText.Text = _title;
        }
    }
    public Orientation Orientation
    {
        get => _orientation;
        set { _orientation = value; UpdateOrientation(); }
    }

    public bool Collapsed
    {
        get => _collapsed;
        set 
        {
            _collapsed = value; UpdateOrientation();
            if (Title == "Recent")
                MainWindow.RecentPanel.Collapsed = Collapsed;
            else
                MainWindow.GameStatePanel.Collapsed = Collapsed;
        }
    }

    public PanelHeader()
    {
        InitializeComponent();
    }

    private void UpdateOrientation()
    {
        BitmapImage bitmapImage = new();
        
        bitmapImage.BeginInit();
        bitmapImage.UriSource = new Uri("/Assets/CollapseIcon.png", UriKind.Relative);
        
        if (_orientation == Orientation.Vertical)
            bitmapImage.Rotation = _collapsed ? Rotation.Rotate90 : Rotation.Rotate270;
        else
            bitmapImage.Rotation = _collapsed ? Rotation.Rotate180 : Rotation.Rotate0;
        
        bitmapImage.EndInit();

        Icon.Source = bitmapImage;
    }

    private void CollapseButtonOnClick(object sender, RoutedEventArgs e)
    {
        Collapsed = !Collapsed;
        /*if (Collapsed)
        {
            if (Orientation == Orientation.Vertical)
            {
                Grid.SetRow(TitleText, 1);
                Grid.SetColumn(TitleText, 0);
                Grid.SetColumnSpan(TitleText, 1);
                TitleText.Margin = new Thickness(0, 10, 0, 0);
                TitleTextTransform.Angle = 90;
            }
        }
        else
        {
            if (Orientation == Orientation.Vertical)
            {
                Grid.SetRow(TitleText, 0);
                Grid.SetColumn(TitleText, 1);
                Grid.SetColumnSpan(TitleText, 1);
                TitleText.Margin = new Thickness(0, 0, 0, 0);
                TitleTextTransform.Angle = 0;
            }
        }*/
    }

    private void Header_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        /*var width = 0;
        if (!Collapsed)
            width = (int) ActualWidth;
        else
            width = (int) ActualHeight;
        TitleText.Width = width;*/
    }
}

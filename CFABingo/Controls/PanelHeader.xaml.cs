using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CFABingo.Controls;

public partial class PanelHeader
{
    private bool _collapsed = false;
    
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
        set { _collapsed = value; UpdateOrientation(); }
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
    }
}

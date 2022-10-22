using System.Windows;
using System.Windows.Controls;

namespace CFABingo.Controls;

public partial class PanelHeader
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(PanelHeader));
    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(PanelHeader));

    public string Title
    {
        get => (string) GetValue(TitleProperty);
        set 
        { 
            SetValue(TitleProperty, value);
            TitleText.Text = Title;
        }
    }
    public Orientation Orientation
    {
        get => (Orientation)GetValue(OrientationProperty);
        set => SetValue(TitleProperty, value);
    }
    
    public PanelHeader()
    {
        InitializeComponent();
        TitleText.Text = Title;
    }
}

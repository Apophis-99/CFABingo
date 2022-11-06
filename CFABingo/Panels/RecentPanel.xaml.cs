using System.Windows.Controls;
using System.Windows.Shapes;

namespace CFABingo.Panels;

public partial class RecentPanel
{
    public bool Collapsed;
    
    private Orientation _orientation = Orientation.Horizontal;

    public Orientation Orientation
    {
        get => _orientation;
        set { _orientation = value; SwitchOrientation(); }
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
        ScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
        ScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;

        Panel.Orientation = Orientation;
    }

    public void Reset()
    {
        Panel.Children.Clear();
    }
}

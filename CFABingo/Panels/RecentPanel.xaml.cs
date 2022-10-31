using System.Windows.Controls;

namespace CFABingo.Panels;

public partial class RecentPanel
{
    private Orientation _orientation;
    
    public Orientation Orientation
    {
        get => _orientation;
        set
        { _orientation = value; SetupOrientation(); }
    }

    public RecentPanel()
    {
        InitializeComponent();
    }
    
    private void SetupOrientation()
    {
        RecentBallsContainer.Orientation = Orientation;
        PanelHeader.Orientation = Orientation;
        
        if (Orientation == Orientation.Horizontal)
        {
            // Standard orientation
            ScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            ScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
        }
        else
        {
            ScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            ScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
        }
    }
}
